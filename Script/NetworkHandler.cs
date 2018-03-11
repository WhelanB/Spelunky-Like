using UnityEngine;
using System.Collections;
using Lidgren.Network;
public class NetworkHandler : MonoBehaviour {

    public Transform hostPlayer;
    public Transform clientPlayer;
    public bool isHost = true;
    NetServer server;
    NetClient client;

    void Awake()
    {
        
        NetPeerConfiguration config = new NetPeerConfiguration("uaimh");
        config.SimulatedMinimumLatency = 0.1f;
        if (isHost)
        {  
            config.Port = 3074;
            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            server = new NetServer(config);
            server.Start();
        }
        else
        {
            client = new NetClient(config);
            client.Start();
            client.Connect("127.0.0.1", 3074);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (isHost )
        {
            NetIncomingMessage msg1;
            while ((msg1 = server.ReadMessage()) != null)
            {
                switch (msg1.MessageType)
                {
                    case NetIncomingMessageType.ConnectionApproval:
                        msg1.SenderConnection.Approve();
                        break;

                }
            }
            if (server.Connections.Count > 0)
            {
                NetOutgoingMessage msg = server.CreateMessage();
                msg.Write(hostPlayer.transform.position.x);
                msg.Write(hostPlayer.transform.position.y);
                msg.Write(hostPlayer.GetComponent<Rigidbody>().velocity.x);
                msg.Write(hostPlayer.GetComponent<Rigidbody>().velocity.y);
                server.SendMessage(msg, server.Connections[0], NetDeliveryMethod.UnreliableSequenced);
            }
            
        }
        else
        {
            NetIncomingMessage msg;
            while ((msg = client.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        Debug.Log("got message");
                        hostPlayer.GetComponent<Lerp>().addLerp(new Vector2(msg.ReadFloat(), msg.ReadFloat()), (new Vector2(msg.ReadFloat(), msg.ReadFloat())));
                        break;
                }
                
            }
        }
	}
}

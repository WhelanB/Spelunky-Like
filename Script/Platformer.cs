using UnityEngine;
using System.Collections;
using System;

public class Platformer : MonoBehaviour {
    public Inventory inventory;
    public bool drawInventory = false;
    int y = 0;
    public Transform item;
    public Slot inventoryUI;
    public State pState;
    public MoveState moveState;
    public HangState hangState;
    Rigidbody rigidbody;
    bool wasWall = false;
    bool isWall = false;
    void Awake()
    {
        rigidbody = this.transform.GetComponent<Rigidbody>();
        moveState = new MoveState(this.transform.GetComponent<Rigidbody>(), this.transform.GetComponent<Animator>(), this.transform);
        hangState = new HangState(this.transform.GetComponent<Rigidbody>(), this.transform.GetComponent<Animator>(), this.transform);
        inventory = new Inventory(inventoryUI);
        inventoryUI.Setup(inventory);
        pState = moveState;
    }
   



    void Update()
    {
        pState.update();
        if (Input.GetKeyDown("i"))
        {
            inventoryUI.ShowUI(inventory);
        }
        wasWall = isWall;
        isWall = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector2.right * transform.localScale.x, out hit,  0.3f) )
        {
            if(hit.transform.tag == "Terrain")
            {
                isWall = true;
            }
            
        }

        if(!wasWall && isWall && rigidbody.velocity.y < 0 && !Physics.Raycast(transform.position, Vector2.down, 1f) && !Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 0.2f), Vector2.right * transform.localScale.x, 0.3f))
        {
            pState = hangState;
        }
        


        
        
       
            
           
        

        
        

        
        
    }

    
        
       
        
    

   
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Lerp : MonoBehaviour {
    public Vector2 oldPos = new Vector2(0, 0);
    public Vector2 newPos = new Vector2(0, 0);
    // Update is called once per frame
    void Update () {
        transform.position = Vector2.Lerp(oldPos, newPos, 0.1f);
	}

    public void addLerp(Vector2 newPosition, Vector2 velocity)
    {
        GetComponent<Rigidbody>().velocity = velocity;
        oldPos = newPos;
        newPos = newPosition;
    }
}

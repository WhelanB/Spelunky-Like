using UnityEngine;
using System.Collections;

public class SnakeAI : MonoBehaviour {

    public int hp = 10;
	void Update () {
        this.transform.position += Vector3.left/1000f * transform.localScale.x;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right * -1 * transform.localScale.x, out hit, 0.6f))
        {
            if(hit.transform.tag == "Terrain")
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            
        }

        if(hp < 0)
        {
            Destroy(this.gameObject);
        }
	}


}

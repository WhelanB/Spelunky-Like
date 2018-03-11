using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Climable : MonoBehaviour {

	public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlatformerCharacter2D>().canClimb = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlatformerCharacter2D>().canClimb = true;
        }
    }
}

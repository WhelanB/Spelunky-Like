using UnityEngine;
using System.Collections;

public class ItemEntity : MonoBehaviour {
    public ItemStack item;
    Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
        this.transform.GetComponent<SpriteRenderer>().sprite = item.item.GetSprite();
        this.transform.GetChild(0).GetComponent<TextMesh>().text = item.count + "";

    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Platformer>().inventory.Add(this.item.item, this.item.count);
            Destroy(this.transform.parent.gameObject);
        }
    }

    
	
}

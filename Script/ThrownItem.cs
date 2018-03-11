using UnityEngine;
using System.Collections;

public class ThrownItem : MonoBehaviour {

    Rigidbody r;
    public Transform item;
    Vector3 oldVelocity;
    void Awake()
    {
        r = transform.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (r.IsSleeping())
        {
            Transform thisItem = (Transform)MonoBehaviour.Instantiate(item, this.transform.position, Quaternion.identity);
            thisItem.GetChild(0).GetComponent<ItemEntity>().item = new ItemStack(Item.stone);
            Destroy(this.gameObject);
        }

        oldVelocity = r.velocity;
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.GetComponent<SnakeAI>() != null && !r.IsSleeping())
        {
            other.transform.GetComponent<SnakeAI>().hp--;
            other.transform.GetComponent<Rigidbody>().AddForce(this.r.velocity.normalized * 100f);
            Destroy(this.gameObject);
        }
    }
}

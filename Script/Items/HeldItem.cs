using UnityEngine;
using System.Collections;

public class HeldItem : MonoBehaviour {

    public Item item;
    public Platformer p;
    public Transform itemDrop;
    int slotBeingHeld; //The slot from which the item the player is holding comes 0 < x < 4
    bool canSwing = true;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<DamageableRock>() != null)
        {
            other.transform.GetComponent<DamageableRock>().Damage(2, item, this);
        }
        if(other.tag == "Enemy")
        {
            other.transform.GetComponent<SnakeAI>().hp--;
        }
    }
    void Update()
    {
        if (canSwing)
        {
            if (Input.GetKeyDown("q") && item != Item.empty)
            {
                Transform drop = (Transform)MonoBehaviour.Instantiate(itemDrop, new Vector2(this.transform.position.x + this.transform.parent.localScale.x * 0.5f, this.transform.position.y), Quaternion.identity);
                drop.GetChild(0).GetComponent<ItemEntity>().item = new ItemStack(item);
                drop.GetComponent<Rigidbody>().velocity = this.transform.parent.GetComponent<Rigidbody>().velocity + (Vector3.up * 5f) + (Vector3.right * this.transform.parent.localScale.x);
                p.inventory.Remove(item);
                
            }
        }
        if (canSwing)
        {
            if (Input.GetKeyDown("1"))
            {
                this.SetItem(0);
            }
            if (Input.GetKeyDown("2"))
            {
                this.SetItem(1);
            }
            if (Input.GetKeyDown("3"))
            {
                this.SetItem(2);
            }
            if (Input.GetKeyDown("4"))
            {
                this.SetItem(3);
            }
        }
        
        if (item != null)
        {
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Nothing"))
            {
                this.transform.GetComponent<SpriteRenderer>().enabled = false;
                canSwing = true;
            }
            if (Input.GetMouseButton(0) && canSwing)
            {
                canSwing = false;
                this.transform.GetComponent<SpriteRenderer>().enabled = true;
                item.Use(this.transform);
                this.GetComponent<Animator>().SetTrigger("isSwinging");
                if (item.used && item != Item.empty)
                {
                    p.inventory.Remove(item);
                }

            }
            if (Input.GetMouseButton(1) && canSwing)
            {
                canSwing = false;
                this.transform.GetComponent<SpriteRenderer>().enabled = true;
                item.RightClick(this.transform);
                this.GetComponent<Animator>().SetTrigger("isSwinging");

            }

        }
        
        
    }

    public void Refresh()
    {
        int i = slotBeingHeld;
        this.transform.GetComponent<SpriteRenderer>().sprite = p.inventory.GetItems()[i].item.GetSprite();
        item = p.inventory.GetItems()[i].item;
    }
    public void SetItem(int i)
    {
        slotBeingHeld = i;
        this.transform.GetComponent<SpriteRenderer>().sprite = p.inventory.GetItems()[i].item.GetSprite();
        item = p.inventory.GetItems()[i].item;
    }
}

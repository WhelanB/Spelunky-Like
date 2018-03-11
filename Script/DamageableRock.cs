using UnityEngine;
using System.Collections;

public class DamageableRock : MonoBehaviour {
    public DropPair[] drops;
    public Transform itemEntity;
    public int HP = 10;
    public int requiredTool = -1;
	public void Damage(int amount, Item holdingItem, HeldItem item)
    {
        if (holdingItem is ItemPickaxe && !item.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Nothing"))
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hit");
            if (HP > amount)
            {
                HP -= amount;
            }
            else
            {
                  if(((ItemPickaxe)holdingItem).toolLevel >= requiredTool)
                  {
                     Drop();
                     Destroy(this.gameObject);
                 }
                 else
                 {
                        Destroy(this.gameObject);
                 }
            }

        }
    }

    public void Drop()
    {
        foreach(DropPair stack in drops)
        {
            Transform drop = (Transform)MonoBehaviour.Instantiate(itemEntity, this.transform.position, Quaternion.identity);
            drop.GetChild(0).GetComponent<ItemEntity>().item = new ItemStack(Item.GetItemFromID(stack.ItemID), stack.Amount);
        }
    }
}

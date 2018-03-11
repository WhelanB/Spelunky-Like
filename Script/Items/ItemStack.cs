using UnityEngine;
using System.Collections;

public class ItemStack
{

    public int count = 1;
    public Item item;

    public ItemStack(Item i)
    {
        item = i;
    }

    public ItemStack(Item i, int amount)
    {
        item = i;
        count = amount;
    }

    public bool Equals(ItemStack i)
    {
        return this.item == i.item;
    }
}

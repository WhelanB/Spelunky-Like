using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    ItemStack[] items = new ItemStack[24];
    Slot inventoryUI;
    public Inventory(Slot UI)
    {
        inventoryUI = UI;
        for(int i = 0; i < 24; i++)
        {
            items[i] = new ItemStack(Item.empty, 0);
        }
    }

    public bool Add(Item item, int count)
    {
        for (int i = 0; i < 24; i++)
        {
            if (items[i].item == item)
            {
                items[i].count += count;
                inventoryUI.change(i);
                return true;
            }
        }
        for(int i = 0; i < 24; i++)
        {
            if(items[i].item == Item.empty)
            {
                items[i] = new ItemStack(item, count);
                inventoryUI.change(i);
                return true;
            }
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        ItemStack temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
        inventoryUI.change(index1);
        inventoryUI.change(index2);
    }

    public bool Remove(Item item)
    {
        for(int i = 0; i < 24; i++)
        {
            ItemStack stack = items[i];
            if(stack.item == item)
            {
                if(stack.count > 1 )
                {
                    stack.count--;
                }
                else
                {
                    items[i] = new ItemStack(Item.empty, 0);
                }
                inventoryUI.change(i);
                return true;
            }
        }
        return false;
    }

    public bool HasItem(Item i)
    {
        foreach (ItemStack stack in items)
        {
            if(stack.item == i)
            {
                return true;
            }
            
        }
        return false;
    }
    public ItemStack[] GetItems()
    {
        return items;
    }



}

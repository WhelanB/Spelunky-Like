using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Item {
    private int damage = 1;
    private int itemID;
    private int protection;
    private Sprite sprite;
    private string displayName;
    public static List<Item> items = new List<Item>();

    public bool used = false;

    public static Item empty = new Item(Resources.Load<Sprite>("items/blank"), "", 0);
    public static Item wood = new Item(Resources.Load<Sprite>("items/wood"), "Wood", 1);
    public static ItemProjectile stone = new ItemProjectile( Resources.Load<Sprite>("items/stone"), "Stone", 2, 1);
    public static Item iron = new Item(Resources.Load<Sprite>("items/iron"), "Iron", 3);
    public static Item gold = new Item(Resources.Load<Sprite>("items/gold"), "Gold", 4);
    public static ItemSword wood_sword = new ItemSword(0, Resources.Load<Sprite>("items/sword"), "Wooden Sword", 5, 5);
    public static ItemPickaxe wood_pickaxe = new ItemPickaxe(0, Resources.Load<Sprite>("items/wood_pickaxe"), "Wooden Pickaxe", 6, 5);


    public Item(Sprite img, string name, int id)
    {
        sprite = img;
        itemID = id;
        displayName = name;
        //items[itemID] = this;
        items.Add(this);
    }

    public Item(Sprite img, string name, int id, int dmg)
    {
        sprite = img;
        itemID = id;
        displayName = name;
        damage = dmg;
    }

    public static Item GetItemFromID(int id)
    {
        return items[id];
    }

    public virtual void Use(Transform t)
    {
        Debug.Log("Used Item");
    }

    public virtual void RightClick(Transform t)
    {
        Debug.Log("Right Clicked with Item");
    }

    public int GetID()
    {
        return this.itemID;
    }

    public Sprite GetSprite()
    {
        return this.sprite;
    }

    public string GetDisplayName()
    {
        return this.displayName;
    }

}

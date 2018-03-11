using UnityEngine;
using System.Collections;

public class ItemPickaxe : Item
{
    public int toolLevel;

    public ItemPickaxe(int toolType, Sprite img, string name, int id, int dmg) : base(img, name, id, dmg)
    {
        toolLevel = toolType;
    }

    public override void Use(Transform t)
    {
        Debug.Log("Used the Pickaxe");
    }
}

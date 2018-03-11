using UnityEngine;
using System.Collections;

public class ItemSword : Item {
    int toolLevel;

	public ItemSword(int toolType, Sprite img, string name, int id, int dmg) : base(img, name, id, dmg)
    {
        toolLevel = toolType;    
    }

    public override void Use(Transform t)
    {
        Debug.Log("Swung a Sword");
    }
}

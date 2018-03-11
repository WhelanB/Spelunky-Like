using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slot : MonoBehaviour {

    public Image[] slots;
    public Text[] slotTexts;
    public int selection1 = -1;
    public int selection2 = -1;
    ItemStack[] inv;
    public HeldItem holdingSlot;
    bool active = false;

    public void Setup(Inventory inventory)
    {
        inv = inventory.GetItems();
    }
    public void ShowUI(Inventory inventory)
    {
        
        inv = inventory.GetItems();
        active = !active;
        for(int i = 0; i < inv.Length; i++)
        {
            
            if(active)
                transform.GetChild(0).GetChild(i).gameObject.SetActive(active);
            else if(i > 3)
                transform.GetChild(0).GetChild(i).gameObject.SetActive(active);

            slots[i].sprite = inv[i].item.GetSprite();
            slotTexts[i].text = (inv[i].count > 0) ? inv[i].count + "" : "";

        }
    }

    public void change(int i)
    {
        if(i < 4)
        {
            holdingSlot.Refresh();
        }
        slots[i].sprite = inv[i].item.GetSprite();
        slotTexts[i].text = (inv[i].count > 0)? inv[i].count + "" : "";
    }

    public void Highlight(string selectionName)
    {
        int selectionIndex = int.Parse(selectionName);
        Debug.Log("Selected " + selectionIndex);
        if(selection1 == -1)
        {
            selection1 = selectionIndex;
            slots[selection1].transform.parent.GetComponent<Button>().image.color = Color.yellow;
            
        }
        else if(selection2 == -1)
        {
            
            selection2 = selectionIndex;
            slots[selection2].transform.parent.GetComponent<Button>().image.color = Color.yellow;
            ItemStack temp = inv[selection1];
            inv[selection1] = inv[selection2];
            inv[selection2] = temp;
            slots[selection1].transform.parent.GetComponent<Button>().image.color = Color.white;
            slots[selection2].transform.parent.GetComponent<Button>().image.color = Color.white;
            change(selection1);
            change(selection2);
            selection1 = -1; selection2 = -1;
        }
    }
}

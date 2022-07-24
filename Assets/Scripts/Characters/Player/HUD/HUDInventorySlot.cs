using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDInventorySlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text countText;
    public TMP_Text indexText;

    public void SetupSlot(InventorySlot slot)
    {
        if (slot.Item == null)
        {
            icon.sprite = null;
            icon.color = new Color(1, 1, 1, 0);
            countText.text = "";
            return;
        }

        Sprite img = slot.Item.Icon;
        icon.sprite = img;
        icon.color = new Color(1, 1, 1, 1);
        if (slot.Item.IsStackable)
        {
            countText.text = slot.Count.ToString();
        }
        else
        {
            countText.text = "";
        }
    }
}

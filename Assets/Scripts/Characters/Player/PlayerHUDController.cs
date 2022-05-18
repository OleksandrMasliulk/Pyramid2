using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerInventoryController;

public class PlayerHUDController : MonoBehaviour
{
    public GameObject hud;

    public Text interractTooltip;

    public Slider sanitySlider;
    public Image sanitySliderFill;

    public GameObject paintDirection;

    public Color sanity100;
    public Color sanity75;
    public Color sanity50;
    public Color sanity25;

    public GameObject[] inventorySlots;
    private int highlightedSlot;

    private void Start()
    {
        DialogueManager.OnStartDialogue += HideHUD;
        DialogueManager.OnEndDialogue += ShowHUD;
    }

    public void UpdateSanitySlider(int newValue)
    {
        sanitySlider.value = newValue;

        if (newValue > 75)
        {
            sanitySliderFill.color = sanity100;
        }
        else if (newValue > 50 && newValue <= 75)
        {
            sanitySliderFill.color = sanity75;
        }
        else if (newValue > 25 && newValue <= 50)
        {
            sanitySliderFill.color = sanity50;
        }
        else
        {
            sanitySliderFill.color = sanity25;
        }
    }

    public void SetTooltipText(string newText)
    {
        interractTooltip.text = newText;
    }

    public void ShowTooltip()
    {
        interractTooltip.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        interractTooltip.gameObject.SetActive(false);
    }

    public void HighlightInventorySlot(int index) 
    {
        inventorySlots[highlightedSlot].GetComponent<Image>().color = Color.white;

        inventorySlots[index].GetComponent<Image>().color = Color.green;
        highlightedSlot = index;
    }

    public void UpdateInventorySlot(int index, InventorySlot data)
    {
        Image img = inventorySlots[index].transform.GetChild(0).GetComponent<Image>();
        Text txt = inventorySlots[index].transform.GetChild(2).GetComponent<Text>();

        if (data.item != null)
        {
            if (data.item.inventoryImage != null)
            {
                img.color = Color.white;
                img.sprite = data.item.inventoryImage;
            }
            else
            {
                img.color = new Color(0, 0, 0, 0);
                img.sprite = null;
            }

            string countText;
            if (data.count == 0)
            {
                countText = "";
            }
            else
            {
                countText = data.count.ToString();
            }

            txt.text = countText;
        }

        else
        {
            img.color = new Color(0, 0, 0, 0);
            img.sprite = null;
            txt.text = "";
        }    
    }

    public void ShowHUD()
    {
        hud.SetActive(true);
    }

    public void HideHUD()
    {
        hud.SetActive(false);
    }

    public void ShowPaintDirection()
    {
        paintDirection.SetActive(true);
    }

    public void HidePaintDirection()
    {
        paintDirection.SetActive(false);
    }

    private void OnDisable()
    {
        DialogueManager.OnStartDialogue -= HideHUD;
        DialogueManager.OnEndDialogue -= ShowHUD;
    }
}
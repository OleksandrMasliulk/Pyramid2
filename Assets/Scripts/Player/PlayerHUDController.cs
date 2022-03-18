using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    public GameObject hud;

    public Text interractTooltip;

    public Slider sanitySlider;
    public Image sanitySliderFill;

    public Color sanity100;
    public Color sanity75;
    public Color sanity50;
    public Color sanity25;

    public void UpdateSanitySlider(int newValue)
    {
        sanitySlider.value = newValue;

        if (newValue >= 75)
        {
            sanitySliderFill.color = sanity100;
        }
        else if (newValue >= 50 && newValue < 75)
        {
            sanitySliderFill.color = sanity75;
        }
        else if (newValue >= 25 && newValue < 50)
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

    public void ShowHUD()
    {
        hud.SetActive(true);
    }

    public void HideHUD()
    {
        hud.SetActive(false);
    }
}

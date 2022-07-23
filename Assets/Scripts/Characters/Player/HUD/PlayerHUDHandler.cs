using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDHandler : MonoBehaviour
{
    [SerializeField] private GameObject _hud;
    public GameObject HUD => _hud;

    [SerializeField] private HUDTooltip _tooltip;
    public HUDTooltip Tooltip => _tooltip;
    [SerializeField] private HUDInventory _inventory;
    public HUDInventory Inventory => _inventory;
    [SerializeField] private HUDSanitySlider _sanitySlider;
    public HUDSanitySlider SanitySlider => _sanitySlider;
    [SerializeField] private HUDArrowDirection _arrowDirection;
    public HUDArrowDirection ArrowDirection => _arrowDirection;

    public void InitHUD(PlayerDrivenCharacter character, PlayerCharacterStatsSO stats)
    {
        if (character.GetComponent<PlayerInventoryHandler>())
            Inventory.Init(stats.SlotCount);

        if (character.GetComponent<PlayerSanityHandler>())
            SanitySlider.gameObject.SetActive(true);
    }
}

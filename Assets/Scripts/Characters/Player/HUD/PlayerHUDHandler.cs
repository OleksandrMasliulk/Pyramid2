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

    public void InitHUD(PlayerDrivenCharacter player) {
        if (player.GetComponent<PlayerInventoryHandler>())
            Inventory.Init(player);

        if (player.GetComponent<PlayerSanityHandler>()) {
            SanitySlider.InitSanityHUD(player);
            SanitySlider.gameObject.SetActive(true);
        }
    }
}

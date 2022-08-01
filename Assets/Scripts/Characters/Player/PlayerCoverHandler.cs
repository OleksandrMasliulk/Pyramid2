using UnityEngine;

[RequireComponent(typeof(PlayerDrivenCharacter))]
public class PlayerCoverHandler : MonoBehaviour {
    private PlayerDrivenCharacter _character;
    private Collider2D _col;
    [SerializeField] private SpriteRenderer _sr;

    private void Awake() {
        _character = GetComponent<PlayerDrivenCharacter>();
        _col = GetComponent<Collider2D>();
    }

    public void Cover() {
        gameObject.ChangeTreeLayer(7);
        _col.enabled = false;
        _character.MovementHandler.enabled = false;
        _character.InventoryHandler.enabled = false;
        _character.SanityHandler.enabled = false;
        _sr.enabled = false;
    }

    public void Uncover() {
        gameObject.ChangeTreeLayer(6);
        _col.enabled = true;
        _character.MovementHandler.enabled = true;
        _character.InventoryHandler.enabled = true;
        _character.SanityHandler.enabled = true;
        _sr.enabled = true;
    }
}

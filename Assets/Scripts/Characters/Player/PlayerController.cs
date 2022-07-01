using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterBase
{
    public new PlayerStats Stats => (PlayerStats)_stats;
    public new PlayerGraphicsController GraphicsController => (PlayerGraphicsController)_graphicsController;

    [SerializeField] private PlayerHUDController _hudController;
    public PlayerHUDController HUDController => _hudController;
    [SerializeField] private PlayerMovementController _movementController;
    public PlayerMovementController MovementController => _movementController;
    [SerializeField] private PlayerInterractionController _interractionController;
    public PlayerInterractionController InterractionController => _interractionController;
    [SerializeField] private PlayerInventoryController _inventoryController;
    public PlayerInventoryController InventoryController => _inventoryController;
    [SerializeField] private PlayerSanityController _sanityController;
    public PlayerSanityController SanityController => _sanityController;
    [SerializeField] private PlayerHealthController _healthController;
    public PlayerHealthController HealthController => _healthController;
    [SerializeField] private PlayerCoverController _coverController;
    public PlayerCoverController CoverController => _coverController;

    [SerializeField] private Camera _ghostCamera;
    public Camera GhostCamera => _ghostCamera;

    public PlayerAliveState aliveState;
    public PlayerCoveredState coveredState;
    public PlayerDeadState deadState;
    public PlayerGhostState ghostState;
    private PlayerState currentState;

    private void Start()
    {
        aliveState = new PlayerAliveState();
        coveredState = new PlayerCoveredState();
        deadState = new PlayerDeadState();
        ghostState = new PlayerGhostState();

        SetState(aliveState);
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        currentState.OnDirectionInput(this, dir.normalized);

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentState.OnInterractInput(this);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            currentState.OnInventoryUsePressInput(this);
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            currentState.OnInventoryUseReleaseInput(this);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            currentState.OnInventoryDropInput(this);
        }
    }

    public void SetState(PlayerState state)
    {
        if (currentState != null)
            currentState.OnStateExit(this);

        this.currentState = state;
        currentState.OnStateEnter(this);
    }

    public void SetPlayerLayer(LayerMask layer)
    {
        this.gameObject.layer = layer;
    }

    public override void TakeDamage(int damage)
    {
        _healthController.Die();
    }
}

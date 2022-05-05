using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private PlayerParameters parameters;
    [SerializeField] private PlayerGraphicsController graphicsController;
    [SerializeField] private PlayerHUDController hudController;
    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerInterractionController interractionController;
    [SerializeField] private PlayerInventoryController inventoryController;
    [SerializeField] private PlayerSanityController sanityController;
    [SerializeField] private PlayerHealthController healthController;
    [SerializeField] private PlayerCoverController coverController;

    public PlayerAliveState aliveState;
    public PlayerCoveredState coveredState;
    public PlayerDeadState deadState;
    public PlayerGhostState ghostState;
    private PlayerState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

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
        this.currentState = state;
        currentState.OnStateEnter(this);
    }

    public void SetPlayerLayer(LayerMask layer)
    {
        this.gameObject.layer = layer;
    }

    public void SetGhost()
    {
        if (parameters.isAlive)
            return;

        parameters.SetIsGhost(true);
        SetPlayerLayer(11);
        graphicsController.SetGhostGraphics();

    }

    public PlayerParameters GetPlayerParameters()
    {
        return parameters;
    }

    public PlayerGraphicsController GetPlayerGraphicsController()
    {
        return graphicsController;
    }

    public PlayerHUDController GetPlayerHUDContorller()
    {
        return hudController;
    }

    public PlayerMovementController GetPlayerMovementController()
    {
        return movementController;
    }

    public PlayerInterractionController GetPlayerInterractionController()
    {
        return interractionController;
    }

    public PlayerInventoryController GetPlayerInventoryController()
    {
        return inventoryController;
    }

    public PlayerSanityController GetPlayerSanityController()
    {
        return sanityController;
    }

    public PlayerHealthController GetPlayerHealthController()
    {
        return healthController;
    }

    public PlayerCoverController GetPlayerCoverController()
    {
        return coverController;
    }
}

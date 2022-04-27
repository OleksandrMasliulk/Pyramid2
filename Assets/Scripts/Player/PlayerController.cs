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

    public void SetPlayerLayer(LayerMask layer)
    {
        this.gameObject.layer = layer;
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
}

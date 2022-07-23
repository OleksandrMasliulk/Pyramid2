using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _aliveMask;
    [SerializeField] private LayerMask _ghostMask;

    public void SetGhostCamera()
    {
        _camera.cullingMask = _ghostMask;
    }

    public void SetAlliveCamera()
    {
        _camera.cullingMask = _aliveMask;
    }
}

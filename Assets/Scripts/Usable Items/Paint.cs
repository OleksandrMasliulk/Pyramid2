using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Paint : Item
{
    private Vector3 mousePosTemp;

    public Paint(PaintSO so/*, GameObject prefab*/) : base(so/*, prefab*/)
    {
    }

    public override void Use(PlayerController user)
    {
        SpawnArrow(MouseUtils.GetMouseDragDirectionString(mousePosTemp, Input.mousePosition), user);
        Debug.Log("Paint used");
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        user.HUDController.ShowPaintDirection();
        mousePosTemp = Input.mousePosition;

        return !UseOnRelease;
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        user.HUDController.HidePaintDirection();
        Use(user);

        return UseOnRelease;
    }
    private void SpawnArrow(string direction, PlayerController user)
    {
        if (direction == null)
        {
            direction = "Up";
        }

        GameObject prefab = (GameObject)Resources.Load("Usable Items/Arrow " + direction);
        if (prefab == null)
        {
            Debug.Log("No RESOURCE found");
            return;
        }

        MonoBehaviour.Instantiate((GameObject)prefab, user.transform.position, Quaternion.identity);
    }

    public override void OnDrop(PlayerController user)
    {
    }
}

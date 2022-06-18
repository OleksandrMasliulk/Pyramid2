using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Paint : Item
{
    private Vector3 mousePosTemp;

    public override void Use(PlayerController user)
    {
        base.Use(user);

        SpawnArrow(MouseUtils.GetMouseDragDirectionString(mousePosTemp, Input.mousePosition), user);
        Debug.Log("Paint used");
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        user.GetPlayerHUDContorller().ShowPaintDirection();
        mousePosTemp = Input.mousePosition;

        return base.OnButtonPressed(user);
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        user.GetPlayerHUDContorller().HidePaintDirection();
        Use(user);

        return base.OnButtonReleased(user);
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
}

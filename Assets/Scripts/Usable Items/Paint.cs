using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Paint : Item, IUseOnPress, IUseOnRelease
{
    private Vector3 _mousePosTemp;

    public Paint(PaintSO so) : base(so)
    {
    }

    private void SpawnArrow(string direction, CharacterBase user)
    {
        //if (direction == null)
        //{
        //    direction = "Up";
        //}

        //GameObject prefab = (GameObject)Resources.Load("Usable Items/Arrow " + direction);
        //if (prefab == null)
        //{
        //    Debug.Log("No RESOURCE found");
        //    return;
        //}

        Debug.Log("Paint used");
        //MonoBehaviour.Instantiate((GameObject)prefab, user.transform.position, Quaternion.identity);
    }

    public UseItemCallback UseOnRelease(CharacterBase user)
    {
        if (user.TryGetComponent<PlayerDrivenCharacter>(out var player))
            player.HUDHandler.ArrowDirection.gameObject.SetActive(false);

        return Use(user);
    }

    public UseItemCallback Use(CharacterBase user)
    {
        SpawnArrow(MouseUtils.GetMouseDragDirectionString(_mousePosTemp, Input.mousePosition), user);

        return new UseItemCallback(UseItemCallback.ResultType.Success);
    }

    public UseItemCallback UseOnPress(CharacterBase user)
    {
        if (user.TryGetComponent<PlayerDrivenCharacter>(out var player))
            player.HUDHandler.ArrowDirection.gameObject.SetActive(true);
        _mousePosTemp = Input.mousePosition;

        return new UseItemCallback(UseItemCallback.ResultType.Failed);
    }
}

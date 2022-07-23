using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

[System.Serializable]
public class Paint : Item, IUseOnPress, IUseOnRelease
{
    private Vector3 _mousePosTemp;

    public Paint(PaintSO so) : base(so)
    {
    }

    private void SpawnArrow(string direction, CharacterBase user)
    {
        if (direction == null)
        {
            direction = "Up";
        }

        var op = Addressables.LoadAssetAsync<GameObject>("Assets/Resources_moved/Usable Items/Arrow " + direction + ".prefab");
        op.Completed += (op) =>
        {
            Debug.Log("Paint Used");
            MonoBehaviour.Instantiate(op.Result, user.transform.position, Quaternion.identity);
        };
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

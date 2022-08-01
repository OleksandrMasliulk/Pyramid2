using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class Paint : Item, IUseOnPress, IUseOnRelease {
    private Vector3 _mousePosTemp;

    public Paint(PaintSO so) : base(so) => _mousePosTemp = Vector3.zero;

    private void SpawnArrow(string direction, CharacterBase user) {
        if (direction == null)
            direction = "Up";

        var op = Addressables.LoadAssetAsync<GameObject>("Assets/Resources_moved/Usable Items/Arrow " + direction + ".prefab");
        Debug.Log("Assets/Resources_moved/Usable Items/Arrow " + direction + ".prefab");
        op.Completed += (op) => {
            Debug.Log("Paint Used");
            MonoBehaviour.Instantiate(op.Result, user.transform.position, Quaternion.identity);
        };
    }

    public UseItemCallback UseOnRelease(CharacterBase user) {
        if (user.TryGetComponent<PlayerDrivenCharacter>(out var player))
            player.HUDHandler.ArrowDirection.gameObject.SetActive(false);

        return Use(user);
    }

    public UseItemCallback Use(CharacterBase user) {
        PlayerDrivenCharacter player = (PlayerDrivenCharacter)user;

        SpawnArrow(MouseUtils.GetMouseDragDirectionString(_mousePosTemp, player.InputController.CharacterActions.Pointer.ReadValue<Vector2>()), player);

        return new UseItemCallback(UseItemCallback.ResultType.Success);
    }

    public UseItemCallback UseOnPress(CharacterBase user) {
        if (user.TryGetComponent<PlayerDrivenCharacter>(out var player)) {
            player.HUDHandler.ArrowDirection.gameObject.SetActive(true);
            _mousePosTemp = player.InputController.CharacterActions.Pointer.ReadValue<Vector2>();
        }

        return new UseItemCallback(UseItemCallback.ResultType.Failed);
    }
}

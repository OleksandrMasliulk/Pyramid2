using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets;

public class ButtonSoundAssigner : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    [SerializeField] private AssetReference _soundboard;
    private ButtonSoundBoardSO _loadedSoundboard;
    private Button _btn;

    public void OnPointerEnter(PointerEventData eventData) => AudioManager.Instance.PlaySound(_loadedSoundboard.ButtonOverlapSound, 1f);

    public void OnSelect(BaseEventData eventData) => AudioManager.Instance.PlaySound(_loadedSoundboard.ButtonOverlapSound, 1f);

    private async void Awake() {
        _loadedSoundboard = await _soundboard.LoadAssetAsyncSafe<ButtonSoundBoardSO>();

        _btn = GetComponent<Button>();
        if (_btn == null) {
            Debug.Log("No Button Component attached");
            Destroy(this.gameObject);
        }

        _btn.onClick.AddListener(() => {
            AudioManager.Instance.PlaySound(_loadedSoundboard.ButtonClickSound, 1f);
        });
    }

    private void OnDestroy() {
        _loadedSoundboard.Dispose();
        _soundboard.ReleaseAssetSafe();
    }
}


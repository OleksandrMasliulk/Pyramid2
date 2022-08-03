using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class Lever : MonoBehaviour, IInterractible {
    public Transform ObjectReference => transform;

    [SerializeField] private UnityEvent _toggleOnAction;
    [SerializeField] private UnityEvent _toggleOffAction;
    [SerializeField] private Animator _anim;
    private bool isOn;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    [SerializeField] private AssetReference _soundboardReference;
    private LeverSoundboardSO _loadedSoundboard;

    private async void Awake() {
        isOn = false;
        _anim.SetBool("On", isOn);
        _loadedSoundboard = await _soundboardReference.LoadAssetAsyncSafe<LeverSoundboardSO>();
    }

    private void On() {
        _toggleOnAction?.Invoke();
        isOn = true;
    }

    private void Off() {
        _toggleOffAction?.Invoke();
        isOn = false;
    }

    public void Interract(CharacterBase user) {
        if (isOn)
            Off();
        else
            On();
        _anim.SetBool("On", isOn);
        AudioManager.Instance.PlayerSound3D(_loadedSoundboard.LeverSwitchSound, transform.position, 1f);
    }

    private void OnDestroy() {
        _loadedSoundboard.Dispose();
        _soundboardReference.ReleaseAssetSafe();
    }
}

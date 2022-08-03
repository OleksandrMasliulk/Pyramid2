using UnityEngine;
using UnityEngine.AddressableAssets;

public class Door : MonoBehaviour, /*IInterractible,*/ ISwitchable {
    public Transform ObjectReference => transform;

    [SerializeField] private Collider2D _door;
    [SerializeField] private Animator _anim;

    [SerializeField] private string _closedTooltip;
    [SerializeField] private string _openedTooltip;
    private string _currentTooltip;
    public string Tooltip => _currentTooltip;

    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;
    private bool isClosed;

    [SerializeField] private AssetReference _soundboardReference;
    private DoorSoundboardSO _loadedSoundboard;

    private async void Awake() {
        isClosed = true;
        _door.enabled = true;
        _currentTooltip = _closedTooltip;
        _loadedSoundboard = await _soundboardReference.LoadAssetAsyncSafe<DoorSoundboardSO>();
    }

    // public void Interract(CharacterBase user) {
    //     if (!IsActive)
    //         return;

    //     if (isClosed)
    //         Open();
    //     else
    //         Close();
    // }
    
    public void Open() {
        if (!isClosed)
            return;

        isClosed = false;
        _door.enabled = false;

        _currentTooltip = _openedTooltip;
        _anim.SetBool("Opened", true);
        AudioManager.Instance.PlayerSound3D(_loadedSoundboard.DoorOpenSound, transform.position, 1f);
    }

    public void Close() {
        if (isClosed)
            return;

        isClosed = true;
        _door.enabled = true;

        _currentTooltip = _closedTooltip;
        _anim.SetBool("Opened", false);
        AudioManager.Instance.PlayerSound3D(_loadedSoundboard.DoorCloseSound, transform.position, 1f);
    }

    public void Activate() => _isActive = true;

    public void Disable() => _isActive = false;

    private void OnDestroy() {
        _loadedSoundboard.Dispose();
        _soundboardReference.ReleaseAssetSafe();
    }
}

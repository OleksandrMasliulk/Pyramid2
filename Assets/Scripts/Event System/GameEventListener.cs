using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
    [SerializeField] protected GameEvent _gameEvent;
    [SerializeField] protected UnityEvent _event;

    private void Awake() => _gameEvent.Register(this);

    public virtual void RunEvent() => _event?.Invoke();

    private void OnDestroy() => _gameEvent.Deregister(this);
}

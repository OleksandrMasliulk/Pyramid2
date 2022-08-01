using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event")]
public class GameEvent : ScriptableObject {
    private HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke() {
        foreach (GameEventListener listener in _listeners)
            listener.RunEvent();
    }

    public void Register(GameEventListener listener) => _listeners.Add(listener);

    public void Deregister(GameEventListener listener) => _listeners.Remove(listener);
}

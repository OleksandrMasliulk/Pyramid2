using UnityEngine;

public abstract class SoundBoardSO : ScriptableObject, IDisposable {
    public abstract void Initialize();
    public abstract void Dispose();
}

using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour {
    public static PickableManager Instance { get; private set; }

    [SerializeField] private List<Pickable> _pickables;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start() {
        foreach (Pickable p in _pickables)
            p.Init();
    }

    public void AddToList(Pickable item) => _pickables.Add(item);

    public void RemoveFromList(Pickable item) => _pickables.Remove(item);
}

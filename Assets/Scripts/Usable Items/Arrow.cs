using UnityEngine;

public class Arrow : MonoBehaviour {
    [SerializeField]private SpriteRenderer _renderer;
    [SerializeField]private Sprite[] _sprites;

    private void Awake() {
        int rand = Random.Range(0, _sprites.Length);
        _renderer.sprite = _sprites[rand];
    }
}
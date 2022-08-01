using UnityEngine;

public class ActionTrigger : MonoBehaviour {
    public GameEvent OnTriggerEvent;

    [SerializeField] private bool destroyOnTrigger;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerDrivenCharacter>() != null) {
            OnTriggerEvent?.Invoke();

            if (destroyOnTrigger)
                Destroy(this.gameObject);
        }
    }
}

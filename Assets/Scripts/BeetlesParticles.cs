using UnityEngine;

public class BeetlesParticles : MonoBehaviour {
    [SerializeField] private ParticleSystem beetlesRunParticles;

    private void OnTriggerEnter2D(Collider2D collision) {
        CharacterBase player = collision.GetComponent<CharacterBase>();

        if (player != null)
            Run();
    }

    private void Run() {
        Instantiate(beetlesRunParticles, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}

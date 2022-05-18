using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetlesParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem beetlesRunParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            Run();
        }
    }

    private void Run()
    {
        Instantiate(beetlesRunParticles, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}

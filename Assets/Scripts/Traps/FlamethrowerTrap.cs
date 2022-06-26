using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerTrap : Trap
{
    public GameObject fireGraphics;
    public ParticleSystem ps; 
    public ParticleSystem ps2;

    public BoxCollider2D damageBox;
    public LayerMask damageLayer;

    public float sanityLossRadius;

    public float rearmTime;

    public float flameThrowingDuration;

    private void Start()
    {
        StartCoroutine(RearmCoroutine());
    }

    IEnumerator ThrowFire()
    {
        float time = flameThrowingDuration;

        ps.Play(); 
        ps2.Play();
        fireGraphics.SetActive(true);
        ReduceSanity(null);
        AudioManager.PlaySound(AudioManager.Sound.FireTrap, transform.position, flameThrowingDuration);

        while (time > 0)
        {
            Collider2D[] cols = Physics2D.OverlapBoxAll(damageBox.transform.position, damageBox.bounds.size, 0f, damageLayer);

            foreach (Collider2D col in cols)
            {
                IDamageable target = col.GetComponent<IDamageable>();
                if (target != null)
                {
                    target.TakeDamage(1);
                }
            }

            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }

        fireGraphics.SetActive(false);

        StartCoroutine(RearmCoroutine());
    }

    IEnumerator RearmCoroutine()
    {
        ps.Stop();
        ps2.Stop();

        yield return new WaitForSeconds(rearmTime);

        StartCoroutine(ThrowFire());
    }

    public override void ReduceSanity(PlayerController target)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, sanityLossRadius, damageLayer);

        PlayerController player;
        foreach (Collider2D col in cols)
        {
            player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SanityController.UpdateSanity(-sanityLoss);
                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(damageBox.transform.position, damageBox.bounds.size);
        Gizmos.DrawWireSphere(transform.position, sanityLossRadius);
    }

    public override void Activate(IDamageable target)
    {
    }
}

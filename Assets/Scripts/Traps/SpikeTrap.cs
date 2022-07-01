using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    [SerializeField] private float spikeDuration;
    private float timeToDisable;

    [SerializeField] private float triggerDelay;
    private bool isTriggered;

    [SerializeField] private Animator anim;

    private void Start()
    {
        isTriggered = false;
        timeToDisable = 0;
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (timeToDisable <= 0)
            {
                Disable();
            }
            else
            {
                timeToDisable -= Time.deltaTime;
            }
        }
    }

    IEnumerator TrapTriggered(IDamageable target)
    {
        yield return new WaitForSeconds(triggerDelay);

        isTriggered = true;
        timeToDisable = spikeDuration;
        Activate(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                ReduceSanity(player);
            }

            StartCoroutine(TrapTriggered(target));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            StopAllCoroutines();
        }
    }

    public override void Activate(IDamageable target)
    {
        target.TakeDamage(1);

        anim.SetBool("isActive", true);
    }

    private void Disable()
    {
        isTriggered = false;
        timeToDisable = spikeDuration;

        anim.SetBool("isActive", false);
    }
}

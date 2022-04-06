using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerTrap : TrapMaster
{
    public GameObject fireGraphics;
    public BoxCollider2D damageBox;

    public float sanityLossRadius;

    public float timeBtwShots;
    public float flameThrowingDuration;

    private bool isThrowingFire;

    protected override void Init()
    {
        base.Init();

        damageBox = fireGraphics.GetComponent<BoxCollider2D>();
        StopThrowingFire();

        StartCoroutine(FlameThrowerCoroutine()); 
    }

    protected override void UpdateSeq()
    {
        if (isThrowingFire)
        {
            Collider2D[] cols = Physics2D.OverlapBoxAll(fireGraphics.transform.position, damageBox.bounds.size, 0f);

            Player target;
            foreach (Collider2D col in cols)
            {
                target = col.GetComponent<Player>();
                if (target != null)
                {
                    target.TakeDamage(1);
                    return;
                }
            }
        }
    }

    IEnumerator FlameThrowerCoroutine()
    {
        while(isActive)
        {
            yield return new WaitForSeconds(timeBtwShots);

            ThrowFire();
            Invoke("StopThrowingFire", flameThrowingDuration);
        }
    }

    private void ThrowFire()
    {
        fireGraphics.SetActive(true);
        isThrowingFire = true;

        AffectSanity(null);
    }

    private void StopThrowingFire()
    {
        fireGraphics.SetActive(false);
        isThrowingFire = false;
    }

    protected override void AffectSanity(Player target)
    {
        base.AffectSanity(target);

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, sanityLossRadius);

        Player player;
        foreach (Collider2D col in cols)
        {
            player = col.GetComponent<Player>();
            if (player != null)
            {
                player.UpdateSanity(-sanityLoss);
                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(fireGraphics.transform.position, damageBox.bounds.size);
        Gizmos.DrawWireSphere(transform.position, sanityLossRadius);
    }
}

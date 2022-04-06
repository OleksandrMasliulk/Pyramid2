using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMaster : MonoBehaviour
{
    public int sanityLoss;
    public float triggerDelay;

    protected bool isActive;

    public float rearmTime;
    private bool isArmed;
    private float timeToRearm;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        isActive = true;
        isArmed = true;
    }

    private void Update()
    {
        UpdateSeq();
    }

    protected virtual void UpdateSeq()
    {
        if (timeToRearm > 0f)
        {
            timeToRearm -= Time.deltaTime;
        }
        else
        {
            isArmed = true;
        }
    }

    public virtual void Trigger(Player target)
    {
        if (isArmed)
        {
            StartCoroutine(ActivateCoroutine(target));
        }
    }

    IEnumerator ActivateCoroutine(Player target)
    {
        yield return new WaitForSeconds(triggerDelay);

        Activate(target);
    }

    public void StopCountdown()
    {
        StopAllCoroutines();
    }

    protected virtual void Activate(Player target)
    {
        AffectSanity(target);

        isArmed = false;
        timeToRearm = rearmTime;
    }

    protected virtual void AffectSanity(Player target)
    {
    }
}

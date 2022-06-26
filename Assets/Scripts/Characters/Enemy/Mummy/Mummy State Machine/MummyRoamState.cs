using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class MummyRoamState : MummyState
{
    private float timeToNextSenseTick;
    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        Debug.LogWarning("Mummy entered Roam state");

        mummy.MovementController.SetSpeed(mummy.Stats.MoveSpeed);
        Roam(mummy, GetRoamPosition(mummy));

        timeToNextSenseTick = mummy.Stats.SenseTickTime;
    }

    public override void ExitState(Mummy mummy)
    {
        mummy.MovementController.CancelMoveTask();
    }

    public override void StateTick(Mummy mummy)
    {
        if (timeToNextSenseTick <= 0f)
        {
            PlayerController player = SensePlayer(mummy);
            if (player != null)
            {
                Debug.Log("Player seeked");
                mummy.SetState(mummy.chaseState, new MummyExitStateArgs(player, player.transform.position, mummy.roamState));
                return;
            }
            timeToNextSenseTick = mummy.Stats.SenseTickTime;
        }
        else
        {
            timeToNextSenseTick -= Time.deltaTime;
        }
    }

    public Vector3 GetRoamPosition(Mummy mummy) 
    {
        int rand = Random.Range(0, GameController.Instance.AlivePlayersList.Count);
        Vector3 target = GameController.Instance.AlivePlayersList[rand].transform.position;
        if (target == null)
            target = mummy.transform.position;

        Vector3 pos = GetRandomPosition(target, mummy.Stats.RoamRadius);

        while (!Map.Instance.IsPointWalkable(pos))
        {
            pos = GetRandomPosition(target, mummy.Stats.RoamRadius);
        }

        return pos;
    }

    private Vector3 GetRandomPosition(Vector3 target, float range)
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        return target + randomDirection * range;
    }

    private PlayerController SensePlayer(Mummy mummy)
    {
        PlayerController player = null;

        Collider2D col = Physics2D.OverlapCircle(mummy.transform.position, mummy.Stats.LoSRadius, mummy.Stats.SenseLayer);
        if (col != null)
        {
            player = col.GetComponent<PlayerController>();
        }

        return player;
    }

    private async void Roam(Mummy mummy, Vector3 roamPos)
    {
        await mummy.MovementController.Move(roamPos);

        Roam(mummy, GetRandomPosition(GetRoamPosition(mummy), mummy.Stats.BreakLoSRoamRadius));
    }

    public override void OnTakeDamage(Mummy mummy)
    {
        mummy.SetState(mummy.stunnedState, new MummyExitStateArgs(null, Vector3.zero, mummy.roamState));
    }
}

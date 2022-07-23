using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDrivenCharacter player = collision.GetComponent<PlayerDrivenCharacter>();
        if (player != null)
        {
            //player.SetState(player.coveredState);
            GameController.Instance.Win();
        }
    }
}

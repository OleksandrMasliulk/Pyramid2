using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    //[SerializeField] private AnimatorOverrideController aliveController;
    [SerializeField] private AnimatorOverrideController ghostController;

    //[SerializeField] private SanityPostFX sanityPostFX;

    [SerializeField] private Transform flashlight;

    public void SetMovementDirection(Vector2 direction)
    {
        if (direction.x < 0f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }

    public void SetDie()
    {
        animator.SetTrigger("Die");
    }

    public void DisableRenderer()
    {
        sprite.enabled = false;
    }

    public void EnableRenderer()
    {
        sprite.enabled = true;
    }

    public void SetGhostGraphics()
    {
        animator.runtimeAnimatorController = ghostController;
        animator.SetTrigger("Ghost");
    }

    public void SwitchFlashlight(bool value)
    {
        flashlight.gameObject.SetActive(value);
    }

    //public void SetSanityFX(int sanityLevel)
    //{
    //    switch (sanityLevel)
    //    {
    //        case 100:
    //            sanityPostFX.SetSanity100Profile();
    //            break;
    //        case > 75 and < 100:
    //            sanityPostFX.SetSanity75Profile();
    //            break;
    //        case > 50 and <= 75:
    //            sanityPostFX.SetSanity100Profile();
    //            break;
    //        case > 25 and <= 50:
    //            sanityPostFX.SetSanity100Profile();
    //            break;
    //        case > 0 and <= 25:
    //            sanityPostFX.SetSanity100Profile();
    //            break;
    //        case 0:
    //            sanityPostFX.SetSanity100Profile();
    //            break;
    //    }
    //}
}

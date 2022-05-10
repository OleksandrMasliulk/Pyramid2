using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private RuntimeAnimatorController aliveController;
    [SerializeField] private AnimatorOverrideController ghostController;

    //[SerializeField] private SanityPostFX sanityPostFX;

    [SerializeField] private Transform flashlight;

    [SerializeField] private Sprite corpseSprite;

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

        SetFlashlightDirection(direction);
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
        GameObject corpse = Instantiate(new GameObject(), transform.position, Quaternion.identity);
        SpriteRenderer sr = corpse.AddComponent<SpriteRenderer>();
        corpse.transform.localScale *= 2;
        sr.sprite = corpseSprite;
        sr.sortingLayerName = "Characters";

        animator.runtimeAnimatorController = ghostController;
        animator.SetTrigger("Ghost");
    }

    public void SetAliveGraphics()
    {
        animator.runtimeAnimatorController = aliveController;
        animator.SetTrigger("Ghost");
    }

    public void SwitchFlashlight(bool value)
    {
        flashlight.gameObject.SetActive(value);
    }

    public void SetFlashlightDirection(Vector3 dir)
    {
        float m = 90;
        if (dir.x == 0 && dir.y == 0)
        {
            m = 180;
        }

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        flashlight.rotation = Quaternion.Euler(0f, 0f, rot_z - m);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : CharacterAnimationHandler
{
    [SerializeField] private RuntimeAnimatorController aliveController;
    [SerializeField] private AnimatorOverrideController ghostController;

    public override void SetMovementDirection(Vector2 direction)
    {
        base.SetMovementDirection(direction);
    }

    public void DisableRenderer()
    {
        _renderer.enabled = false;
    }

    public void EnableRenderer()
    {
        _renderer.enabled = true;
    }

    public void SetGhostAnimationHandler()
    {
        _animator.runtimeAnimatorController = ghostController;
        _animator.Rebind();
    }

    public void SetAliveAniationHandler()
    {
        _animator.runtimeAnimatorController = aliveController;
        _animator.Rebind();
    }

    

    //public void SetSanityFX(int sanityLevel)
    //{
    //    switch (sanityLevel)
    //    {
    //        case 100:
    //            {
    //                sanityPostFX.SetSanity100Volume();
    //                HideTentacles();
    //                break;
    //            }
    //        case > 75 and < 100:
    //            {
    //                sanityPostFX.SetSanity75Volume();
    //                HideTentacles();
    //                break;
    //            }
    //        case > 50 and <= 75:
    //            {
    //                sanityPostFX.SetSanity50Volume();
    //                HideTentacles();
    //                break;
    //            }
    //        case > 25 and <= 50:
    //            {
    //                sanityPostFX.SetSanity25Volume();
    //                HideTentacles();
    //                break;
    //            }
    //        case > 0 and <= 25:
    //            {
    //                sanityPostFX.SetSanity0Volume();
    //                ShowTentacles();
    //                break;
    //            }
    //    }
    //}

    //private void ShowTentacles()
    //{
    //    if (!tentaclesEnabled)
    //    {
    //        tentaclesAnim.Play("ShowTentacles");
    //        tentaclesEnabled = true;
    //    }
    //}

    //private void HideTentacles()
    //{
    //    if (tentaclesEnabled)
    //    {
    //        tentaclesAnim.Play("HideTentacles");
    //        tentaclesEnabled = false;
    //    }
    //}
}

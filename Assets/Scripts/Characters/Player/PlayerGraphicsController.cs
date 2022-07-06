using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsController : CharacterGraphicsController
{
    [SerializeField] private ParticleSystem stepsPS;
    [SerializeField] private ParticleSystem ghostPS;

    [SerializeField] private RuntimeAnimatorController aliveController;
    [SerializeField] private AnimatorOverrideController ghostController;

    [SerializeField] private SanityFX sanityPostFX;
    private bool tentaclesEnabled = false;
    [SerializeField] private Animation tentaclesAnim; 

    [SerializeField] private Sprite corpseSprite;

    [Header("Sockets")]
    [SerializeField] private Transform _flashlightSocket;
    public Transform FlashlightSocket => _flashlightSocket;

    public override void SetMovementDirection(Vector2 direction)
    {
        base.SetMovementDirection(direction);

        SetFlashlightDirection(direction);
    }

    public void SetMoving()
    {
        _animator.SetTrigger("Moving");
    }

    public void SetDie()
    {
        _animator.SetTrigger("Die");
    }

    public void SetIdle()
    {
        _animator.SetTrigger("Idle");
    }

    public void DisableRenderer()
    {
        _renderer.enabled = false;
    }

    public void EnableRenderer()
    {
        _renderer.enabled = true;
    }

    public void SetGhostGraphics()
    {
        ghostPS.Play();
        stepsPS.Stop();

        GameObject corpse = Instantiate(new GameObject(), transform.position, Quaternion.identity);
        SpriteRenderer sr = corpse.AddComponent<SpriteRenderer>();
        corpse.transform.localScale *= 2;
        sr.sprite = corpseSprite;
        sr.sortingLayerName = "Characters";

        _animator.runtimeAnimatorController = ghostController;
        //_animator.SetTrigger("Ghost");
        _animator.Rebind();
    }

    public void SetAliveGraphics()
    {
        ghostPS.Stop();
        stepsPS.Play();
        _animator.runtimeAnimatorController = aliveController;
        _animator.Rebind();
    }

    public void SetFlashlightDirection(Vector3 dir)
    {
        float m = 90;
        if (dir.x == 0 && dir.y == 0)
        {
            m = 180;
        }

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _flashlightSocket.rotation = Quaternion.Euler(0f, 0f, rot_z - m);
    }

    public void SetSanityFX(int sanityLevel)
    {
        switch (sanityLevel)
        {
            case 100:
                {
                    sanityPostFX.SetSanity100Volume();
                    HideTentacles();
                    break;
                }
            case > 75 and < 100:
                {
                    sanityPostFX.SetSanity75Volume();
                    HideTentacles();
                    break;
                }
            case > 50 and <= 75:
                {
                    sanityPostFX.SetSanity50Volume();
                    HideTentacles();
                    break;
                }
            case > 25 and <= 50:
                {
                    sanityPostFX.SetSanity25Volume();
                    HideTentacles();
                    break;
                }
            case > 0 and <= 25:
                {
                    sanityPostFX.SetSanity0Volume();
                    ShowTentacles();
                    break;
                }
        }
    }

    private void ShowTentacles()
    {
        if (!tentaclesEnabled)
        {
            tentaclesAnim.Play("ShowTentacles");
            tentaclesEnabled = true;
        }
    }

    private void HideTentacles()
    {
        if (tentaclesEnabled)
        {
            tentaclesAnim.Play("HideTentacles");
            tentaclesEnabled = false;
        }
    }
}

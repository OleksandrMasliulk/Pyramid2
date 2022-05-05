using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sr;
    [SerializeField]private Sprite[] sprites;

    private void Awake()
    {
        int rand = Random.Range(0, sprites.Length);
        sr.sprite = sprites[rand];
    }
}

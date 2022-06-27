using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class ItemAssets : MonoBehaviour
{
    //public static ItemAssets Instance { get; private set; }

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    //[Header("Prefabs")]
    //public Transform pbFlashlight;
    //public Transform pbMedkit;
    //public Transform pbPaint;
    //public Transform pbFlare;
    //public Transform[] pbTreasure5;
    //public Transform[] pbTreasure10;
    
    //[Header("Sprites")]
    //public Sprite spriteFlashlight;
    //public Sprite spriteMedkit;
    //public Sprite spritePaint;
    //public Sprite spriteFlare;
    //public Sprite[] spriteTreasure5;
    //public Sprite[] spriteTreasure10;

    //public void GetItem(ItemType item, out Transform pb, out Sprite sprite)
    //{
    //    switch (item)
    //    {
    //        case ItemType.Flare:
    //            pb = pbFlare;
    //            sprite = spriteFlare;
    //            break;
    //        case ItemType.Flashlight:
    //            pb = pbFlashlight;
    //            sprite = spriteFlashlight;
    //            break;
    //        case ItemType.Medkit:
    //            pb = pbMedkit;
    //            sprite = spriteMedkit;
    //            break;
    //        case ItemType.Paint:
    //            pb = pbPaint;
    //            sprite = spritePaint;
    //            break;
    //        case ItemType.Treasure5:
    //            {
    //                int rnd = Random.Range(0, pbTreasure5.Length);
    //                pb = pbTreasure5[rnd];
    //                sprite = spriteTreasure5[rnd];
    //                break;
    //            }
    //        case ItemType.Treasure10:
    //            {
    //                int rnd = Random.Range(0, pbTreasure10.Length);
    //                pb = pbTreasure10[rnd];
    //                sprite = spriteTreasure10[rnd];
    //                break;
    //            }
    //        default:
    //            pb = null;
    //            sprite = null;
    //            break;
    //    }
    //}
}

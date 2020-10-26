﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    Item item;
    public bool canTake = false;
    SpriteRenderer spriteRenderer;
    DialogueTrigger dialogueTrigger;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        dialogueTrigger.dialoguePath = item.GetDialoguePath();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

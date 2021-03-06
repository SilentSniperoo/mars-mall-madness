﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DepthScaler))]
public class PickupController : MonoBehaviour
{
    GameObject highlight;
    DialogueController dialogueController;

    public string titleText = "Item Name";
    public string bodyText = "Item description and more.";

    public Sprite owner;

    private void Awake()
    {
        gameObject.tag = "Item";
    }

    // Start is called before the first frame update
    void Start()
    {
        highlight = transform.Find("Highlight").gameObject;
        dialogueController = FindObjectOfType<DialogueController>();
        Untargeted();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Targeted()
    {
        if (highlight)
        {
            highlight.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (dialogueController)
        {
            dialogueController.targetPickup(this);
        }
    }

    void Untargeted()
    {
        if (highlight)
        {
            highlight.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (dialogueController)
        {
            dialogueController.untargetPickup(this);
        }
    }

    void Interact()
    {
        if (dialogueController)
        {
            dialogueController.examinePickup();
        }
    }

    public Transform getSpriteTransform()
    {
        Transform spriteTransform = transform.Find("Sprite");
        if (!spriteTransform)
        {
            Debug.LogWarning("No child object named 'Sprite' on '" + gameObject.name + "'", gameObject);
            return null;
        }

        return spriteTransform;
    }

    public SpriteRenderer getSpriteRenderer(Transform spriteTransform)
    {
        if (!spriteTransform) return null;

        SpriteRenderer renderer = spriteTransform.GetComponent<SpriteRenderer>();
        if (!renderer)
        {
            Debug.LogWarning("No 'SpriteRenderer' component on '" + spriteTransform.gameObject.name + "'", spriteTransform.gameObject);
            return null;
        }

        return renderer;
    }

    public Sprite getSprite(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer ? spriteRenderer.sprite : null;
    }
}

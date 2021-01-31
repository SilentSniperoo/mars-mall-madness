﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DepthScaler))]
public class PickupController : MonoBehaviour
{
    GameObject highlight;
    DialogueController dialogueController;

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
}
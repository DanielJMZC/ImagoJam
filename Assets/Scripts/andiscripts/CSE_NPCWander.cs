using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class CSE_NPCWander : CutsceneElementBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform targetX;

    private bool isTriggered = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Execute()
    {
        isTriggered = true;
    }
    
    public override void Update()
    {
        base.Update();

        if (!isTriggered || targetX == null || rb == null) return;

        if (rb.transform.position.x > targetX.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            isTriggered = false;

            if (cutsceneHandler != null)
            {
                cutsceneHandler.PlayNextElement();
            }
        }
    }
}

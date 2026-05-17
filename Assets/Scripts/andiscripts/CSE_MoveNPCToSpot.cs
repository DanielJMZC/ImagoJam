using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class CSE_MoveNPCToSpot : CutsceneElementBase
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform targetPosition;

    public override void Start()
    {
        base.Start();
    }

    public override void Execute()
    {
        if (targetPosition == null || rb == null) 
        {
            if (cutsceneHandler != null) cutsceneHandler.PlayNextElement();
            return;
        }

        rb.transform.position = targetPosition.position;
        if (cutsceneHandler != null)
        {
            cutsceneHandler.PlayNextElement();
        }
    }
}

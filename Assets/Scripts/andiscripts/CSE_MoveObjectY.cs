using UnityEngine;

public class CSE_MoveObjectY : CutsceneElementBase
{
    [SerializeField] private Transform objectToMove;
    [SerializeField] private Transform topTarget;
    [SerializeField] private Transform bottomTarget;
    [SerializeField] private float speed = 2f;

    private bool isMoving = false;
    private bool movingToTop = true;

    public override void Execute()
    {
        if (objectToMove != null && topTarget != null && bottomTarget != null)
        {
            isMoving = true;
        }

        if (cutsceneHandler != null)
        {
            cutsceneHandler.PlayNextElement();
        }
    }

    public override void Update()
    {
        base.Update();
        if (!isMoving || objectToMove == null) return;

        Transform currentTarget = movingToTop ? topTarget : bottomTarget;
        
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(objectToMove.position, currentTarget.position) < 0.01f)
        {
            movingToTop = !movingToTop; 
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}

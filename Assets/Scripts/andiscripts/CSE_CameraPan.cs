using System.Collections;
using UnityEngine;

public class CSE_CameraPan : CutsceneElementBase
{
    private Camera cam;
    [SerializeField] private Vector2 distanceToMove;
    public override void Execute()
    {
        cam = cutsceneHandler.cam;
        StartCoroutine(PanCoroutine());
    }
    private IEnumerator PanCoroutine()
    {
        // SMOTH LARPINGG
        Vector3 originalPosition = cam.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(distanceToMove.x, distanceToMove.y, 0);

        float startTime = Time.time;
        float elapsedTime = 0;

        //lop camera moove 
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cam.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        cam.transform.position = targetPosition;

        cutsceneHandler.PlayNextElement();
    }

    private void ODestroy()
    {
        StopAllCoroutines();
    }
}


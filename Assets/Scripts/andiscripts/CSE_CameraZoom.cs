using System.Collections;
using UnityEngine;

public class CSE_CameraZoom : CutsceneElementBase
{
    [SerializeField] private float targetSize;
    [SerializeField] Transform target;
    [SerializeField] private Vector3 offset;
    private Camera cam;
    public override void Execute()
    {
        cam = cutsceneHandler.cam;
        StartCoroutine(ZoomCamera());

    }

    private IEnumerator ZoomCamera()
    {
        Vector3 originalPosition = cam.transform.position;
        Vector3 targetPosition = target.position + offset;

        float OriginalSize = cam.orthographicSize;
        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < duration )
        {
            float t = elapsedTime/duration;
            cam.orthographicSize = Mathf.Lerp(OriginalSize, targetSize, t);
            cam.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);

            elapsedTime = Time.time - startTime;
            yield return null;
        }
        
        cam.orthographicSize = targetSize;
        cam.transform.position = target.position;

        cutsceneHandler.PlayNextElement();
    }
    private void ODestroy()
    {
        StopAllCoroutines();
    }
}

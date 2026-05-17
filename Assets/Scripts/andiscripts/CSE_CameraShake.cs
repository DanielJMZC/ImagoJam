using UnityEngine;

public class CSE_CameraShake : CutsceneElementBase
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float shakeIntensity = 0.5f;
    [SerializeField] private float shakeSpeed = 20f;
    [SerializeField] private CSE_MoveObjectY scriptToStop;

    private bool isShaking = false;
    private Vector3 originalCameraPosition;

    public override void Execute()
    {
        if (scriptToStop != null)
        {
            scriptToStop.StopMoving();
        }

        if (cameraTransform != null)
        {
            originalCameraPosition = cameraTransform.localPosition;
            isShaking = true;
        }

        if (cutsceneHandler != null)
        {
            cutsceneHandler.PlayNextElement();
        }
    }

    public override void Update()
    {
        base.Update();
        if (!isShaking || cameraTransform == null) return;

        float offsetX = (Mathf.PerlinNoise(Time.time * shakeSpeed, 0f) - 0.5f) * 2f * shakeIntensity;
        float offsetY = (Mathf.PerlinNoise(0f, Time.time * shakeSpeed) - 0.5f) * 2f * shakeIntensity;
        
        cameraTransform.localPosition = new Vector3(
            originalCameraPosition.x + offsetX,
            originalCameraPosition.y + offsetY,
            originalCameraPosition.z
        );
    }
}

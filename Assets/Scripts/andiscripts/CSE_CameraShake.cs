using UnityEngine;

public class CSE_CameraShake : CutsceneElementBase
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float shakeIntensity = 0.5f;
    [SerializeField] private float shakeSpeed = 20f;
    [SerializeField] private CSE_MoveObjectY scriptToStop;
    [SerializeField] private GameObject flashPanel;
    [SerializeField] private float flashInterval = 0.5f;
    private bool isShaking = false;
    private Vector3 originalCameraPosition;
    private float flashTimer;
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

        if (flashPanel != null)
        {
            flashPanel.SetActive(true);
            flashTimer = flashInterval;
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

        if (flashPanel != null)
        {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0f)
            {
                flashPanel.SetActive(!flashPanel.activeSelf);
                flashTimer = flashInterval;
            }
        }
    }
}

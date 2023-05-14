using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [HideInInspector] public CinemachineVirtualCamera _virtualCamera;
    private Timers tim;
    public AnimationCurve curve;
    public static CameraShake Instance { get; private set;}
    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        Instance = this;
        tim = new Timers(1);
    }

    private void OnEnable()
    {
        PlaneCollision.OnGameOver += DefeatedCinematic;
    }

    private void OnDisable()
    {
        PlaneCollision.OnGameOver -= DefeatedCinematic;
    }

    public IEnumerator shakeCamera(float intensity, float duration)
    {
        Debug.Log(duration);
        float timer = 0;
        float completeness = 0f;
        if (_virtualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>())
        {
            CinemachineBasicMultiChannelPerlin cinemachinePerlin = _virtualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>(); 
            while (completeness<1f)
            {
                timer += Time.deltaTime;
                completeness = timer / duration;
                cinemachinePerlin.m_AmplitudeGain = curve.Evaluate(completeness) * intensity;
                yield return null;
            }
        }
    }

    private void DefeatedCinematic()
    {
        StartCoroutine(shakeCamera(3f, 0.5f));
    }
}

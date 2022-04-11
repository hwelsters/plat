using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public static CameraController instance = null;

    private const float SCREEN_SHAKE_DURATION = 0.25f;
    private const float SCREEN_SHAKE_STRENGTH = 0.1f;
    private const float SCREEN_SHAKE_FREQUENCY = 20f;

    private static readonly float INVERSE_SCREEN_SHAKE;

    static CameraController()
    {
        INVERSE_SCREEN_SHAKE = 1 / SCREEN_SHAKE_DURATION * SCREEN_SHAKE_FREQUENCY * Mathf.PI;
    }

    private void Start()
    {
        instance = this;
    }

    public static void ScreenShake ()
    {
        instance.StartCoroutine(instance.ScreenShakeCoroutine());
    }

    public IEnumerator ScreenShakeCoroutine()
    {
        float time = 0f;
        Vector3 originalPosition = instance.transform.position;
        while (time < SCREEN_SHAKE_DURATION)
        {
            float newRadian = (time * INVERSE_SCREEN_SHAKE);
            float displacement = Mathf.Sin(newRadian) * SCREEN_SHAKE_STRENGTH;
            Vector3 newPosition = new Vector3(originalPosition.x + displacement, originalPosition.y, -10);

            instance.transform.position = (Vector3) newPosition;

            time += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
    }
}

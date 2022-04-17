using UnityEngine;

public class DestroySelfTimed : MonoBehaviour
{
    [SerializeField] private float secondsToSelfDestruct;

    private void Start() {
        Invoke("DestroySelf", secondsToSelfDestruct);
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }
}

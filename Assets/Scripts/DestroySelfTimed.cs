using UnityEngine;

public class DestroySelfTimed : MonoBehaviour
{
    [SerializeField] private float secondsToSelfDestruct;

    protected virtual void Start() {
        Invoke("DestroySelf", secondsToSelfDestruct);
    }

    protected virtual void DestroySelf() {
        Destroy(gameObject);
    }
}

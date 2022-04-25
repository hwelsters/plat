using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static Vector2 nextScenePosition;

    [SerializeField] private Vector2 currNextScenePosition;
    [SerializeField] private string nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) ChangeScenes();
    }

    private void ChangeScenes()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}

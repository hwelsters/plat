using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static Vector2 nextScenePosition;

    [SerializeField] private Vector2 currNextScenePosition;
    [SerializeField] private string nextScene;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = nextScenePosition;
    }

    private void ChangeScenes()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}

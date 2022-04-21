using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //VERY VERY SUS CODE
    //PLEASE CORRECT THIS WHEN YOU'RE SMARTER NOEL
    [SerializeField] private Vector3 offset;

    private Camera mainCamera;
    private RectTransform rectTransform;
    private Animator animator;

    private GameObject player;

    private void Start()
    {
        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        mainCamera = mainCameraObject.GetComponent<Camera>();

        rectTransform = GetComponent<RectTransform>();

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector3 playerScreenPosition = mainCamera.WorldToScreenPoint(player.transform.position);
        rectTransform.position = playerScreenPosition + offset;
    }

    public void Leave()
    {
        animator.SetBool("Leaving", true);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private const float JUMP_SPEED = 13f;
    private const float JUMP_HOLD_TIME = 0.25f;
    private const float SQUASH_AMOUNT = 0.1f;
    
    private Animator animator;
    private Rigidbody2D rb2d;
    private PlayerState currentState;

    [SerializeField] private GameObject playerJumpFX;
    [SerializeField] private GameObject playerMoveFX;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rb2d = GetComponent<Rigidbody2D>();
        
        this.currentState = new PlayerMoveState();
    }

    private void Update()
    {
        currentState = currentState.HandleInput(this);
        currentState.HandleAnimation(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap")) this.currentState = new PlayerDeathState();
    }

    public void Jump(Rigidbody2D rb2d)
    {
        // REFACTOR
        Instantiate(playerJumpFX, transform.position, Quaternion.identity);
        StartCoroutine(JumpCoroutine(rb2d));
    }

    public void Squash(SquashDirection squashDirection)
    {
        StartCoroutine(SquashCoroutine(squashDirection));
    }

    public void CreateDust()
    {
        Instantiate(playerMoveFX, transform.position, Quaternion.identity);
    }

    public Rigidbody2D GetRigidbody2D ()
    {
        return this.rb2d;
    } 

    public Animator GetAnimator()
    {
        return this.animator;
    }

    private IEnumerator JumpCoroutine(Rigidbody2D rb2d)
    {
        Squash(SquashDirection.VERTICAL);
        
        float jumpHoldCounter = JUMP_HOLD_TIME;

        while ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.C)) && jumpHoldCounter >= 0)
        {
            this.rb2d.velocity = new Vector2(rb2d.velocity.x, JUMP_SPEED);
            jumpHoldCounter -= Time.deltaTime;
            yield return null;
        }
    }
    
    private IEnumerator SquashCoroutine(SquashDirection squashDirection)
    {
        float currentRadian = 0;

        while (currentRadian < Mathf.PI)
        {
            float change = Mathf.Sin(currentRadian) * SQUASH_AMOUNT * (float) squashDirection;
            currentRadian += Time.deltaTime * 20;
            transform.localScale = new Vector2(1 + change, 1 - change);
            yield return null;
        }
    }

}

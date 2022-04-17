using UnityEngine;
using System.Collections;

public class PlayerMoveState : PlayerState
{
    private const float MOVEMENT_SPEED      = 9f;
    private const float FALL_MULTIPLIER     = 3f;
    private const float COLLISION_RADIUS    = 0.1f;
    private const float JUMP_BUFFER_TIME    = 0.2f;
    private const float COYOTE_TIME         = 0.2f;
    private const float DUST_CREATION_SPEED = -30;

    private float bufferTimeCounter = 0f;
    private float coyoteTimeCounter = 0f;

    private float xVelocity = 0;

    private bool wasGrounded = false;
    private bool isGrounded = false;
    
    private LayerMask groundLayer;

    public PlayerMoveState()
    {
        this.groundLayer = LayerMask.GetMask("GroundLayer");
    }

    public override PlayerState HandleInput(PlayerMovement player)
    {
        if (Input.GetKey(KeyCode.Q)) return new PlayerDeathState();
        
        Rigidbody2D rb2d = player.GetRigidbody2D();

        this.wasGrounded = isGrounded;
        this.isGrounded =
            Physics2D
                .OverlapCircle((Vector2) rb2d.position,
                COLLISION_RADIUS,
                groundLayer) !=
            null;
        
        if (this.isGrounded) coyoteTimeCounter = COYOTE_TIME;
        else coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.C)) { bufferTimeCounter = JUMP_BUFFER_TIME; }
        else bufferTimeCounter -= Time.deltaTime;

        if (coyoteTimeCounter >= 0 && bufferTimeCounter >= 0) 
        {
            player.Jump(rb2d);
            ResetCounters();
        }
        if (rb2d.velocity.y < 0) rb2d.velocity += Vector2.up * Physics2D.gravity.y * ( FALL_MULTIPLIER - 1 ) * Time.deltaTime;

        this.xVelocity = Input.GetAxisRaw("Horizontal") * MOVEMENT_SPEED;

        rb2d.velocity = new Vector2(this.xVelocity, rb2d.velocity.y);
        
        if (isGrounded && !wasGrounded) 
        {
            player.Squash(SquashDirection.HORIZONTAL);

            if (rb2d.velocity.y < DUST_CREATION_SPEED)
            {
                player.CreateDust();
            }
        }

        return this;
    }

    public override void HandleAnimation(PlayerMovement player)
    {
        Animator animator = player.GetAnimator();

        if (Mathf.Abs(xVelocity) > float.Epsilon)
        {
            animator.SetBool("moving", true);
            animator.SetFloat("xDirection", xVelocity * 100);
        }
        else
        {
            animator.SetBool("moving", false);
        }

    }
    
    private void ResetCounters() 
    {
        bufferTimeCounter = -1;
        coyoteTimeCounter = -1;
    }

}

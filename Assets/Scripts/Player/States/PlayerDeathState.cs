using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState()
    {
        CameraController.ScreenShake();
    }

    public override PlayerState HandleInput(PlayerMovement player)
    {
        Rigidbody2D rb2d = player.GetRigidbody2D();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector2.zero;

        return this;
    }

    public override void HandleAnimation(PlayerMovement player)
    {
        Animator animator = player.GetAnimator();
        
        animator.SetBool("dying", true);
    }
}

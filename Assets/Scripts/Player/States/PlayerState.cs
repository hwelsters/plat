using UnityEngine;

public abstract class PlayerState 
{
    public abstract PlayerState HandleInput(PlayerMovement player);
    public abstract void HandleAnimation(PlayerMovement player);
}
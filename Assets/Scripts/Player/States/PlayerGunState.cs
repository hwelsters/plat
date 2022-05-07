using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunState : PlayerMoveState
{

    public override PlayerState HandleInput(PlayerMovement player) 
    {
        if (Input.GetKeyDown(KeyCode.X)) {player.ShootBullet(base.direction);}
        base.HandleInput(player);
        return this;
    }

}

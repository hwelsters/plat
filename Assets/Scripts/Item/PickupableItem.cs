using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Pickupable
{
    protected override void HandleAction(Collider2D other) {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        player?.Flash();
    }
}

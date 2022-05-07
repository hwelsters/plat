using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : PickupableItem
{
    protected override void HandleAction(Collider2D other)
    {
        ItemManager.SetHasGun();
        base.HandleAction(other);
    }
}

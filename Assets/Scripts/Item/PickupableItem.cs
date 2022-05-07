using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Pickupable
{
    [SerializeField] private int itemId;
    private void Start()
    {
        if (ItemManager.GetWasPickedUp(this.itemId)) Destroy(gameObject);
    }

    protected override void HandleAction(Collider2D other) 
    {
        ItemManager.SetWasPickedUp(this.itemId);
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        player?.Flash();
    }
}

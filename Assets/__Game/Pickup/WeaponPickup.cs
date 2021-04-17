using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public override void OnPickup(Player player)
    {
        player.GetComponent<PlayerShoot>().Upgrade();
    }
}

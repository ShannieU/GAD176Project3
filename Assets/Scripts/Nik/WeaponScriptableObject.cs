using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/New Weapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        [Tooltip("Unique Weapon ID")]
            public int iD;
        [Tooltip("Name of the weapon.")]
            public string weaponName;
        [Tooltip("Damage the weapon will deal if an enemy is hit.")]
            public float weaponDamage;
        [Tooltip("Time (in seconds) between shots being fired from the weapon.")]
            public float weaponFireDelay;
        [Tooltip("The total maximum ammount of ammo the player can hold, including the ammo in the current magazine.")]
            public int maxAmmoInInventory;
        [Tooltip("The current ammount of ammo in the weapon's magazine")]
            public int currentAmmoInInventory;
        [Tooltip("The maximum ammount of ammo the weapon can hold in the magazine.")]
            public int maxMagazineAmmo;
        [Tooltip("The current ammount of ammo in the weapon's magazine.")]
            public int currentMagazineAmmo;
    }
}

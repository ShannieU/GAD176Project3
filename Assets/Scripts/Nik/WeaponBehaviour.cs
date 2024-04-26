using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

namespace Player {
    public class WeaponBehaviour : MonoBehaviour
    {
        private WeaponScriptableObject currentWeapon;
        private PlayerBehaviour currentPlayer;

        private void Start()
        {
            currentPlayer = GetComponent<PlayerBehaviour>();
        }
        public void SetWeapon(WeaponScriptableObject weapon)
        {
            currentWeapon = weapon;
        }
        public void ShootWeapon()
        //Fires the current weapon.
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.DrawRay(Camera.main.transform.position, hit.point, Color.red);
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    GameObject enemy = hit.collider.gameObject;
                    //enemy.EnemyTakeDamage(weapon.weaponDamage);
                    currentWeapon.currentAmmoInInventory -= 1;
                    Debug.Log("Hit");
                }
                else if (hit.collider.gameObject)
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
                else
                {
                    currentWeapon.currentAmmoInInventory -= 1;
                    Debug.Log("Miss");
                }
            }
            //Raycast to mouse position on screen
            //Get collider for enemy pointed at
            //Enemy take damage
        }
        public void ReloadWeapon()
        {
            foreach (WeaponScriptableObject weapon in currentPlayer.GetWeaponInventory())
            {
                if (weapon.currentAmmoInInventory != 0)
                {
                    int n = weapon.maxMagazineAmmo - weapon.currentMagazineAmmo;        //n is the number of bullets needed
                                                                                        //  to reload the gun to max mag cap
                    if (n <= weapon.currentAmmoInInventory)
                    {
                        weapon.currentAmmoInInventory -= n;                            //Subtracts n from the total ammo in inventory.
                        weapon.currentMagazineAmmo = weapon.maxMagazineAmmo;           //Resets the magazine count
                    }
                    else if (n > weapon.currentAmmoInInventory)
                    {
                        n = weapon.currentAmmoInInventory;                             //sets n to be the ammo left in the inventory.
                        weapon.currentAmmoInInventory -= n;                            //subtracts n from current ammo (this will always be 0,
                                                                                       //  but i had to write this out like this bc i didnt take
                                                                                       //  my pills today)
                        weapon.currentMagazineAmmo += n;                               //adds the remaining ammo to the magazine.
                    }
                }
                else 
                { 
                    continue;
                }
            }
        }
    }
}

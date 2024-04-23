using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject weapon;
    Vector3 mousePos;

    
    public void SelectWeapon(WeaponScriptableObject playerWeapon)
    {
        weapon = playerWeapon;
    }

    public void ShootWeapon()
        //Fires the current weapon.
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Input.mousePosition, out hit, 1000f))
        {
            Debug.DrawRay(Camera.main.transform.position, Input.mousePosition, Color.red);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                GameObject enemy = hit.collider.gameObject;
                //enemy.EnemyTakeDamage(weapon.weaponDamage);
                weapon.currentAmmoInInventory -= 1;
                Debug.Log("Hit");
            }
            else if (hit.collider.gameObject)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                weapon.currentAmmoInInventory -= 1;
                Debug.Log("Miss");
            }
        }
        //Raycast to mouse position on screen
        //Get collider for enemy pointed at
        //Enemy take damage
    }
    public void ReloadWeapon()
    {
        if (weapon.currentMagazineAmmo != 0)
        {
            //Reload weapon.
            //Magazine ammo needs to find out how much it needs. So maxmagazine - currentmagazine
            //Subtract this from the total ammo pool.
            //If this rersults in the total ammo bool being less than 0, find the ammount that would result in 0, and substitute this in.
            int n = weapon.maxMagazineAmmo - weapon.currentMagazineAmmo;
            //n is how many bullets need to be put into the mag

            if (n <= weapon.currentAmmoInInventory)
            {
                weapon.currentAmmoInInventory -= n;                     //Subtracts n from the total ammo in inventory.
                weapon.currentMagazineAmmo = weapon.maxMagazineAmmo;    //Resets magazine count
            }
            else if (n > weapon.currentAmmoInInventory)
            {
                n = weapon.currentAmmoInInventory;                      //sets n to be the ammo left in the inventory.
                weapon.currentAmmoInInventory -= n;                     //subtracts n from current ammo (this will always be 0, but i had to write this out like this bc i didnt take my pills today)
                weapon.currentMagazineAmmo += n;                        //adds the remaining ammo to the magazine.
            }
        }
    }
}

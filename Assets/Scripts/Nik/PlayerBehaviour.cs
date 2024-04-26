using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// PlayerBehaviour contains all systems to facilitate user interaction with the game.
    /// </summary>
    public class PlayerBehaviour : MonoBehaviour
    {
        #region private variables
        [SerializeField] private PlayerScriptableObject currentPlayer;
        [SerializeField] private int currentHealth;

        private enum position { inCover, outCover }
        private position playerPosition = position.inCover;
        private bool shootDelay = false;
        private bool debug = false;
        private int weaponIndex = 0;

        public List<WeaponScriptableObject> weaponsInventory = new List<WeaponScriptableObject>();
        [SerializeField] private WeaponScriptableObject starterWeapon;
        [SerializeField] private WeaponScriptableObject currentWeapon;
        [SerializeField] private WeaponBehaviour playerWeapon;
        #endregion

        #region Unity Methods
        private void Start()
        {
            SetBeginStats(SanityChecks());
        }

        private void Update()
        {
            switch (playerPosition)
            {
                case position.inCover:
                    playerWeapon.ReloadWeapon();
                    CycleWeapon();
                    //Behaviour to allow when in cover:
                        //When moving into cover, reload currently equipped weapon.
                        //When shoot button is pressed in cover, switch weapons.
                            //On weapon switch, reload current weapon.
                        //When in cover, player cannot take damage. Send event to enemies so they cannot damage player?
                break;

                case position.outCover:
                    StartCoroutine(Shoot());
                break;
            }
            CoverInAndOut();
            PlayerDeathCheck();
            DebugStats();
        }
        #endregion

        #region Start
        private bool SanityChecks()
            //Null checks go in here. If any of them return null, the game will not set default stats.
            //This creates a general error that is easy to track.
        {
            if (playerWeapon == null)
            {
                playerWeapon = GetComponent<WeaponBehaviour>();

            }
            if (currentPlayer == null)
            {
                Debug.Log("No player stats file detected. Please add one and relaunch!");
                return false;
            }
            else if (starterWeapon == null)
            {
                Debug.Log("No default weapon added. Please add one and relaunch!");
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void SetBeginStats(bool sane)
            //Necessary default stats that begin at runtime go here. This will not run if all sanity checks do not clear.
        {
            if (sane)
            {
                currentHealth = currentPlayer.maxHealth;
                weaponsInventory.Add(starterWeapon);
                currentWeapon = weaponsInventory[weaponIndex];
                playerWeapon.SetWeapon(currentWeapon);
            }
        }
        #endregion
        private IEnumerator Shoot()
        //Contains the shoot behaviour. Pulls all necessary stats from the currentWeapon scriptableObject.
        {
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (shootDelay == false)
                {
                    Debug.Log("Shoot");
                    shootDelay = true;
                    playerWeapon.ShootWeapon();
                    yield return new WaitForSecondsRealtime(currentWeapon.weaponFireDelay);
                    shootDelay = false;
                }
            }
        }

        private void CycleWeapon()
            //If in cover, this will change the player's weapon to the next one in their inventory. Does this by iterating
            //  an int, which acts as an index for picking to weapon from the inventory. Contains an out of range check to
            //  reset index to 0.
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                weaponIndex++;
                if (weaponIndex > weaponsInventory.Count - 1)
                {
                    weaponIndex = 0;
                    currentWeapon = weaponsInventory[weaponIndex];
                    playerWeapon.SetWeapon(currentWeapon);
                }
                else
                {
                    currentWeapon = weaponsInventory[weaponIndex];
                    playerWeapon.SetWeapon(currentWeapon);
                }
            }
        }


        private void CoverInAndOut()
            //Temporary until we replace with an input handler. Hold space to not be in cover. Let go of space to be
            //  in cover.
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playerPosition = position.outCover;

                //Replace the Vector3.zeroes in here with the two transform positions from the movement script.
                if (transform.position != Vector3.up)
                {
                    transform.position = Vector3.MoveTowards(Vector3.zero, Vector3.up, 1 * Time.deltaTime);
                }
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                //Replace the Vector3.zeroes in here with the two transform positions from the movement script.
                playerPosition = position.inCover;
                if (transform.position != Vector3.zero)
                {
                    transform.position = Vector3.MoveTowards(Vector3.up, Vector3.zero, 1 * Time.deltaTime);
                }
            }
        }

        public void PlayerTakeDamage(int damage)
            //Public method for enemies to damage the player.
        {
            currentHealth -= damage;
        }

        private void PlayerDeathCheck()
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //Fire death event.
            }
        }
        public List<WeaponScriptableObject> GetWeaponInventory()
        {
            return weaponsInventory;
        }

        public void GetWeapon(WeaponScriptableObject newWeapon)
            //Public method for adding weapons to the player's inventory. Will check if the weapon ID matches the ID of
            //  a weapon already in the inventory, and will not add it if this is the case.
            //Correct function relies on each individual weapon having a unique ID, so this may not be the optimal solution.
        {
            foreach (var weapon in weaponsInventory)
            {
                if (weapon.iD == newWeapon.iD)
                {
                    return;
                }
                else
                {
                    weaponsInventory.Add(newWeapon);
                }
            }
        }
        /// <summary>
        /// Getter for all player information to be read by the UI.
        /// Item1 is the player's current TOTAL ammo for the current weapon.
        /// Item2 is the player's MAXIMUM ammo for the current weapon.
        /// Item3 is the CURRENT ammo in the player's weapon's magazine.
        /// Item4 is the MAXIMUM ammo in the player's weapon's magazine.
        /// Item5 is the current weapon's name.
        /// </summary>
        public Tuple <int, int, int, int, string> GetWeaponInfo()
        {
            return Tuple.Create(currentWeapon.currentAmmoInInventory, currentWeapon.maxAmmoInInventory, currentWeapon.currentMagazineAmmo, currentWeapon.maxMagazineAmmo, currentWeapon.weaponName);
        }
        /// <summary>
        /// Item1 is the player's current HP.
        /// Item2 is the player's maximum HP.
        /// </summary>
        /// <returns></returns>
        public Tuple <int, int> GetPlayerInfo()
        {
            return Tuple.Create(currentHealth, currentPlayer.maxHealth);
        }
        private void DebugStats()
        {
            if (Input.GetKeyDown(KeyCode.Y)) ;
            {
                Debug.Log(currentWeapon.weaponName);
                Debug.Log("TOTAL: " + currentWeapon.currentAmmoInInventory + "/" + currentWeapon.maxAmmoInInventory);
                Debug.Log("MAG: " + currentWeapon.currentMagazineAmmo + "/" + currentWeapon.maxMagazineAmmo);
            }
        }
    }
}

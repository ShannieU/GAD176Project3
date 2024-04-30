using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeesStuff
{
    public class BaseEnemy : MonoBehaviour
    {
        //the reference to other things
        [SerializeField] protected GameObject playerObj;
        [SerializeField] protected EnemyManager management;

        //the variables we need
        protected int health = 10, speed = 5, safeDistance = 2, attackDistance = 5, chanceToHit = 6;
        protected bool withinDestinationRange = false;

        protected virtual void Start()
        {
            //if theres no player object (there isnt)
            if (playerObj == null)
            {
                //grab it
                playerObj = GameObject.FindWithTag("Player");
            }
            //also grab the enemy manager
            management = FindAnyObjectByType<EnemyManager>();
            //Debug.Log("Am I tagged as Enemy?");
        }

        protected virtual void Update()
        {
            //i dont know if this needs to be here
            /*
            if(Input.GetKey(KeyCode.Tab))
            {
                EnemyTakeDamage(10);
            }
            */
        }

        protected virtual void EnemyMoves(Vector3 location)
        {
            //Debug.Log("movin");
            //get the locations
            Vector3 dirToLocation = (location - this.transform.position); //.normalized;

            //check if close to their end distance
            if (dirToLocation.magnitude > safeDistance)
            {
                //normalise the number 
                dirToLocation = dirToLocation.normalized;
                //move towards player
                this.transform.position += dirToLocation * speed * Time.deltaTime;

                withinDestinationRange = false;
            }
            else //so if theyer at or within their destinatikon range
            {
                withinDestinationRange = true;
            }
        }

        protected virtual void EnemyAttack()
        {
            RaycastHit hit;

            //send the raycast to see if we hit the player
            if (Physics.Raycast(this.transform.position, playerObj.transform.position, out hit, attackDistance))
            {
                int chance = Random.Range(0, 10);
                //Debug.Log(chance);
                Debug.DrawRay(this.transform.position, playerObj.transform.position, Color.red, attackDistance);

                //we want some inaccuracy so the player wont die straight away
                if (hit.collider.gameObject == playerObj && chance > chanceToHit)
                {
                    //Debug.Log("player ouchies");
                    //call whatever thing hurt the player
                }
            }
        }

        public void EnemyTakeDamage(int damage)
        {
            //Debug.Log("ow");
            //subtract the damage
            health -= damage;
            if (health <= 0)
            {
                EnemyDies();
            }
        }


        protected virtual void EnemyDies()
        {
            //bleh x~x
            //this.gameObject.SetActive(false);
            management.KillEnemy(this.gameObject);
        }
    }
}
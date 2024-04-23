using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    GameObject playerObj;

    int health;

    private void Start()
    {
        if (playerObj = null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        Debug.Log("Am I tagged as Enemy?");
    }

    private void EnemyMoves()
    {
        //get the locations
        Vector3 playerLocation = playerObj.transform.position;
        Vector3 dirToPlayer = playerLocation - this.transform.position;

        //take that from the current pos

        //move towards player

    }

    public void EnemyTakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            EnemyDies();
        }
    }


    private void EnemyDies()
    {
        //bleh x~x

    }
}

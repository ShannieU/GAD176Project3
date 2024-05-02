using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeesStuff
{
    public class EnemyRunner : BaseEnemy
    {
        protected override void Start()
        {
            base.Start();
            //change the variables to be more accurate the enemy type
            safeDistance = 2;
            attackDistance = 3;
        }

        protected override void Update()
        {
            base.Update();
            EnemyMoves(playerObj.transform.position);
        }

        protected override void EnemyMoves(Vector3 location)
        {
            base.EnemyMoves(location);
            if (withinDestinationRange)
            {
                EnemyAttack();
            }
        }
    }
}

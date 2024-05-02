using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeesStuff
{
    public class EnemyShooter : BaseEnemy
    {
        public Cover mineCover;
        private int lengthOfTime = 5;

        Transform goalLocation;

        protected override void Start()
        {
            base.Start();
            goalLocation = mineCover.inCover.transform;
            EnemyMoves(goalLocation.position);
        }

        protected override void Update()
        {
            if (!withinDestinationRange)
            {
                EnemyMoves(goalLocation.position);
            }
            base.Update();
        }

        protected override void EnemyMoves(Vector3 location)
        {
            base.EnemyMoves(location);
            if (location == mineCover.inCover.transform.position && withinDestinationRange)
            {
                //enemy is in cover, stay for length, move out of cover
                StartCoroutine(WhileInCover());
            }
            else if (location == mineCover.outCover.transform.position && withinDestinationRange)
            {
                //enemy is out of cover, attack for length, move back into cover
                StartCoroutine(WhileOutCover());
            }
        }

        IEnumerator WhileInCover()
        {
            //Debug.Log("in cover");
            // set the position to the incover pos
            this.transform.position = mineCover.inCover.transform.position;

            //hide for the preset lentgh of time
            yield return new WaitForSeconds(lengthOfTime);

            //change where its su[pposed to go and then go there
            goalLocation = mineCover.outCover.transform;
            EnemyMoves(goalLocation.position);

            yield return null;
        }

        IEnumerator WhileOutCover()
        {
            //Debug.Log("out cover");
            // set the position to the out of cover pos
            this.transform.position = mineCover.outCover.transform.position;

            float tickTock = 0, interval = 0.5f;

            while (tickTock <= lengthOfTime)
            {
                //attack the player at a consistent interval
                EnemyAttack();
                yield return new WaitForSeconds(interval);
                tickTock += interval;
                //Debug.Log(tickTock);
            }
            if (tickTock >= lengthOfTime)
            {
                //change where its supposed to go and then go there
                goalLocation = mineCover.inCover.transform;
                EnemyMoves(goalLocation.position);
            }
            yield return null;
        }
    }
}

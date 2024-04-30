using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeesStuff
{
    public class SpawnPoint : MonoBehaviour
    {
        public int order, enemyCount;

        public Transform mineLocation;

        public List<Cover> covers;

        private void Start()
        {
            mineLocation = this.gameObject.transform;
        }
    }
}
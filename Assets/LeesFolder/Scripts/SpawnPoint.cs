using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int order, enemyCount;

    public Transform mineLocation;

    private void Start()
    {
        mineLocation = this.gameObject.transform;
    }
}

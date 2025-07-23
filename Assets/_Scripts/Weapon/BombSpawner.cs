using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombSpawner : Spawner
{

    private void Reset()
    {
        this.prefabName = "BombPrefab";
        this.spawnPosName = "BombSpawnPos";
        this.maxObj = 17; 
    }
}

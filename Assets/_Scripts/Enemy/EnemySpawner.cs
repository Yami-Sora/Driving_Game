using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemySpawner : Spawner
{

    private void Reset()
    {
        this.prefabName = "EnemyPrefab";
        this.spawnPosName = "EnemySpawnPos";
    }
}

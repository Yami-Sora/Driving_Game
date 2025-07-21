using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    protected List<GameObject> enemies = new List<GameObject>();
    protected int maxEnemies = 1; 
    protected GameObject enemyPrefab;
    protected float Timer = 0f;
    protected float Delay = 2f;

    private void Awake()
    {
        this.enemyPrefab = GameObject.Find("EnemyPrefab");
        this.enemyPrefab.SetActive(false);
    }

    private void FixedUpdate()
    {
        this.Spawn();
        this.CheckDead();
    }
    protected virtual void Spawn()
    {
        if(PlayerCtrl.Instance.damageReceiver.IsDead())
        {
            return;
        }
        if (this.enemies.Count >= this.maxEnemies) return;

        this.Timer += Time.deltaTime;
        if (this.Timer < this.Delay) return;
        this.Timer = 0f;

        GameObject enemy = Instantiate(this.enemyPrefab);
        enemy.SetActive(true);

        this.enemies.Add(enemy);
    }
    void CheckDead()
    {
        for (int i = 0; i < this.enemies.Count; i++)
        {
            if (this.enemies[i] == null)
            {
                this.enemies.RemoveAt(i);
                i--;
            }
        }
    }
}

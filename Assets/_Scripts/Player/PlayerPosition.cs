using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPosion : MonoBehaviour
{
    int index =1;
    protected List<GameObject> bombs = new List<GameObject>();
    protected GameObject bombPrefab;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 1f;
    private void Awake()
    {
        this.bombPrefab = GameObject.Find("BombPrefab");
        this.bombPrefab.SetActive(false);
    }


    void Update()
    {
        this.Spawn();
        this.CheckminionDead();
        this.ResetIndex(); 
    }

    void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (spawnTimer < spawnDelay) return;
        this.spawnTimer = 0f;

        if (bombs.Count >= 7) return;
        GameObject bomb = Instantiate(this.bombPrefab);
        bomb.name = "Bom #" + index;
        index++;
        this.bombs.Add(bomb);
        bomb.transform.position = transform.position;
        bomb.gameObject.SetActive(true);
    }

    void CheckminionDead()
    {
        for (int i = 0; i < this.bombs.Count; i++)
        {
            if (this.bombs[i] == null)
            {
                this.bombs.RemoveAt(i);
                i--;
            }
        }
    }

    private void ResetIndex()
    {
        if (index > 7)
        {
            index = 1; // Reset index về 1 nếu vượt quá 7
        }
    }

}

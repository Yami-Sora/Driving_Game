using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    int index =1;
    List<GameObject> minions = new List<GameObject>();
    public GameObject minionPrefab;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 1f;


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

        if (minions.Count >= 7) return;
        GameObject minion = Instantiate(this.minionPrefab);
        minion.name = "Bom #" + index;
        index++;
        this.minions.Add(minion);
        minion.transform.position = transform.position;
        minion.gameObject.SetActive(true);
    }

    void CheckminionDead()
    {
        for (int i = 0; i < this.minions.Count; i++)
        {
            if (this.minions[i] == null)
            {
                this.minions.RemoveAt(i);
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

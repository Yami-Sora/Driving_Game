using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]
    public GameObject objPrefab;
    public List<GameObject> objects = new List<GameObject>();
    public GameObject SpawnPos;
    public float spawnTimer = 0f;
    public float spawnDelay = 1f;
    public string prefabName = "";
    public string spawnPosName = "";
    public int maxObj = 1;
    public int OrderLayer = 5;

    private void Awake()
    {
        this.objPrefab = GameObject.Find(this.prefabName);
        this.SpawnPos = GameObject.Find(this.spawnPosName);
        this.objPrefab.SetActive(false);
        this.OrderLayer = (int)this.objPrefab.transform.position.z;

    }
    private void FixedUpdate()
    {
        this.Spawn();
        this.CheckDead();
    }
    protected virtual GameObject Spawn()
    {
        if (PlayerCtrl.Instance.damageReceiver.IsDead()) return null;
        if (this.objects.Count >= this.maxObj) return null;

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return null;
        this.spawnTimer = 0f;
        Vector3 pos = this.SpawnPos.transform.position;
        pos.z = this.OrderLayer;
        return this.Spawn(pos);
    }
    protected virtual GameObject Spawn(Vector3 pos)
    {
        GameObject obj = Instantiate(this.objPrefab);
        obj.transform.position = pos;
        obj.transform.parent = transform;
        obj.SetActive(true);
        this.objects.Add(obj);
        return obj;
    }

    protected void CheckDead()
    {
        for (int i = 0; i < this.objects.Count; i++)
        {
            if (this.objects[i] == null)
            {
                this.objects.RemoveAt(i);
                i--;
            }
        }
    }
}

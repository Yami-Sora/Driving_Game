using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    protected GameObject enemyPrefab;
    protected float Timer = 0f;
    protected float Delay = 2f; // Thời gian giữa các lần spawn

    private void Awake()
    {
        this.enemyPrefab = GameObject.Find("EnemyPrefab");
        this.enemyPrefab.SetActive(false);
    }

    private void Update()
    {
        this.Spawn();
    }
    protected virtual void Spawn()
    {
        if(PlayerCtrl.Instance.damageReceiver.IsDead())
        {
            return; // Không spawn nếu người chơi đã chết
        }

        this.Timer += Time.deltaTime;
        if (this.Timer < this.Delay) return;
        this.Timer = 0f;

        GameObject enemy = Instantiate(this.enemyPrefab);
        //enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }
}

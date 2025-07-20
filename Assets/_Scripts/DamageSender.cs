using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [SerializeField]
    protected EnemyCtrl enemyCtrl;
    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver receiver = collision.GetComponent<DamageReceiver>();
        if (receiver != null && enemyCtrl != null)
        {
            receiver.Receive(1);
        }
        this.enemyCtrl.despawner.Despawn();
        Debug.Log("Enemy đã bị phá huỷ");
    }
}

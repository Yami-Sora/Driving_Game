using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [Header("Enemy")]
    protected EnemyCtrl enemyCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }
    protected override void ColliderSendDamage(Collider2D collision)
    {
        base.ColliderSendDamage(collision);

        this.enemyCtrl.despawner.Despawn();
        //Destroy(this.gameObject);
    }
}

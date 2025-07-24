using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    public EnemyCtrl enemyCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }

    private void Reset()
    {
        this.hp = 3;
    }

    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            EffectManager.Instance.SpawnVFX("Explosion_B", transform.position, Quaternion.identity);
            this.enemyCtrl.despawner.Despawn();
        }
    }
}

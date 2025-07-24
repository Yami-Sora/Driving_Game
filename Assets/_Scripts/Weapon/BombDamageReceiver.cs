using UnityEngine;

public class BombDamageReceiver : DamageReceiver
{
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            Destroy(gameObject);
            EffectManager.Instance.SpawnVFX("Explosion_A", transform.position, Quaternion.identity);
        }

    }
}

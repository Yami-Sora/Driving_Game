using UnityEngine;

public class BombDamageReceiver : DamageReceiver
{
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if(this.IsDead()) Destroy(gameObject);
    }
}

using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [Header("DamageSender")]
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.ColliderSendDamage(collision);
    }

    protected virtual void ColliderSendDamage(Collider2D collision)
    {
        DamageReceiver receiver = collision.GetComponent<DamageReceiver>();
        if (receiver != null) receiver.Receive(this.damage);
    }
}

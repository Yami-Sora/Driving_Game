using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [Header("Damage Receiver")]
    public int hp = 1;

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    public virtual void Receive(int damage)
    {
        this.hp -= damage;
    }
}

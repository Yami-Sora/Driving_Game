using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected PlayerCtrl playerCtrl;

    private void Awake()
    {
        this.playerCtrl = GetComponent<PlayerCtrl>();
    }
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            this.playerCtrl.playerStatus.Dead();
            UIManager.Instance.bnGameOver.SetActive(true);
        }
    }
}

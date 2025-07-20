using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public DamageReceiver damageReceiver;
    public PlayerStatus playerStatus;
    public static PlayerCtrl Instance{ get; private set; }
    private void Awake()
    {
        PlayerCtrl.Instance = this;
        this.damageReceiver = GetComponent<DamageReceiver>();
        this.playerStatus = GetComponent<PlayerStatus>();
    }
   
}

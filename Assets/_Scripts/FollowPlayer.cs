using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; 
    [SerializeField] protected float speed = 27f;
    [SerializeField] protected float DisLimit = 6f;
    [SerializeField] protected float randPosX = 0f;

    private void Start()
    {
        this.player = PlayerCtrl.Instance.transform;
        this.randPosX = Random.Range(-8f, 8f);
    }
    void FixedUpdate()
    {
        this.Follow();
    }
    void Follow()
    {
        Vector3 pos = this.player.position;
        pos.x = this.randPosX;
        Vector3 distance = pos - transform.position;

        if (distance.magnitude >= DisLimit)
        {
            Vector3 targetPoint = pos - distance.normalized * DisLimit;

            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.fixedDeltaTime);
        }
    }
}

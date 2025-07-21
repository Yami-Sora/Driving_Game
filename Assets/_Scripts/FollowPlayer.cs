using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; 
    [SerializeField] protected float speed = 27f;
    [SerializeField] protected float DisLimit = 6f;

    private void Start()
    {
        this.player = PlayerCtrl.Instance.transform;
    }
    void Update()
    {
        this.Follow();
    }
    void Follow()
    {
        Vector3 distance = player.transform.position - transform.position;

        if (distance.magnitude >= DisLimit)
        {
            Vector3 targetPoint = player.transform.position - distance.normalized * DisLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, speed * Time.deltaTime);
        }
    }
}

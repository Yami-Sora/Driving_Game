using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player; 
    protected float speed = 4f;
    protected float DisLimit = 0.5f;

    void Update()
    {
        this.Follow();
    }
    void Follow()
    {
        Vector3 distance = Player.transform.position - transform.position;

        if (distance.magnitude >= DisLimit)
        {
            Vector3 targetPoint = Player.transform.position - distance.normalized * DisLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, speed * Time.deltaTime);
        }
    }
}

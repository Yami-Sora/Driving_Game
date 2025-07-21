using UnityEngine;

public class RoadDespawner : MonoBehaviour
{
    protected float distance = 0f;

    private void FixedUpdate()
    {
        this.UpdateRoad();
    }
    protected virtual void UpdateRoad()
    {
        this.distance = Vector2.Distance(PlayerCtrl.Instance.transform.position, transform.position);
        if (this.distance > 70)
        {
            this.Despawn();
        }
    }
    protected virtual void Despawn()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    public Vector2 velocity =new Vector2(0f, 0f);
    [SerializeField] protected float pressHorizontal = 0f;
    [SerializeField] protected float pressVertical = 0f;
    [SerializeField] protected float speedUp = 0.5f;
    [SerializeField] protected float speedDown = 0.5f;
    [SerializeField] protected float speedMax = 20f;
    [SerializeField] protected float speedHorizontal = 10f;

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        if (this.rb2d == null)
        {
            Debug.LogError("Rigidbody2D component not found on PlayerMovement.");
        }
    }

    private void Update()
    {
     this.pressHorizontal = Input.GetAxis("Horizontal");
     this.pressVertical = Input.GetAxis("Vertical");           
    }
    private void FixedUpdate()
    {
        this.UpdateSpeed();
    }
    protected virtual void UpdateSpeed()
    {
        this.velocity.x = this.pressHorizontal * this.speedHorizontal;
        if (this.pressVertical > 0) this.velocity.y += this.speedUp;
        if (this.pressVertical == 0)
        {
            this.velocity.y -= this.speedDown;
            if (this.velocity.y < 0) this.velocity.y = 0;
        }
        if (this.velocity.y > this.speedMax) this.velocity.y = this.speedMax;


        this.rb2d.MovePosition(this.rb2d.position + this.velocity * Time.fixedDeltaTime);
    }
    
}
 
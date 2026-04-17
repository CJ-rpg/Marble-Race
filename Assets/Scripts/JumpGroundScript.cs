using UnityEngine;

public class JumpGroundScript : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 8f;
[SerializeField] private float sideBoost = 3f;
[SerializeField] private float maxX = 10f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;

        if (rb != null)
        {
            float currentY = rb.linearVelocity.y;

            // optional: keep a bit of momentum
            float newY = Mathf.Max(jumpVelocity, currentY * 0.5f);

            float newX = rb.linearVelocity.x + sideBoost;
            newX = Mathf.Clamp(newX, -maxX, maxX);

            rb.linearVelocity = new Vector2(newX, newY);
        }
    }
}

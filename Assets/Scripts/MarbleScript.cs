using System.Collections;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{

    public Vector2 startForce = new Vector2(5f, 0);
    public float delay = 7f; // Delay in seconds
    public Vector2 pushForce = new Vector2(5f, 0); // Direction + strength
    public float pushDelay = 1f;

    private Vector3 startPosition;
    public Transform spawnPoint;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = spawnPoint.position;
        rb = GetComponent<Rigidbody2D>();

        Invoke(nameof(ApplyForce), delay);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            TeleportToStart();
        }
    }

    void TeleportToStart()
    {
        rb.linearVelocity = Vector2.zero; // Stop movement
        transform.position = startPosition;
        StartCoroutine(DelayedPush());
    }

    IEnumerator DelayedPush()
    {
        yield return new WaitForSeconds(pushDelay);
        rb.AddForce(pushForce, ForceMode2D.Impulse);
    }

    void ApplyForce()
    {
        GetComponent<Rigidbody2D>().AddForce(startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    public float delay = 5f; // Delay in seconds
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 90f * Time.deltaTime);
        Invoke(nameof(Destroy), delay);
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{
    public enum DoorState
    {
        Closed,
        Opening,
        Open,
        Closing
    }

    public Transform door; // Assign in Inspector
    public Transform hinge; // Assign in Inspector

    public float openAngle = -90f;
    public float speed = 90f; // degrees per second
    public float pauseTime = 1f; // time to wait when open/closed

    private DoorState state = DoorState.Closed;
    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoorCycle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator DoorCycle()
    {
        while (true)
        {
            // Open
            state = DoorState.Opening;
            yield return RotateDoor(0f, openAngle);
            state = DoorState.Open;
            yield return new WaitForSeconds(pauseTime);

            // Close
            state = DoorState.Closing;
            yield return RotateDoor(openAngle, 0f);
            state = DoorState.Closed;
            yield return new WaitForSeconds(pauseTime);
        }
    }

    private IEnumerator RotateDoor(float fromAngle, float toAngle)
    {
        float elapsed = 0f;
        float duration = Mathf.Abs(toAngle - fromAngle) / speed;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float angle = Mathf.Lerp(fromAngle, toAngle, elapsed / duration);
            float delta = angle - currentAngle;
            door.RotateAround(hinge.position, Vector3.forward, delta);
            currentAngle = angle;
            yield return null;
        }

        // Ensure final position
        float correction = toAngle - currentAngle;
        door.RotateAround(hinge.position, Vector3.forward, correction);
        currentAngle = toAngle;
    }
}

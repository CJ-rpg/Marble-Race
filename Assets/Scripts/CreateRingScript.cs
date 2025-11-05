using UnityEngine;

[ExecuteInEditMode]
public class CreateRingScript : MonoBehaviour
{
    public int segments = 24;
    public float radius = 3f;
    public float thickness = 0.3f;
    public Color color = Color.black;
    public Sprite sprite; // Assign a square sprite here
    void OnValidate()
    {
        UpdateRing();
    }


    void Start()
    {
         if (!Application.isPlaying)
            UpdateRing();
    }
    void UpdateRing()
    {
        // Clean up old children
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        // Create ring parts
        for (int i = 0; i < segments; i++)
        {
            float angle = (360f / segments) * i;
            float rad = angle * Mathf.Deg2Rad;

            Vector2 position = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

            GameObject wall = new GameObject("ColliderPart_" + i);
            wall.transform.parent = transform;
            wall.transform.localPosition = position;
            wall.transform.localRotation = Quaternion.Euler(0, 0, angle);

            // Add Collider
            BoxCollider2D col = wall.AddComponent<BoxCollider2D>();
            col.size = new Vector2(thickness, 1f);

            // Add Sprite Renderer
            if (sprite != null)
            {
                SpriteRenderer sr = wall.AddComponent<SpriteRenderer>();
                sr.sprite = sprite;
                sr.color = color;
                sr.sortingOrder = 1;
                sr.drawMode = SpriteDrawMode.Sliced;
                sr.size = col.size;
            }
        }
    }
    void Update()
    {
        
    }
}

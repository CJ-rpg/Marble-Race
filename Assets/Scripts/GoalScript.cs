using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    //A reference to the game manager
    public GameManager gameManager;
    public TMPro.TextMeshProUGUI textbox;

    // Triggers when the marble collides with trap
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject marble = collision.gameObject;

        // Moves the player to the spawn point
        gameManager.Goal(marble);

        textbox.text = "Last Marble to Finish: " + marble.name;
    }
}

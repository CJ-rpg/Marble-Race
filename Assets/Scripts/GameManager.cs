using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform teleporter;

    public bool isGameOver = false;
    // Flags that control the state of the game
    private float elapsedTime = 0;
    private bool isRunning = false;
    int marbles = GameObject.FindGameObjectsWithTag("Marble").Length;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }
    private void StartGame()
    {

        elapsedTime = 0;
        isRunning = true;
        isGameOver = false;
    }
    public void FinishedGame()
    {
        isRunning = false;
        Time.timeScale=0;
    }
    // Update is called once per frame
    void Update()
    {

        // Add time to the clock if the game is running
        if (isRunning)
        {
            elapsedTime = elapsedTime + Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
    void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    void OnGUI()
    {
        if (isGameOver)
        {
            FinishedGame();
            string message;

            message = "Click or Press Enter to Play Again";


            //Define a new rectangle for the UI on the screen
            Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

            if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
            {
                //start the game if the user clicks to play
                Time.timeScale = 1;
                Start();
                Reset();
                
            }
            GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Your Time Was\n" + ((int)elapsedTime).ToString() + " seconds");

        }
    }
    
    public void Goal(GameObject marble)
	{
        marble.transform.position = teleporter.position;
        marbles--;
        if (marbles == 1)
        {
            isGameOver = true;
        }
	}
}

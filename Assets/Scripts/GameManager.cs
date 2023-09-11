using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

// Notes from last session:
// You think you figured out how to maintain a persistent GameManager object
// between scenes and reloads and also have attached it to both even triggers for game
// over and level complete but you can only fail once either by falling off or hitting
// an object, the level reloads and should reattach the gameManager but it doesn't seem to
// call the end level function a second time.
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1;
    public GameObject completeLevelUI;

    public float currentScore = 0;
    public static GameManager Manager;

    void FixedUpdate()
    {
        returnToMain();
    }
    private void Awake()
    {
        if (Manager != null)
        {
            // Destroy(Manager);
            return;
        }
        Manager = this;
        DontDestroyOnLoad(Manager);
        Debug.Log("New Game Manager instantiated");
        // completeLevelUI = FindObjectOfType<GameObject>(LevelComplete);
    }
    // public void UpdateHighScore (float recentScore, LinkedList<float> highscores)
    // {
    //     //Your plan is to determine a data structure to hold 1-10 high scores and display them in descending order
    //     //then you can call this method when the player fails or reaches the end of the level and then
    //     //search through your data and insert where appropriate, then restart
    //     //Debug.Log("Recent Score " + recentScore);
    //     highscores.AddLast(recentScore);
    //     foreach(float score in highscores) {
    //         Debug.Log("Score: "+ score + " key: " + highscores.Count);
    //     }
    // }
    // public void GetHighScore (LinkedList<float> highscores)
    // {
    //     foreach(float score in highscores) {
    //         Debug.Log("Score: "+ score + " key: " + highscores.Count);
    //     }
    // }

    public void LevelComplete()
    { // should deprecate and merge into EndGame as plan to make levels infinite.
        completeLevelUI.SetActive(true);
        // Load Level 2 - NYI
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, restartDelay);
        //Debug.Log("COMPLETE");
    }
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            //Debug.Log("Game Over");
            //UpdateHighScore(FindObjectOfType<Score>().scoreFloat, highscores);
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameHasEnded = false;
    }

    void returnToMain()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Debug.Log("Escaped Level");
        }
    }
}

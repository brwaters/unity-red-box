using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1;
    public GameObject completeLevelUI;

    public static GameManager Manager;
        private void Awake()
        {
            if (Manager != null)
            {
                Destroy(gameObject);
                return;
            }
            Manager = this;
            DontDestroyOnLoad(gameObject);
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
        //Debug.Log("COMPLETE");
    }
    public void EndGame()
    {
        if (!gameHasEnded) {
            gameHasEnded = true;
            //Debug.Log("Game Over");
            //UpdateHighScore(FindObjectOfType<Score>().scoreFloat, highscores);
            Invoke("Restart",restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}

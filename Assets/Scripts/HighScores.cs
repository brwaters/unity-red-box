using UnityEngine;
using UnityEngine.SceneManagement;
public class HighScores : MonoBehaviour
{
//should just request the high scores from the GameManager and display here.
    void Update()
    {
        //Debug.Log(FindObjectOfType<GameManager>().GetHighScore);
    }

        public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

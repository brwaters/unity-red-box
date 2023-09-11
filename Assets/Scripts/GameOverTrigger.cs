using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    void OnTriggerEnter()
    {
        gameManager.EndGame();
    }
}

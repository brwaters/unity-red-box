using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void Awake() {

        gameManager = FindObjectOfType<GameManager>();

    }
    void OnTriggerEnter() {
        gameManager.LevelComplete();
    }
}

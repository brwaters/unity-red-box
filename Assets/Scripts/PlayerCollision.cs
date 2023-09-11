using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "EndLevelVolume" ) {
            movement.enabled = false;
        }
        if (collisionInfo.collider.tag == "Obstacle"){
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        if (collisionInfo.collider.tag == "Ground") {
            movement.canJump = true;
        }
        if (collisionInfo.collider.tag =="KillVolume") {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}


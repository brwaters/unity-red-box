using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public bool canJump = true;
    public float forwardForce = 2000f;
    public float sidewaysForce = 100f;
    public float upwardForce = 200f;
    public bool isFrozen = false;
    public PlayerMovement playerMovement;
    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {

        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Move side to side
        // if (Input.GetKey("d"))
        // {
        //     rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }
        // if (Input.GetKey("a"))
        // {
        //     rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }

        // Side to side movement that uses Input Manager instead
        float sideMovement = Input.GetAxis("Horizontal") * sidewaysForce * Time.deltaTime;
        transform.Translate(Vector3.right * sideMovement);
        // Jump
        if (Input.GetKey(KeyCode.Space)) {
            if(canJump) {
                rb.AddForce(0, upwardForce * Time.deltaTime, 0,ForceMode.VelocityChange);
                canJump = false;
            }
        }

        // End game is player falls off level
        if (rb.position.y < 0f) {
            Debug.Log("player is below 0f");
            if (!isFrozen)
            {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            isFrozen = true;
            playerMovement.enabled = false;
            }
            FindObjectOfType<GameManager>().EndGame();
        }

        // Return to Main Menu
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }
}

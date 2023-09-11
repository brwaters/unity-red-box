using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
public Transform player;
public TMP_Text scoreText;
public float scoreFloat;
void Update()
{
    scoreText.text = player.position.z.ToString("0");
    scoreFloat = player.position.z;
}
}

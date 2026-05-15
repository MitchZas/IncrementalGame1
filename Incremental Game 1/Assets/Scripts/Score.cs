using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] InputHandler mouseClickScript;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + mouseClickScript.score.ToString();
    }
}

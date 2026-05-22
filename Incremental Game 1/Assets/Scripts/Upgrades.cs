using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int price;
    [SerializeField] InputHandler scriptScore;
    public TextMeshProUGUI scoreText;
    int minValue = 0;
    int maxValue = 100;

    // Increase speed by 10% 
    public void IncreasedSpeed ()
    {
        //Increased Pickaxe Animation Speed by 10% 
        ClampScore(3);
    }

    public void IncreaseOutput()
    {
        // When Pickaxe hits the rock, increase score + 2 
        scriptScore.score -= 1;
    }

    private void ClampScore(int price)
    {
        scriptScore.score -= price;
        scriptScore.score = Mathf.Clamp(scriptScore.score, minValue, maxValue);
        scriptScore.UpdateScoreUI();
    }
}

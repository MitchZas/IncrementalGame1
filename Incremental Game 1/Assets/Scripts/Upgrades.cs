using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int price;
    [SerializeField] InputHandler scriptScore;
    [SerializeField] Animator animator;
    [SerializeField] AnimationController animController;
    [SerializeField] GameObject Pickaxe;
    public bool canIncreaseOutput;
    int minValue = 0;
    int maxValue = 100;

    // Increase speed by 10% 
    public void IncreasedSpeed ()
    {
        //Increased Pickaxe Animation Speed by 10% 
        animator.speed = 5f;
        ClampScore(3);
    }
    public void IncreaseOutput()
    {
        // When Pickaxe hits the rock, increase score + 2 
        canIncreaseOutput = true;
        Pickaxe.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        ClampScore(1);
    }

    private void ClampScore(int price)
    {
        scriptScore.score -= price;
        scriptScore.score = Mathf.Clamp(scriptScore.score, minValue, maxValue);
        scriptScore.UpdateScoreUI();
    }
}

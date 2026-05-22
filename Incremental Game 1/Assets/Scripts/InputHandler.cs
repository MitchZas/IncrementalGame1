using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public bool isClicked;

    [Header("Upgrade Buttons")]
    [SerializeField] Button Upgrade1Button;
    [SerializeField] private TextMeshProUGUI upgradeButton1Text;
    [SerializeField] Button Upgrade2Button;
    [SerializeField] private TextMeshProUGUI upgradeButton2Text;

    [Header("Auto Click Settings")]
    public bool autoClick = false;
    public float autoClickInterval = 1f;
    private float _autoClickTimer;

    [Header("Score Settings")]
    public int score = 0;
    public int scorePerClick = 1;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] Upgrades upgradesScript;

    private void Awake()
    {
        _mainCamera = Camera.main;
        isClicked = false;
        _autoClickTimer = autoClickInterval;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void OnButtonClick()
    {
        AddScore();
        isClicked = true;
    }

    private void AddScore()
    {
        score += scorePerClick;
        if (upgradesScript.canIncreaseOutput) score += scorePerClick;

        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        _scoreText.text = "Score: " + score;
    }

    void Update()
    {        
        if (autoClick)
        {
            _autoClickTimer -= Time.deltaTime;
            if (_autoClickTimer <= 0f)
            {
                //AddScore();
                _autoClickTimer = autoClickInterval;
            }
        }
    }
}
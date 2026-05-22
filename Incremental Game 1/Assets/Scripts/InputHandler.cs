using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public bool isClicked;

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

    //public void OnClick(InputAction.CallbackContext context)
    //{
    //    if (!context.started) return;
    //    PerformClick();
    //}

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

    //public void PerformClick()
    //{
    //    var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
    //    if (!rayhit.collider) return;

    //    if(rayhit.collider.gameObject.name == "MineButton")
    //    {
    //        isClicked = true;
    //        AddScore();
    //    }

    //    Debug.Log(rayhit.collider.gameObject.name);
    //}
}
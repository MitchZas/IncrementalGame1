using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private bool isClicked;

    [Header("Auto Click Settings")]
    public bool autoClick = false;
    public float autoClickInterval = 1f;
    private float _autoClickTimer;

    [Header("Score Settings")]
    public int score = 0;
    public int scorePerClick = 1;
    [SerializeField] private TextMeshProUGUI _scoreText;

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

    private void OnButtonClick()
    {
        AddScore();
    }

    private void AddScore()
    {
        score += scorePerClick;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        _scoreText.text = "Score: " + score;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        isClicked = true;
        if (!context.started) return;
        PerformClick();
    }

    void Update()
    {
        if (autoClick)
        {
            _autoClickTimer -= Time.deltaTime;
            if (_autoClickTimer <= 0f)
            {
                AddScore();
                _autoClickTimer = autoClickInterval;
            }
        }
    }

    private void PerformClick()
    {
        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;
        Debug.Log(rayhit.collider.gameObject.name);
    }
}
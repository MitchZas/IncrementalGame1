using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] AudioSource mouseClickSFX;
    public int score;

    [Header("Scripts")]
    [SerializeField] Score clickScoreScript;

    [Header("Auto Click Settings")]
    public bool autoClick = false;
    public float autoClickInterval = 3f;
    private float _autoClickTimer;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _autoClickTimer = autoClickInterval;
        score = 0;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
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
                PerformClick();
                score++;
                _autoClickTimer = autoClickInterval;
                mouseClickSFX.Play();
                Debug.Log("Click Registered");
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

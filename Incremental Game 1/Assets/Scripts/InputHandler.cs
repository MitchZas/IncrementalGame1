using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private bool isClicked;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _mainCamera = Camera.main;
        isClicked = false;

        Vector3 scaleUp = new Vector3(4, 4, 4);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        isClicked = true;
        if (!context.started) return;

        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;

        Debug.Log(rayhit.collider.gameObject.name);
    }

    void Update()
    {
        if (isClicked)
        {
            _spriteRenderer.color = Color.red;
        }
    }
}

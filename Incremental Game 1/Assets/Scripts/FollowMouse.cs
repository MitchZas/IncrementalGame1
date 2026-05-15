using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private float maxSpeed = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosition();
        Cursor.visible = false;
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePos);

        //return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}

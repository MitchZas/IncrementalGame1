using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] InputHandler mouseClickScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseClickScript.isClicked == true)
        {
            animator.SetTrigger("Swing");
            mouseClickScript.isClicked = false;
        }
    }
    void OnSwingComplete()
    {
        animator.Play("Idle");
        // Force the animator to the first frame of idle immediately
        animator.Update(0);
    }
}

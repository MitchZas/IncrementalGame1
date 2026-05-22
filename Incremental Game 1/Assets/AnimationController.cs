using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] InputHandler mouseClickScript;
    public bool animComplete;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animComplete = false;
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
    public void OnSwingComplete()
    {
        animator.Play("Idle");
        // Force the animator to the first frame of idle immediately
        animator.Update(0);
        animComplete = true;
    }
}

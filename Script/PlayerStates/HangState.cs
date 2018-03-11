using UnityEngine;
using System.Collections;

public class HangState : State {
    Rigidbody rigidbody;
    Animator animator;
    Transform transform;
    public HangState(Rigidbody pRigidbody, Animator pAnimator, Transform pTransform)
    {
        rigidbody = pRigidbody;
        animator = pAnimator;
        transform = pTransform;
    }

    public override void update()
    {
        animator.SetBool("hanging", true);
        rigidbody.isKinematic = true;
        if (Input.GetKeyDown("w"))
        {
            animator.SetBool("hanging", false);
            rigidbody.isKinematic = false;
            rigidbody.AddForce(new Vector2(0, 6), ForceMode.Impulse);
            transform.GetComponent<Platformer>().pState = transform.GetComponent<Platformer>().moveState;
        }
        if(Input.GetKeyDown("s"))
        {
            animator.SetBool("hanging", false);
            transform.GetComponent<Platformer>().pState = transform.GetComponent<Platformer>().moveState;
        }
        
       
    }
}

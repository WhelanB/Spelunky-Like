using UnityEngine;
using System.Collections;

public class MoveState : State {
    Rigidbody rigidbody;
    Animator animator;
    Transform transform;
    bool canJump = true;
    private bool facingRight = true;
    float speed = 3f;
    public MoveState(Rigidbody pRigidbody, Animator pAnimator, Transform pTransform)
    {
        rigidbody = pRigidbody;
        animator = pAnimator;
        transform = pTransform;
    }
	
	public override void update () {
        rigidbody.isKinematic = false;
        if (Input.GetKeyDown("w") && canJump)
        {
            canJump = false;
            rigidbody.AddForce(new Vector2(0, 6), ForceMode.Impulse);
            animator.SetBool("jumping", true);
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector2.down, out hit, 0.6f) && this.rigidbody.velocity.y < 0)
        {
            if(hit.transform.tag == "Terrain")
            {
                canJump = true;
            }
        }
        if(rigidbody.velocity.x != 0 && Physics.Raycast(transform.position, Vector2.down, out hit, 0.6f) && canJump)
        {
            animator.SetBool("walking", true);
            animator.SetBool("jumping", false);
        }
        
        if(canJump && rigidbody.velocity.x == 0)
        {
            animator.SetBool("walking", false);
        }
        
        float h = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(h, rigidbody.velocity.y);
        rigidbody.velocity = movement;

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        
    }


    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

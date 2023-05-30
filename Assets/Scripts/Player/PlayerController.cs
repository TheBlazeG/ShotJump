using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public new Rigidbody2D rigidbody;
    public float jumpvelocity;
    public float movevelocity;
    public float gravityvelocity;
    private Vector2 velocity;
    private bool grounded;
    private bool jumping;
    public Transform origin;
    public float radius;
    private bool mario;
    private void Update()
    {
        float move = ControlsInstance.Instance.Gameplay.Move.ReadValue<float>();
        animator.SetBool("Walking", move != 0);

        Vector3 scale = Vector3.one;
        if (move < 0)
            scale.x = -1;
        if (move>0)
            scale.x = 1;

        transform.localScale = scale;

        grounded = IsGrounded();
        velocity.y=grounded && !jumping  ?-1: velocity.y-gravityvelocity*Time.deltaTime;
        if (ControlsInstance.Instance.Gameplay.Jump.WasPressedThisFrame()&& grounded)
        {
            velocity.y = 1;
            StartCoroutine(JumpingHandler());
        }
        velocity.x = move * movevelocity;
        rigidbody.velocity=velocity;
    }
    private bool IsGrounded()
    {
       return Physics2D.OverlapCircle(origin.position, radius);
    }

    private IEnumerator JumpingHandler()
    {
        //mario = true;
        jumping = true;
        yield return new WaitForSeconds(1f);
        jumping = false;
        //mario = false;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    grounded= true;
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    grounded= false;
    //    jumping = false;
        
    //}
}

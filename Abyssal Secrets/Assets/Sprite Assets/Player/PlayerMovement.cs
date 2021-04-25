using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 12;
    private float movementSpeed;
    private float sprintSpeedMult = 2;
    private float diveSpeed = 15;
    private bool isFlippedX;
    private bool isIdle;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        isFlippedX = false;
        isIdle = true;
        movementSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var movementHorizontal = Input.GetAxis("Horizontal");
        var movementVertical = Input.GetAxis("Vertical");

        if (movementHorizontal < 0 && !isFlippedX)
        {
            Flip();
        }
        else if (movementHorizontal > 0 && isFlippedX)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isShift", true);
            movementSpeed = baseSpeed * sprintSpeedMult;
        }
        else
        {
            animator.SetBool("isShift", false);
            movementSpeed = baseSpeed;
        }

        CheckIdle(movementHorizontal, movementVertical);
        animator.SetFloat("swimming", Mathf.Abs(movementHorizontal));

        //float deltaX = Input.GetAxis("Horizontal") * movementSpeed;
        //float deltaZ = Input.GetAxis("Vertical") * diveSpeed;
        //Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //// Returns a copy of vector with its magnitude clamped to maxLength
        //movement = Vector3.ClampMagnitude(movement, movementSpeed);

        //movement *= Time.deltaTime;
        //// Transforms direction from local space to world space.
        //movement = transform.TransformDirection(movement);
        //rigidBody.AddForce(movement);

        //transform.position += new Vector3(movementHorizontal, 0, 0) * Time.deltaTime * movementSpeed;
        //transform.position += new Vector3(0, movementVertical, 0) * Time.deltaTime * diveSpeed;
    }

    private void FixedUpdate()
    {
        // Much more efficient than creating your own input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        // Generates the thrust forward to your rigidbody
        rigidBody.velocity = new Vector2(moveX * movementSpeed, moveY * diveSpeed);
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        if (theScale.y < 0)
        {
            theScale.y*= -1;
        }
        transform.localScale = theScale;

        isFlippedX = !isFlippedX;
    }

    private void CheckIdle(float movementHorizontal, float movementVertical)
    {
        if (movementHorizontal != 0 || movementVertical != 0)
        {
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }
        animator.SetBool("isIdle", isIdle);
    }
}


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
        transform.position += new Vector3(movementHorizontal, 0, 0) * Time.deltaTime * movementSpeed;
        transform.position += new Vector3(0, movementVertical, 0) * Time.deltaTime * diveSpeed;
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


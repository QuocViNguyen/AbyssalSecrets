using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 12;
    private float movementSpeed;
    private float sprintSpeedMult = 2;
    private float diveSpeed = 12;
    private bool isFlippedX;
    private bool isIdle;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Transform sealevel;
    [SerializeField] Text depthMeter;
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

        CheckIdle(movementHorizontal, movementVertical);
        animator.SetFloat("swimming", Mathf.Abs(movementHorizontal));
    }

    private void FixedUpdate()
    {
        // Much more efficient than creating your own input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        // Generates the thrust forward to your rigidbody
        rigidBody.velocity = new Vector2(moveX * movementSpeed, moveY * diveSpeed);
        UpdateDepthMeter();
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

    private void UpdateDepthMeter()
    {
        depthMeter.text = (int)((sealevel.position.y - transform.position.y)*0.08)+ "m";
    }
    public void BoostSpeed()
    {
        StartCoroutine(IncreaseSpeedAndReset());
    }

    private IEnumerator IncreaseSpeedAndReset()
    {
        movementSpeed = baseSpeed * sprintSpeedMult;

        yield return new WaitForSeconds(3.5f);

        movementSpeed = baseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MusicTrigger")
        {
            AudioManager.Instance.PlayStage1();
        }
        else if (collision.tag == "MusicTrigger1")
        {
            AudioManager.Instance.PlayStage2();
        }
        else if (collision.tag == "MusicTrigger2")
        {
            AudioManager.Instance.PlayStage3();
        }
        else if (collision.tag == "BossMusicTrigger")
        {
            AudioManager.Instance.PlayBossStage();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatHandler : MonoBehaviour
{
    private float remainingLifeTime = 5f;
    private Rigidbody2D rigidBody2D;
    private float throwSpeed = 2.8f;
    private float fallSpeed = 5f;
    private MeatCollisionHandler meatCollisionHandler;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        meatCollisionHandler = GetComponentInChildren<MeatCollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingLifeTime -= Time.deltaTime;
        if (remainingLifeTime <= 0)
            Destroy(gameObject);

        if (!meatCollisionHandler.IsLanded())
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }

        rigidBody2D.velocity = Vector2.Lerp(rigidBody2D.velocity, Vector2.zero, 0.05f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Attacker" && Vector3.SqrMagnitude(transform.position - collision.transform.position) >= 1.0f)
        {
            collision.transform.position = Vector3.Lerp(collision.transform.position, transform.position, 0.05f);
        }
    }

    public void FollowMouseDirection(Vector3 throwDirection)
    {
        rigidBody2D.velocity = new Vector2(throwDirection.x * throwSpeed, throwDirection.y * throwSpeed);
    }
}

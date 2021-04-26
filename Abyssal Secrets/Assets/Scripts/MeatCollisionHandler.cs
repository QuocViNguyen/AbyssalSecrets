using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCollisionHandler : MonoBehaviour
{
    private CircleCollider2D meatCollider;

    private void Start()
    {
        meatCollider = GetComponent<CircleCollider2D>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boundary")
        {
            meatCollider.isTrigger = false;
        }
    }

    public bool IsLanded()
    {
        return !meatCollider.isTrigger;
    }
}

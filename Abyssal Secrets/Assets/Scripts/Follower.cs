using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private bool isInRange;
    private Transform target;
    private Vector3 lastPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        if (isInRange)
        {
            transform.parent.position = Vector2.Lerp(transform.parent.position, target.position, 0.00297f);
        }
        else
        {
            transform.parent.position = Vector2.Lerp(transform.parent.position, lastPosition, 0.0015f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
        target = collision.gameObject.transform;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}

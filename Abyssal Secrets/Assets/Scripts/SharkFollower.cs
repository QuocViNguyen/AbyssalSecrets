using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkFollower : MonoBehaviour
{
    private bool isInRange;
    private Transform target;
    private Vector3 lastPosition;
    private float chasingSpeed = 15f;
    private float returnSpeed = 12f;

    [SerializeField] Transform sharkDen;
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
            Vector3 direction = (target.position - transform.parent.position).normalized;
            transform.parent.position += direction * chasingSpeed * Time.deltaTime;
        }
        else
        {
            Vector3 direction = (lastPosition - transform.parent.position).normalized;
            transform.parent.position += direction * returnSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = true;
            target = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }

    public void ToTheDen()
    {
        if (isInRange)
        {
            isInRange = !isInRange;
            lastPosition = sharkDen.position;
        }
    }
}

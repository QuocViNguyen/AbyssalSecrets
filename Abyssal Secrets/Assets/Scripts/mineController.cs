using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineController : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("explode", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeleteMine()
    {
        Destroy(gameObject);
    }
}

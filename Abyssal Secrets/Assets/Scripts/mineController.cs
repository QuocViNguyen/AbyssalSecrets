using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineController : MonoBehaviour
{

    private Animator animator;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            animator.SetBool("explode", true);
            AudioManager.Instance.PlayMineExplosion();
        }
    }

    private void DeleteMine()
    {   
        Destroy(gameObject);
        playerHealth.Death();
    }
}

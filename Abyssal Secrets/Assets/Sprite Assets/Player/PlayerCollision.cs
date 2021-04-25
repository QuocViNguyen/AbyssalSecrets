using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        while (collision.gameObject.layer == 7 && playerHealth.currentHealth>0)
        {
            playerHealth.OnHealthChanged(playerHealth.currentHealth-3);
            yield return new WaitForSeconds(1);   //Wait
        }

        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.SetActive(false);
        }
    }
}

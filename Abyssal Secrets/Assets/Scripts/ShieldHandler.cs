using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    [SerializeField] GameObject player;

    private float remainingLifeTime = 5f;

    private void Start()
    {
        FindObjectOfType<PlayerHealth>().shieldActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }

        remainingLifeTime -= Time.deltaTime;
        if (remainingLifeTime <= 0)
        {
            FindObjectOfType<PlayerHealth>().shieldActivated = false;
            Destroy(gameObject);
        }
    }
}

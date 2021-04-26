using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatHandler : MonoBehaviour
{
    private float remainingLifeTime = 5f;

    // Update is called once per frame
    void Update()
    {
        remainingLifeTime -= Time.deltaTime;
        if (remainingLifeTime <= 0)
            Destroy(gameObject);

        transform.position += Vector3.down * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Attacker" && Vector3.SqrMagnitude(transform.position - collision.transform.position) >= 1.0f)
        {
            collision.transform.position = Vector3.Lerp(collision.transform.position, transform.position, 0.05f);
        }
    }
}

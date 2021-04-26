using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneHandler : MonoBehaviour
{
    private float lifeTime = 5f;
    private float remainingLifeTime;
    private float maxScale = 45.0f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        remainingLifeTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(maxScale, maxScale, 0), Time.deltaTime);

        remainingLifeTime -= Time.deltaTime;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, remainingLifeTime / lifeTime);
        if (remainingLifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        if (attacker != null)
        {
            attacker.OnExplosion();
        }
    }
}

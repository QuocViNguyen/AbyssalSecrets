using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] string name = "default name";
    [SerializeField] string description = "default description";
    private Artifact artifact;
    // Start is called before the first frame update
    void Start()
    {
        artifact = new Artifact(name, description);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            artifact = new Artifact(name, description);
            collision.gameObject.GetComponent<PlayerArtifacts>().AddArtifact(artifact);
            gameObject.SetActive(false);
        }
    }
}

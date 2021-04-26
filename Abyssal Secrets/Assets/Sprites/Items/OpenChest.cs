using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenChest : MonoBehaviour
{
    private Artifact artifact;
    [SerializeField] string artifactName = "NoName";
    [SerializeField] string artifactDescription = "NoDrescription";
    // Start is called before the first frame update
    void Start()
    {
        //artifact = artifactPool[GetRandomIndex(artifactPool)];
        artifact = new Artifact(artifactName, artifactDescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerArtifacts>().AddArtifact(artifact);
            gameObject.SetActive(false);
        }
    }
}

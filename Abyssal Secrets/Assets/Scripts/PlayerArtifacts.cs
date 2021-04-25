using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifacts : MonoBehaviour
{
    List<Artifact> Artifacts;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Artifacts = new List<Artifact>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddArtifact(Artifact artifact)
    {
        audioSource.Play();
        Artifacts.Add(artifact);
        Debug.Log(artifact.Name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArtifacts : MonoBehaviour
{
    List<Artifact> Artifacts;
    private  AudioSource audioSource;
    [SerializeField] Text displayerName;
    [SerializeField] Text displayerDesc;
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
        displayerName.text = artifact.Name;
        displayerDesc.text = artifact.Description;
        Artifacts.Add(artifact);
        StartCoroutine(ClearArtifactDisplay());
    }

    private IEnumerator ClearArtifactDisplay()
    {
        yield return new WaitForSeconds(4);
        displayerName.text = "";
        displayerDesc.text = "";
    }
}

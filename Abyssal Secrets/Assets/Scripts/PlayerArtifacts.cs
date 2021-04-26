using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArtifacts : MonoBehaviour
{
    List<Artifact> artifacts;
    private  AudioSource audioSource;
    [SerializeField] Text displayerName;
    [SerializeField] Text displayerDesc;
    [SerializeField] Text artifactTracker;
    [SerializeField] GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        artifacts = new List<Artifact>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (artifacts.Count == 7)
        {
            Time.timeScale = 0;
            AudioManager.Instance.StopPlaying();
            GetComponent<AudioSource>()?.Stop();
            winPanel.SetActive(true);
        }
    }

    public void AddArtifact(Artifact artifact)
    {   
        AudioManager.Instance.PlayOpenChest();
        displayerName.text = artifact.Name;
        displayerDesc.text = artifact.Description;
        artifacts.Add(artifact);
        artifactTracker.text = artifacts.Count.ToString();
        StartCoroutine(ClearArtifactDisplay());
    }

    private IEnumerator ClearArtifactDisplay()
    {
        yield return new WaitForSeconds(5);
        displayerName.text = "";
        displayerDesc.text = "";
    }
}

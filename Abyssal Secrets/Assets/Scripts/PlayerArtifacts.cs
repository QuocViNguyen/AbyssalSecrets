using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArtifacts : MonoBehaviour
{
    List<Artifact> artifacts;
    [SerializeField] Text displayerName;
    [SerializeField] Text displayerDesc;
    [SerializeField] Text artifactTracker;
    [SerializeField] GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        artifacts = new List<Artifact>();
    }

    // Update is called once per frame
    void Update()
    {
        if (artifacts.Count == 7)
        {
            GameManager.Instance.GameStarted = false;
            GetComponent<AudioSource>().Stop();
            AudioManager.Instance.PlayGameOver();
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

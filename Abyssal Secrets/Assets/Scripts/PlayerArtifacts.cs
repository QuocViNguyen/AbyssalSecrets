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
    [SerializeField] ItemManager itemManager;

    private int requiredArtifactCount = 6;

    // Start is called before the first frame update
    void Start()
    {
        artifacts = new List<Artifact>();
    }

    // Update is called once per frame
    void Update()
    {
        if (artifacts.Count == requiredArtifactCount)
        {
            itemManager.EnableRuneSlot();
        }
    }

    public void AddArtifact(Artifact artifact)
    {   
        AudioManager.Instance.PlayOpenChest();
        displayerDesc.transform.parent.gameObject.SetActive(true);
        displayerName.text = artifact.Name;
        displayerDesc.text = artifact.Description;
        artifacts.Add(artifact);
        if (artifacts.Count <= requiredArtifactCount)
        {
            artifactTracker.text = $"{artifacts.Count}/{requiredArtifactCount}";
        }
    }

    public bool IsFullArtifacts()
    {
        return artifacts.Count > requiredArtifactCount;
    }

    public void EndGame()
    {
        GetComponent<AudioSource>()?.Stop();
    }
}

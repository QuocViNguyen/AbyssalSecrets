using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioClip openChest;
    [SerializeField] AudioClip activateShield;
    [SerializeField] AudioClip speedBoost;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySpeedBoost()
    {
        audioSource.PlayOneShot(speedBoost);
    }

    public void PlayShieldActivation()
    {
        audioSource.PlayOneShot(activateShield);
    }

    public void PlayOpenChest()
    {
        audioSource.PlayOneShot(openChest);
    }
}

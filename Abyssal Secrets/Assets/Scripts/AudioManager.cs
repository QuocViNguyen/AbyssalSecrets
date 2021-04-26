using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip stage1;
    [SerializeField] AudioClip stage2;
    [SerializeField] AudioClip stage3;
    [SerializeField] AudioClip boss;
    [SerializeField] AudioClip gameOver;

    [SerializeField] AudioClip openChest;
    [SerializeField] AudioClip mineExplosion;

    [SerializeField] AudioClip activateShield;
    [SerializeField] AudioClip speedBoost;
    [SerializeField] AudioClip itemBought;
    [SerializeField] AudioClip smellyBombExplosion;
    [SerializeField] AudioClip runeExplosion;


    private AudioSource sfxSource;

    private void Awake()
    {
        Instance = this;
        sfxSource = GetComponent<AudioSource>();
    }

    public void PlayStage1()
    {
        musicSource.volume = 1f;
        musicSource.clip = stage1;
        musicSource.Play();
    }

    public void PlayStage2()
    {
        musicSource.volume = 1f;
        PlayMusicWithFade(stage2);
    }

    public void PlayStage3()
    {
        musicSource.volume = 1f;
        PlayMusicWithFade(stage3);
    }

    public void PlayBossStage()
    {
        musicSource.volume = 0.7f;
        PlayMusicWithFade(boss);
    }

    public void StopPlaying()
    {
        musicSource.Stop();
    }

    private void PlayMusicWithFade(AudioClip newClip, float transitionTime = 0.7f)
    {
        if (newClip == musicSource.clip)
            return;

        StartCoroutine(UpdateMusicWithFade(newClip, transitionTime));
    }

    private IEnumerator UpdateMusicWithFade(AudioClip newClip, float transitionTime)
    {
        if (!musicSource.isPlaying)
            musicSource.Play();

        float t;
        for (t = 0.0f; t < transitionTime; t += Time.deltaTime)
        {
            musicSource.volume = 1 - (t / transitionTime);
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.Play();

        for (t = 0.0f; t < transitionTime; t += Time.deltaTime)
        {
            musicSource.volume = t / transitionTime;
            yield return null;
        }
    }

    public void PlaySpeedBoost()
    {
        sfxSource.PlayOneShot(speedBoost);
    }

    public void PlayShieldActivation()
    {
        sfxSource.PlayOneShot(activateShield);
    }

    public void PlayOpenChest()
    {
        sfxSource.PlayOneShot(openChest);
    }

    public void PlayItemBought()
    {
        sfxSource.PlayOneShot(itemBought);
    }

    public void PlayMineExplosion()
    {
        sfxSource.PlayOneShot(mineExplosion);
    }
}

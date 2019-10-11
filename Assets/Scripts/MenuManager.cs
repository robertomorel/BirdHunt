﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    AudioSource audioSource;

    public AudioClip[] clips;
    public Text dataPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(IntroJingle());
        dataPlayer.text = LobbyManager.instance.player.toString();
    }

    private void PlaySound(int sound)
    {
        audioSource.clip = clips[sound];
        audioSource.Play();
    }

    private IEnumerator IntroJingle()
    {
        yield return new WaitForSeconds(3.0f);
        PlaySound(0);
        StartCoroutine(Quack());
    }

    private IEnumerator Quack()
    {
        yield return new WaitForSeconds(1.8f);
        PlaySound(1);
        StartCoroutine(Dog());
    }

    private IEnumerator Dog()
    {
        yield return new WaitForSeconds(0.5f);
        PlaySound(2);
        StartCoroutine(GunShot());
    }

    private IEnumerator GunShot()
    {
        yield return new WaitForSeconds(0.4f);
        PlaySound(3);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main"); 
    }

}

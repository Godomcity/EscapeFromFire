using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public FadeController fadeController;

    AudioSource audioSource;

    [SerializeField] AudioClip easyClip;
    [SerializeField] AudioClip normalClip;
    [SerializeField] AudioClip hardClip;
    [SerializeField] AudioClip button_Click_Clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void callEasyMainScene()
    {
        LevelManager.isEasy = true;
        StartCoroutine(ButtonSound());
    }
    public void callNolamlMainScene()
    {
        LevelManager.isNormal = true;
        StartCoroutine(ButtonSound());
    }

    public void callHardMainScene()
    {
        LevelManager.isHard = true;
        StartCoroutine(ButtonSound());
    }

    public void callTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    IEnumerator ButtonSound()
    {
        audioSource.PlayOneShot(button_Click_Clip);
        fadeController.FadeIn();
        yield return new WaitForSeconds(1.8f);

        if(LevelManager.isEasy == true)
        {
            AudioManager.instance.audioSource.clip = easyClip;
        }
        else if (LevelManager.isNormal == true)
        {
            AudioManager.instance.audioSource.clip = normalClip;
        }
        else
        {
            AudioManager.instance.audioSource.clip = hardClip;
        }

        AudioManager.instance.audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(https://spartacodingclub.kr/);
        #else
            Application.Quit();
        #endif
    }

}

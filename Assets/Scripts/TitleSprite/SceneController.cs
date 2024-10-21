using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public FadeController fadeController;

    AudioSource audioSource;

    [SerializeField] AudioClip button_Click_Clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void callEasyMainScene()
    {
        if (!characterSetting())
        {
            return;
        }
        LevelManager.isEasy = true;
        StartCoroutine(ButtonSound());
    }
    public void callNolamlMainScene()
    {
        if (!characterSetting())
        {
            return;
        }
        LevelManager.isNormal = true;
        StartCoroutine(ButtonSound());
    }

    public void callHardMainScene()
    {
        if (!characterSetting())
        {
            return;
        }
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
            AudioManager.instance.audioSource.clip = AudioManager.instance.easyClip;
        }
        else if (LevelManager.isNormal == true)
        {
            AudioManager.instance.audioSource.clip = AudioManager.instance.normalClip;
        }
        else
        {
            AudioManager.instance.audioSource.clip = AudioManager.instance.hardClip;
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
    private bool characterSetting()
    {
        if (GameManager.Instance.PlayerMode)
        {
            if (GameManager.Instance.player1ChooseCharacter>5)
            {
                return false;
            }
        }
        else if (!GameManager.Instance.PlayerMode)
        {
            if (GameManager.Instance.player1ChooseCharacter>5&&GameManager.Instance.player2ChooseCharacter>5)
            {
                return false;
            }
        }
        if (GameManager.Instance.PlayerMode)
        {
            GameManager.Instance.SelectPlayerHandler.AddSelectData(GameManager.Instance.player1ChooseCharacter);
        }
        else if (!GameManager.Instance.PlayerMode)
        {

            GameManager.Instance.SelectPlayerHandler.AddSelectData(GameManager.Instance.player1ChooseCharacter);
            GameManager.Instance.SelectPlayerHandler.AddSelectData(GameManager.Instance.player2ChooseCharacter);
        }
        Debug.Log(GameManager.Instance.player1ChooseCharacter);
        return true;
    }
}

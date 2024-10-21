using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void HomeButton()
    {
        LevelManager.isEasy = false;
        LevelManager.isNormal = false;
        LevelManager.isHard = false;
        AudioManager.instance.audioSource.clip = AudioManager.instance.clip;
        GameManager.Instance.SelectPlayerHandler.DeleteSelectData();
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
        AudioManager.instance.audioSource.Play();
        Time.timeScale = 1;
    }

    public void RetryButton()
    {
        if (LevelManager.isEasy == true)
        {
            AudioManager.instance.audioSource.clip = AudioManager.instance.easyClip;
            AudioManager.instance.audioSource.Play();
        }
        else if (LevelManager.isNormal == true)
        {
            AudioManager.instance.audioSource.clip = AudioManager.instance.normalClip;
            AudioManager.instance.audioSource.Play();
        }
        else
        {
            AudioManager.instance.audioSource.clip = AudioManager.instance.hardClip;
            AudioManager.instance.audioSource.Play();
        }

        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
            Application.OpenURL(https://nbcamp.spartacodingclub.kr/);
#else
            Application.Quit();
#endif
    }
}

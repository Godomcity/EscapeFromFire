using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] public AudioClip clip;
    [SerializeField] public AudioClip easyClip;
    [SerializeField] public AudioClip normalClip;
    [SerializeField] public AudioClip hardClip;
    [SerializeField] public AudioClip resultClip;

    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

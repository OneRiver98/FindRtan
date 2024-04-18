using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;
    //public AudioClip clip;
    public AudioClip startAudioClip;
    public AudioClip mainAudioClip;
    public AudioClip secondAudioClip;

    public Button OneBtn; // 1번 버튼
    public Button TwoBtn; // 2번 버튼
    public Button TrdBtn; // 3번 버튼

    public AudioClip bgmusic; // 1번 버튼에 연결할 음악 클립
    public AudioClip mario;   // 2번 버튼에 연결할 음악 클립
    public AudioClip marios;  // 3번 버튼에 연결할 음악 클립
    public AudioClip marioBoss; //20초 이후에 나올 음악 클립

    public AudioClip secondBGM;  // 2번째 스테이지 노래


    private void Awake()
     {
         if (instance == null)
         {
             instance = this;
             DontDestroyOnLoad(gameObject);  // AudioManager 게임 오브젝트가 파괴가 안됨 그대로 유지되면서 main으로 넘어감
         }
         else  // 이미 존재할때 즉 새로운 게 생성되려고 할때 instance가 
         {
             Destroy(gameObject);
         }
         
     }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        /**if (SceneManager.GetActiveScene().name == "StartScene")
        {
            // 시작 씬에서는 startAudioClip을 재생
            audioSource.clip = startAudioClip;
            audioSource.Play();

        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            // 메인 씬에서는 mainAudioClip을 재생
            audioSource.clip = mainAudioClip;
            audioSource.Play();

        }
        else if (SceneManager.GetActiveScene().name == "SecondScene")
        {
            // 메인 씬에서는 mainAudioClip을 재생
            audioSource.clip = secondAudioClip;
            audioSource.Play();

        } **/


        // 1번 버튼 클릭 시
        OneBtn.onClick.AddListener(() => PlayMusic(bgmusic));

        // 2번 버튼 클릭 시
        TwoBtn.onClick.AddListener(() => PlayMusic(mario));

        // 3번 버튼 클릭 시
        TrdBtn.onClick.AddListener(() => PlayMusic(marios));
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            // 현재 재생 중인 음악이 있으면 멈추기
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            // 새로운 음악 재생
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


}

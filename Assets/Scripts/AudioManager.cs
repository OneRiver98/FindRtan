using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;
    //public AudioClip clip;
    public AudioClip startAudioClip;
    public AudioClip mainAudioClip;
    public AudioClip secondAudioClip;


    /** private void Awake()
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
         
     }**/

    /** void Start()
     {
         audioSource = GetComponent<AudioSource>();

         audioSource.clip = this.clip;
         audioSource.Play();
     } **/

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "StartScene")
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

        }
    }

    // 스테이지마다 다른 오디오를 재생하는 함수
    public void PlayStageAudio(AudioClip stageAudioClip)
    {
        // 현재 재생 중인 오디오를 중지하고 파괴
        audioSource.Stop();
        Destroy(audioSource.clip);

        // 새로운 오디오 클립을 할당하고 재생
        audioSource.clip = stageAudioClip;
        audioSource.Play();
    }
}

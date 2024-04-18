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
             DontDestroyOnLoad(gameObject);  // AudioManager ���� ������Ʈ�� �ı��� �ȵ� �״�� �����Ǹ鼭 main���� �Ѿ
         }
         else  // �̹� �����Ҷ� �� ���ο� �� �����Ƿ��� �Ҷ� instance�� 
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
            // ���� �������� startAudioClip�� ���
            audioSource.clip = startAudioClip;
            audioSource.Play();

        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            // ���� �������� mainAudioClip�� ���
            audioSource.clip = mainAudioClip;
            audioSource.Play();

        }
        else if (SceneManager.GetActiveScene().name == "SecondScene")
        {
            // ���� �������� mainAudioClip�� ���
            audioSource.clip = secondAudioClip;
            audioSource.Play();

        }
    }

    // ������������ �ٸ� ������� ����ϴ� �Լ�
    public void PlayStageAudio(AudioClip stageAudioClip)
    {
        // ���� ��� ���� ������� �����ϰ� �ı�
        audioSource.Stop();
        Destroy(audioSource.clip);

        // ���ο� ����� Ŭ���� �Ҵ��ϰ� ���
        audioSource.clip = stageAudioClip;
        audioSource.Play();
    }
}

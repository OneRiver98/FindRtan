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

    public Button OneBtn; // 1�� ��ư
    public Button TwoBtn; // 2�� ��ư
    public Button TrdBtn; // 3�� ��ư

    public AudioClip bgmusic; // 1�� ��ư�� ������ ���� Ŭ��
    public AudioClip mario;   // 2�� ��ư�� ������ ���� Ŭ��
    public AudioClip marios;  // 3�� ��ư�� ������ ���� Ŭ��
    public AudioClip marioBoss; //20�� ���Ŀ� ���� ���� Ŭ��

    public AudioClip secondBGM;  // 2��° �������� �뷡


    private void Awake()
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
         
     }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        /**if (SceneManager.GetActiveScene().name == "StartScene")
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

        } **/


        // 1�� ��ư Ŭ�� ��
        OneBtn.onClick.AddListener(() => PlayMusic(bgmusic));

        // 2�� ��ư Ŭ�� ��
        TwoBtn.onClick.AddListener(() => PlayMusic(mario));

        // 3�� ��ư Ŭ�� ��
        TrdBtn.onClick.AddListener(() => PlayMusic(marios));
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            // ���� ��� ���� ������ ������ ���߱�
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            // ���ο� ���� ���
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


}

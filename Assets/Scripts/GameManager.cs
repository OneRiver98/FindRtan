using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip failClip;
    public Text timeTxt;
    public Card firstCard;
    public Card secondCard;
    public GameObject EndTxt;
    public int fullCount;
    int tryMatche;
    public Text tryTxt;
    public GameObject successText;
    public GameObject failText;
    public Camera cameraBackGround;
    int combo;
    public Animator anim;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    float time = 60.0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1.0f;
    }
    private void Update() 
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if(time <= 20.0f)
        {
            timeTxt.color = new Color(1f,0f,0f,1f);
            anim.SetBool("Delay", true);
        }

        if(time <= 0.0f)
        {
            GameOver();
            tryTxt.text = tryMatche + " 번 시도 했지만 실패 입니다.";
        }
    }

    public void isMatched()
    {
        tryMatche++;

        if(firstCard.idx == secondCard.idx)
        {
            combo++;
            if(combo == 2 )
            {
                time += 5.0f;
                combo = 0;
            }
            audioSource.PlayOneShot(clip);
            firstCard.destroyCard();
            secondCard.destroyCard();
            switch(firstCard.idx)
            {
                case 0:
                successText.GetComponent<Text>().text = "주윤님!";
                break;
                case 1:
                successText.GetComponent<Text>().text = "원강님!";
                break;
                case 2:
                successText.GetComponent<Text>().text = "수진님!";
                break;
                case 3:
                successText.GetComponent<Text>().text = "현우님!";
                break;
                case 4:
                successText.GetComponent<Text>().text = "수진님!";
                break;
                case 5:
                successText.GetComponent<Text>().text = "원강님!";
                break;
                case 6:
                successText.GetComponent<Text>().text = "현우님!";
                break;
                case 7:
                successText.GetComponent<Text>().text = "종혁님!";
                break;
            }
            successText.SetActive(true);
            Invoke("closeSuc", 0.4f);

            fullCount -= 2;
            if(fullCount == 0)
            {
                GameOver();
                tryTxt.text = tryMatche + " 번 만에 게임을 클리어 했어요!";
            }
        }
        else
        {
            if(combo>0)
            {
                combo--;
            }
            time -= 1;
            audioSource.PlayOneShot(failClip);
            firstCard.closerCard();
            secondCard.closerCard();
            failText.SetActive(true);
        }
        Invoke("closeFail", 0.4f);
        firstCard = null;
        secondCard = null;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        EndTxt.SetActive(true);
    }

    void closeSuc()
    {
        successText.SetActive(false);
    }
    void closeFail()
    {
        failText.SetActive(false);
    }


//테스트  완 그 자 체
//테스트2 벽

}

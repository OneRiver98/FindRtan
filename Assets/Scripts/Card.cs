using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx;
    public AudioClip clip;
    public AudioSource audioSource;
    public Animator anim;
    public GameObject front;
    public GameObject back;
    public Text clickCountTxt;
    int cardClickCount;
    public SpriteRenderer frontImage;
    public SpriteRenderer backImage;
    private int flippedCardCount = 0;

    public void setting(int abc)
    {
        audioSource = GetComponent<AudioSource>();
        idx = abc; 
        Sprite loadedSprite = Resources.Load<Sprite>($"image{idx}"); // $ {} 중괄호 안에 

        // 스프라이트 크기 설정
        frontImage.transform.localScale = new Vector3(
          frontImage.sprite.bounds.size.x / loadedSprite.bounds.size.x,
           frontImage.sprite.bounds.size.x / loadedSprite.bounds.size.y,
            1f
        );  // 2D 에서 z축 1은 무시

        frontImage.sprite = loadedSprite;
    }
    public void opneCard()
    {
        cardClickCount++;
        clickCountTxt.text = cardClickCount.ToString();
        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpne", true);
        front.SetActive(true);
        back.SetActive(false);

        if(GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.isMatched();
        }
    }

    
    public void destroyCard()
    {
         Invoke("destroyInvoke", 1.0f);
    }
    public void closerCard()
    {
        Invoke("closeCardInvoke", 1.0f);
        flippedCardCount++;
        if (flippedCardCount == 1)
        {
            backImage.color = Color.gray;
        }

        if (flippedCardCount == 2)
        {
            backImage.color = Color.red;
        }

        if (flippedCardCount == 3)
        {
            backImage.color = Color.blue;
        }

        if (flippedCardCount == 4)
        {
            backImage.color = Color.green;
        }

        if (flippedCardCount == 5)
        {
            backImage.color = Color.yellow;
        }

    }

    public void destroyInvoke()
    {
        Destroy(gameObject);
    }
    public void closeCardInvoke()
    {
        anim.SetBool("isOpne",false);
        front.SetActive(false);
        back.SetActive(true);
    }
    //texet
}

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

    public void setting(int abc)
    {
        audioSource = GetComponent<AudioSource>();
        idx = abc; 
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
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
        backImage.color = new Color(162/255f, 162/255f,162/255f,1f);
    }
}

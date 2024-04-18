using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RtryBtn : MonoBehaviour
{
    public void rtry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RRetry()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.secondBGM);
        SceneManager.LoadScene("SecondScene");
    }

    //µåµð¾î..

}

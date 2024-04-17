using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChange : MonoBehaviour
{
    public Camera backGround;
    public void BackGroundExchange()
    {
        float a = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        float c = Random.Range(0f, 1f);
        float d = Random.Range(0f, 1f);

        backGround.backgroundColor = new Color(a, b, c, d);
    }
}

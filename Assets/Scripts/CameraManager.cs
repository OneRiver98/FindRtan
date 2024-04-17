using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
public Camera backGround;
public static CameraManager insTance;
void Awake()
{
    if(insTance == null)
    {
        insTance = this;
        DontDestroyOnLoad(gameObject);
    }

        else
        {
            Destroy(gameObject);
        }

    // 테스트입니다.
}
}

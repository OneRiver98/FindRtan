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

    // �׽�Ʈ�Դϴ�.

    // �׽�Ʈ �ѹ� �� �մϴ�.
  }
}

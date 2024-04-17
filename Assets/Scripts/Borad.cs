using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Collections;
public class Borad : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        int[] ary = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4 ,5 ,5 ,6 ,6 , 7, 7};
        ary = ary.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for(int i = 0; i < 16; i++)
        {
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            GameObject go = Instantiate(card);
            go.transform.position = new Vector2(x,y);
            go.GetComponent<Card>().setting(ary[i]);
            GameManager.Instance.fullCount = ary.Length;
        }
    }
//Texttextet
}

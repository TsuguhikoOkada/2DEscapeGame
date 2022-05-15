using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    /// <summary>
    /// 衝突したとき
    /// </summary>
    /// <param name = "collision"></param>

    void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突した相手にplayerタグが付いてるとき
        if (collision.gameObject.tag == "Player")
        {
            //0.2秒で消える
            Destroy(gameObject, 0.2f);
        }
        else
        {
            Destroy(gameObject, 3.0f);
        }
    }
}


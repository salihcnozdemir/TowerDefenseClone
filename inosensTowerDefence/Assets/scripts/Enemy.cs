using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Fobject;
    int healt = 600;
    public void damage()
    {
        healt -= 50;
        if (healt <= 0)
        {
            Fobject = GameObject.Find("Finish");
            finish s2 = Fobject.GetComponent<finish>();

            s2.coin += 20;
            Destroy(gameObject);
        }
    }
}

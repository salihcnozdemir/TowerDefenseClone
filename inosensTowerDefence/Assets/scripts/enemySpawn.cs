using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enmyPrefab;
    int enemyValue = 5;
    float waitTime=3.3f;

    void Start()
    {
        Invoke("wave", 3);
    }

    public void wave()
    {
        enemyValue += 5;
        waitTime -= 0.2f;
        StartCoroutine(enemyWave());
    }

    IEnumerator enemyWave()
    {
        for (int i = 0; i < enemyValue; i++)
        {
            Instantiate(enmyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
        Invoke("wave",7);
    }
}

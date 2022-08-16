using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finish : MonoBehaviour
{
    public Text lifeText;
    public Text CoinText;
    public int life = 3;
    public int coin;
    public GameObject GOpanel;
    void Start()
    {
        
    }
    void Update()
    {
        lifeText.text =  "Kalan Hak:  " + life;
        CoinText.text = "Altýn :  " + coin;
        if (life <= 0)
        {
            GOpanel.SetActive(true);
            Time.timeScale = 0;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            life--;
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControl : MonoBehaviour
{
    public GameObject TurrentSelectPanel,towerUpgradePanel;
    public bool PanelActive = false;
    public GameObject selectBox,towerPrefab;
    public GameObject Fobject;
    public GameObject selectTower;
    void Start()
    {
      
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Slot")
            {
                newPos();
                Transform objectHit = hit.transform;
                selectBox.transform.position = objectHit.transform.position;
                
                TurrentSelectPanel.SetActive(true);
                TurrentSelectPanel.transform.position = objectHit.transform.position;
            }
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Tower")
            {
                newPos();
                Transform objectHit = hit.transform;
                print(objectHit.transform.position);

                selectTower = hit.transform.gameObject;
                towerUpgradePanel.SetActive(true);
                towerUpgradePanel.transform.position = objectHit.transform.position;
            }
        }
       
    }
    public void btn()
    {
        finish f = Fobject.GetComponent<finish>();

        if (f.coin > 99)
        {
            Instantiate(towerPrefab, TurrentSelectPanel.transform.position, Quaternion.identity);
            newPos();
            f.coin -= 100;
        }
        
    }
    public void upgradeButton()
    {
        finish f = Fobject.GetComponent<finish>();

        if (f.coin > 99)
        {
            Tower t = selectTower.GetComponent<Tower>();
            t.UpgradeTower();
            selectTower.gameObject.tag = "Untagged";
            newPos();
            f.coin -= 100;
        }
    }
    public void newPos()
    {
        towerUpgradePanel.transform.position = new Vector3(100, 1000, 100);
        TurrentSelectPanel.transform.position = new Vector3(100, 1000, 100);
        selectBox.transform.position = new Vector3(100, 1000, 100);
    }
}

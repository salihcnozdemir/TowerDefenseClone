using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {


    public int towerLevel = 1;
    public GameObject firstTower, secondTower;
    public Transform firstTurretRot, secondTurretRot,TurretRot;


    private Transform target;
    private Enemy targetEnemy;

    public float range = 15f;

    public float turnSpeed = 10f;

    public GameObject bullet,bullet2, shootPoint, shootPoint2;
    float fireTime = 1;


    void Start()
    {
        TurretRot = firstTurretRot;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    public void UpgradeTower()
    {
        firstTower.SetActive(false);
        secondTower.SetActive(true);
        TurretRot = secondTurretRot;
        towerLevel = 2;

    }
    void shoot()
    {
        TurretRot.transform.LookAt(target);

        fireTime -= Time.deltaTime;
        if(fireTime <= 0)
        {
            if(towerLevel == 1)
            {
                Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                fireTime = 0.5f;
            }
            else
            {
                Instantiate(bullet2, shootPoint2.transform.position, shootPoint2.transform.rotation);
                fireTime = 0.3f;
            }
        }

    }



    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        shoot();
    }
}
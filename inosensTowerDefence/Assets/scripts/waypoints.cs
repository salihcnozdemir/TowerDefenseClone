using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    public List<Transform> waypointsT;
    int WaypointIndex = 0;
    public float speed = 0.7f;


    void Start()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Way");
        foreach (var item in array)
        {
            waypointsT.Add(item.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        Transform wp = waypointsT[WaypointIndex].transform;
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            transform.position = wp.position;
            WaypointIndex = WaypointIndex + 1;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,wp.position, speed * Time.deltaTime);
            transform.LookAt(wp.position);
        }
    }
}

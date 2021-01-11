using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {

        RayCasting();
    }

    void RayCasting()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Debug.Log("거리 :  " + hit.distance);
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000f, Color.blue);
        }


        switch (hit.distance)
        {
            case 6f: Debug.Log("3점"); break;
            case 4f: Debug.Log("2점"); break;
            case 2f: Debug.Log("1점"); break;
        }


    }



}

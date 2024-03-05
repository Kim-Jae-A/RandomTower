using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTrun : MonoBehaviour
{
    //Transform tr;
    private void Start()
    {
        //tr.rotation = Quaternion.identity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //other.transform.rotation = tr.rotation;
            other.transform.rotation = gameObject.transform.rotation;
        }
    }
}

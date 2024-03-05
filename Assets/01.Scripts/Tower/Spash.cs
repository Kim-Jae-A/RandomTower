using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spash : MonoBehaviour
{
    float dmg;
    public GameObject game;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().hp -= dmg;
            Instantiate(game, transform.position, Quaternion.identity);
        }
    }
    public void SetDMG(float dag)
    {
        dmg = dag;
    }
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}

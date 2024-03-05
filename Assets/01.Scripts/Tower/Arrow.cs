using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    float dmage;
    GameObject obj;
    Vector3 ve;
    public GameObject eff;
    public float speed;
    int atttype;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().hp -= dmage;
            GameObject a = Instantiate(eff, transform.position, eff.transform.rotation);
            if(atttype == 1)
            {
                a.GetComponent<Spash>().SetDMG(dmage);
            }
            Destroy(gameObject);
        }
    }
    public void SetDmage(float dmg,int check)
    {
        dmage = dmg;
        atttype = check;
    }
    void Update()
    {
        if (obj != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, speed * Time.deltaTime);
            ve = obj.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(ve).normalized;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVector(GameObject v)
    {
        obj = v;
    }
}

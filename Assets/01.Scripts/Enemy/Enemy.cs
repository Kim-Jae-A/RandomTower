using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float hp = 2000;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(hp <= 0) 
        {
            GameManager.kill++;
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        EnemyGenerate.mobCheck--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider hpBar;
    Enemy enemy;
    float maxhp;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {      
        enemy = GetComponent<Enemy>();
        maxhp = enemy.hp;
        hpBar.maxValue = maxhp;
        hpBar.value = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = enemy.hp;
    }
    private void OnDestroy()
    {
        if (enemy.hp <= 0f)
        {
            //GameManager.gold += 400;
            GameManager.rare++;
        }
        else
        {
            if(ID == 5)
            {
                GameManager.life -= 50;
            }
            GameManager.life -= 29;
        }
    }
}

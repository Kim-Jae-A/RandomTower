using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
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
            GameManager.gold += 100 * ID;
        }
        else
        {
            GameManager.life -= 19;
        }
    }
}

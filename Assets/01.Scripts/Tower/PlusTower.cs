using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusTower : MonoBehaviour
{
    CreateTower[] cre;
    string[] towern;
    string[] towerc;
    public string towername;
    public string towerclass;
    public int num;
    public GameObject obj;
    void Start()
    {
        cre = GetComponentsInChildren<CreateTower>();
        for(int i = 0; i < cre.Length; i++)
        {
            cre[i].number = i;
        }
        towern = new string[cre.Length];
        towerc = new string[cre.Length];
    }

    public void UpgradeButton()
    {
        obj.SetActive(false);
        for (int i = 0; i < cre.Length; i++)
        {
            towern[i] = cre[i].UnitInFoName();
            towerc[i] = cre[i].UnitInFoclass();
        }

        for (int i = 0;i < towern.Length; i++) 
        {
            if (i != num)
            {
                if(towername == towern[i])
                {
                    if(towerclass == towerc[i] && towerclass != "Eqic")
                    {
                        cre[num].UpGrade();
                        cre[i].check = false;
                        Destroy(cre[i].GetComponentInChildren<Tower>().gameObject);
                        Destroy(cre[i].GetComponentInChildren<Ora>().gameObject);
                        return;
                    }
                }
            }
        }
    }
    public void SellButton()
    {
        obj.SetActive(false);
        cre[num].SellUnit();
    }
}

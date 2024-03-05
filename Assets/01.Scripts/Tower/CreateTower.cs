using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreateTower : MonoBehaviour
{
    public GameObject[] tower;
    public GameObject[] towerMagic;
    public GameObject[] towerRare;
    public GameObject[] towerUnique;
    public GameObject[] towerEqic;
    public GameObject towerinfor;
    public GameObject[] Ora;
    public Text[] text;
    public Text alam;
    public bool check;
    bool[] indexcheck = new bool[8];
    bool[] gunindexcheck = new bool[2];
    int index = 0;
    //int gunin = 0;
    GameObject a, o;
    PlusTower plus;
    public int number;
    private void Start()
    {
        plus = GetComponentInParent<PlusTower>();
    }

    public void SetNum(int num, string name, string tclass)
    {
        plus.num = num;
        plus.towername = name;
        plus.towerclass = tclass;
    }

    public string UnitInFoName()
    {
        if (a != null)
            return a.GetComponent<Tower>().towerName.ToString();
        else
            return "NULL";
    }
    public string UnitInFoclass()
    {
        if (a != null)
            return a.GetComponent<Tower>().towerclass.ToString();
        else
            return "NULL";
    }

    public void UpGrade()
    {
        string check = UnitInFoclass();

        #region �⺻����
        if (check == "Common")
        {
            GameManager.commoncount[(int)a.GetComponent<Tower>().towerName] -= 2;
            if (GameManager.commoncount[(int)a.GetComponent<Tower>().towerName] == 0)
            {
                indexcheck[(int)a.GetComponent<Tower>().towerName] = false;
            }
        }
        else if (check == "Magic")
        {
            if ((int)a.GetComponent<Tower>().towerName == 2)
            {
                GameManager.guncount[0] -= 2;
                if (GameManager.guncount[0] == 0)
                {
                    gunindexcheck[0] = false;
                }
            }
            else if ((int)a.GetComponent<Tower>().towerName == 6)
            {
                GameManager.guncount[1] -= 2;
                if (GameManager.guncount[1] == 0)
                {
                    gunindexcheck[1] = false;
                }
            }
        }
        else if (check == "Rare")
        {
            GameManager.lucky7 -= 2;
        }
        else if (check == "Unique")
        {
            GameManager.unluckisluckcount -= 2;
        }
        #endregion

        Destroy(a); a = null;
        Destroy(o); o = null;
        int random = Random.Range(0, tower.Length);
        if (check == "Common")
        {
            a = Instantiate(towerMagic[random]);
            #region �׳��� �׿���
            if (!GameManager.gun)
            {
                if ((int)a.GetComponent<Tower>().towerName == 2)
                {
                    GameManager.guncount[0]++;

                    /*if (GameManager.guncount[0] >= 0)
                    {
                        if (!gunindexcheck[0])
                        {
                            gunin++;
                            gunindexcheck[0] = true;
                            if (gunin >= 2)
                            {
                                GameManager.gold += 400;
                                GameManager.gun = true;
                            }
                        }
                    }*/

                }
                else if ((int)a.GetComponent<Tower>().towerName == 6)
                {
                    GameManager.guncount[1]++;

                    /*if (GameManager.guncount[1] >= 0)
                    {
                        if (!gunindexcheck[1])
                        {
                            gunin++;
                            gunindexcheck[1] = true;
                            if (gunin >= 2)
                            {
                                GameManager.gold += 400;
                                GameManager.gun = true;
                            }
                        }
                    }*/
                }

            }
            #endregion
        }
        else if (check == "Magic")
        {
            a = Instantiate(towerRare[random]);
            #region ��Ű����
            if (!GameManager.unLuck7)
            {
                GameManager.lucky7++;
                if (GameManager.lucky7 >= 7)
                {
                    GameManager.gold += 300;
                    GameManager.unLuck7 = true;
                    alam.text = $"��Ű����";
                    alam.gameObject.SetActive(true);
                }
            }
            #endregion
        }
        else if (check == "Rare")
        {
            a = Instantiate(towerUnique[random]);
            #region �ǿ ���̴�
            if (!GameManager.unluckisluck)
            {
                GameManager.unluckisluckcount++;
                if (GameManager.unluckisluckcount >= 6)
                {
                    GameManager.gold += 300;
                    GameManager.unluckisluck = true;
                    alam.text = $"�ǿ ���̴�";
                    alam.gameObject.SetActive(true);
                }
            }
            #endregion
        }
        else if (check == "Unique")
        {
            a = Instantiate(towerEqic[random]);
        }
        o = Instantiate(Ora[(int)a.GetComponent<Tower>().towerclass]);
        a.transform.parent = transform;
        o.transform.parent = transform;
        a.transform.localPosition = Vector3.zero;
        o.transform.localPosition = new Vector3(0, 0.1f, 0);
        o.transform.localScale = new Vector3(3, 3, 1);
    }

    public void SellUnit()
    {
        string check1 = UnitInFoclass();
        if (check1 != "Eqic")
        {
            int x = (int)a.GetComponent<Tower>().towerclass * 100;
            check = false;
            Destroy(a); a = null;
            Destroy(o); o = null;
            if (x == 0)
            {
                GameManager.gold += 50;
            }
            else
            {
                GameManager.gold += x;
            }

        }
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (GameManager.CreateCheck)
        {
            if (!check)
            {
                if (GameManager.gold >= 100)
                {
                    GameManager.gold -= 100;
                    int random = Random.Range(0, tower.Length);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (!GameManager.rareOn)
                        {
                            a = Instantiate(tower[random]);
                        }
                        else
                        {
                            a = Instantiate(towerRare[GameManager.raretower]);
                            GameManager.rareOn = false;
                            GameManager.rare--;
                            GameManager.raretower = -1;
                        }
                        o = Instantiate(Ora[(int)a.GetComponent<Tower>().towerclass]);
                        o.transform.parent = hit.transform;
                        a.transform.parent = hit.transform;
                        a.transform.localPosition = Vector3.zero;
                        o.transform.localPosition = new Vector3(0, 0.1f, 0);
                        o.transform.localScale = new Vector3(3, 3, 1);
                        check = true;
                        #region ����� �ݹ�
                        if (!GameManager.vustlr)
                        {
                            if ((int)a.GetComponent<Tower>().towerclass == 0)
                            {
                                GameManager.commoncount[(int)a.GetComponent<Tower>().towerName]++;
                                for (int i = 0; i < 8; i++)
                                {
                                    if (GameManager.commoncount[i] >= 1)
                                    {
                                        if (!indexcheck[i])
                                        {
                                            index++;
                                            indexcheck[i] = true;
                                            if (index >= 8)
                                            {
                                                GameManager.gold += 300;
                                                GameManager.vustlr = true;
                                                alam.text = $"����� �ݹ�";
                                                alam.gameObject.SetActive(true);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        else
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    Debug.Log("��� ����");
                }
            }
            else
            {
                towerinfor.SetActive(true);
                Debug.Log("�̹� Ÿ���� �ֽ��ϴ�.");
                plus.num = number;
                SetNum(number, a.GetComponent<Tower>().towerName.ToString(), a.GetComponent<Tower>().towerclass.ToString());
                text[0].text = $"{a.GetComponent<Tower>().towerName}";
                text[1].text = a.GetComponent<Tower>().towerclass.ToString();
                text[2].text = $"���� ������ : {a.GetComponent<Tower>().attDeley}";
                text[3].text = $"������ : {a.GetComponent<Tower>().dmage} + {a.GetComponent<Tower>().upDmage * GameManager.UpGradeCheck(a.GetComponent<Tower>().towerName)}";
                text[4].text = $"��ȭ��ġ : {GameManager.UpGradeCheck(a.GetComponent<Tower>().towerName)}";
            }
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerate : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] mission;
    int maxGenerate;
    public static int now;
    float timer;
    public static bool GenFinsh;
    public static int mobCheck;
    int boss;
    public Button[] but;
    public int nowch;

    // Start is called before the first frame update
    void Start()
    {
        maxGenerate = 50;
        now = 0;
        timer = 1;
        boss = 0;
        but[0].onClick.AddListener(delegate { MissionMob(0); });
        but[1].onClick.AddListener(delegate { MissionMob(1); });
        but[2].onClick.AddListener(delegate { MissionMob(2); });
    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(mobCheck < 0)
        {
            mobCheck = 0;
        }
        nowch = mobCheck;
        timer = timer + Time.deltaTime;
        if(GameManager.round >= 50)
        {
            return;
        }
        if (!GenFinsh)
        {
            if (timer >= 0.5f)
            {
                if (now < maxGenerate)
                {
                    if (GameManager.round != 9 + boss)// || GameManager.round != 19 || GameManager.round != 29 || GameManager.round != 39 || GameManager.round != 49)
                    {
                        GameObject a = Instantiate(enemy[GameManager.round]);
                        a.transform.position = gameObject.transform.position;
                        now++;
                        mobCheck++;
                        timer = 0;
                    }
                    else
                    {
                        GameObject a = Instantiate(enemy[GameManager.round]);
                        a.transform.position = gameObject.transform.position;
                        now = 50;
                        mobCheck++;
                        boss += 10;
                    }
                }
                else
                {
                    GenFinsh = true;
                }
            }
        }
    }
    public void MissionMob(int num)
    {
        GameObject a = Instantiate(mission[num]);
        a.transform.position = gameObject.transform.position;
        mobCheck++;
        but[num].interactable = false;
        StartCoroutine(CoolTime(num));
    }
    IEnumerator CoolTime(int num)
    {
        yield return new WaitForSeconds(300);
        but[num].interactable = true;
    }
}

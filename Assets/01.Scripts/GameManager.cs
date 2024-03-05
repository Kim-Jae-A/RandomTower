using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static TowerInterface;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Text lifetext;
    public Text goldtext;
    public Text gastext;
    public Text timertext;
    public Text roundtext;
    public Text killtext;
    public Image upgradepanel;
    public GameObject towerbulid;
    public GameObject speedpanel;
    public GameObject missionpanel;
    public GameObject settingpanel;
    public GameObject unitinfo;
    public GameObject costinfo;
    public GameObject rareTowerSelet;
    public Button rareButton;
    public Image[] misImage;
    public Text alamtext;
    public Text raretext;
    bool missioncheck;
    bool settingcheck;
    bool speedcheck;
    bool upcheck;
    public static bool raretowercheck;
    float timer;
    bool goldCheck;
    public bool test;
    int timescale;
    public int lastround;
    int killmoney = 1;
    public bool panelCheck;

    #region 미션
    public static bool vustlr;
    public static bool gun;
    public static bool unLuck7;
    public static bool unluckisluck;
    public static int unluckisluckcount;
    #endregion

    public static int life;
    public static int gold;
    public static int gas;
    public static int round;
    public static bool CreateCheck;
    public static int rare; // 레어타워 선택권
    public static int raretower = -1; // 레어타워 정보
    public static bool rareOn;
    public static int lucky7;
    public static int kill;
    bool hellFire;
    

    public static int[] typename = new int[8];
    public static int[] upcost = new int[8];
    public static int[] commoncount = new int[8];
    public static int[] guncount = new int[2];

    bool[] killmission = new bool[4];

    ColorBlock colorBlock;
    Vector3 vec;
    RectTransform rect;

    void Start()
    {
        colorBlock = rareButton.colors;       
        life = 50;
        gold = 400;
        gas = 0;
        timer = 20;
        round = 0;
        roundtext.text = $"{round + 1}라운드";
        timescale = 1;
        lastround = 49;
        for (int i = 0; i < upcost.Length; i++)
        {
            typename[i] = 0;
            upcost[i] = 20;
        }
        timertext.gameObject.SetActive(false);
        rect = towerbulid.GetComponent<RectTransform>();
    }

    public static int UpGradeCheck(TowerName towerName)
    {
        int up = 0;
        switch (towerName)
        {
            case TowerName.ElfShotter:
                up = typename[(Int16)TowerName.ElfShotter];
                break;
            case TowerName.ElfMagician:
                up = typename[(Int16)TowerName.ElfMagician];
                break;
            case TowerName.HumanGunner:
                up = typename[(Int16)TowerName.HumanGunner];
                break;
            case TowerName.HumanWarrior:
                up = typename[(Int16)TowerName.HumanWarrior];
                break;
            case TowerName.DevilShotter:
                up = typename[(Int16)TowerName.DevilShotter];
                break;
            case TowerName.DevilMagician:
                up = typename[(Int16)TowerName.DevilMagician];
                break;
            case TowerName.Robat:
                up = typename[(Int16)TowerName.Robat];
                break;
            case TowerName.Mutant:
                up = typename[(Int16)TowerName.Mutant];
                break;
        }
        return up;
    }
    public static void UpGrade(TowerName towerName)
    {
        switch (towerName)
        {
            case TowerName.ElfShotter:
                typename[(Int16)TowerName.ElfShotter] += 1;
                upcost[(Int16)TowerName.ElfShotter] += 2;
                break;
            case TowerName.ElfMagician:
                typename[(Int16)TowerName.ElfMagician] += 1;
                upcost[(Int16)TowerName.ElfMagician] += 2;
                break;
            case TowerName.HumanGunner:
                typename[(Int16)TowerName.HumanGunner] += 1;
                upcost[(Int16)TowerName.HumanGunner] += 2;
                break;
            case TowerName.HumanWarrior:
                typename[(Int16)TowerName.HumanWarrior] += 1;
                upcost[(Int16)TowerName.HumanWarrior] += 2;
                break;
            case TowerName.DevilShotter:
                typename[(Int16)TowerName.DevilShotter] += 1;
                upcost[(Int16)TowerName.DevilShotter] += 2;
                break;
            case TowerName.DevilMagician:
                typename[(Int16)TowerName.DevilMagician] += 1;
                upcost[(Int16)TowerName.DevilMagician] += 2;
                break;
            case TowerName.Robat:
                typename[(Int16)TowerName.Robat] += 1;
                upcost[(Int16)TowerName.Robat] += 2;
                break;
            case TowerName.Mutant:
                typename[(Int16)TowerName.Mutant] += 1;
                upcost[(Int16)TowerName.Mutant] += 2;
                break;

        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelCheck)
            {
                speedpanel.gameObject.SetActive(false);
                speedcheck = false;
                upgradepanel.gameObject.SetActive(false);
                upcheck = false;
                missionpanel.gameObject.SetActive(false);
                missioncheck = false;
                rareTowerSelet.gameObject.SetActive(false);
                raretowercheck = false;
                CreateCheck = false;
                costinfo.SetActive(false);
                unitinfo.SetActive(false);
                panelCheck = false;           
            }
            else
            {
                settingcheck = !settingcheck;
                CreateCheck = false;
                settingpanel.SetActive(settingcheck);
                costinfo.SetActive(false);
                unitinfo.SetActive(false);
                if (settingcheck)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = timescale;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CreatButton();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpButton();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MissionPanelOn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpeedPanelOn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RareTowerSelet();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GasChange();
        }

        if (EnemyGenerate.GenFinsh)
        {        
            if (EnemyGenerate.mobCheck <= 0)
            {
                timertext.gameObject.SetActive(true);
                timer = timer - Time.deltaTime;
                timertext.text = timer.ToString("#");
                if (!goldCheck)
                {
                    gold += 200;
                    goldCheck = true;
                }
                if (timer <= 0)
                {
                    EnemyGenerate.GenFinsh = false;
                    timertext.gameObject.SetActive(false);
                    timer = 20;
                    if (round <= lastround)
                    {
                        round += 1;
                        roundtext.text = $"{round + 1}라운드";
                    }
                    EnemyGenerate.now = 0;
                    EnemyGenerate.mobCheck = 0;
                    goldCheck = false;
                }
            }          
        }
        if (CreateCheck)
        {
            towerbulid.gameObject.SetActive(true);
            panelCheck = true;
            vec = Input.mousePosition;
            rect.position = vec + (new Vector3(110, -110, 0));
        }
        else
        {
            towerbulid.gameObject.SetActive(false);
            //panelCheck = false;
        }
        lifetext.text = $"{life}";
        goldtext.text = $"{gold}";
        gastext.text = $"{gas}";
        killtext.text = $"{kill}킬";
        raretext.text = $"{rare}";
        if (vustlr)
        {
            misImage[0].gameObject.SetActive(true);
        }
        if (guncount[0] >= 1)
        {
            if (guncount[1] >= 1)
            {
                if (!gun)
                {
                    gold += 400;
                    gun = true;
                    alamtext.text = $"총잡이들";
                    alamtext.gameObject.SetActive(true);
                }
            }
        }
        if (gun)
        {
            misImage[1].gameObject.SetActive(true);
        }
        if (unLuck7)
        {
            misImage[2].gameObject.SetActive(true);
        }
        if (rareOn)
        {
            colorBlock.normalColor = Color.blue;
            rareButton.colors = colorBlock;
        }
        else
        {
            colorBlock.normalColor = Color.white;
            rareButton.colors = colorBlock;
        }
        if (life <= 0)
        {
            GameOver();
        }
        if (kill > 450 * killmoney)
        {
            if (killmoney == 1)
            {

                if (!killmission[0])
                {
                    alamtext.text = $"꽤 하는놈";
                    alamtext.gameObject.SetActive(true);
                    killmission[0] = true;
                    gold += 200;
                }
            }
            else if (killmoney == 2)
            {
                if (!killmission[1])
                {
                    alamtext.text = $"고수의 경지";
                    alamtext.gameObject.SetActive(true);
                    killmission[1] = true;
                    gold += 300;
                }
            }
            else if (killmoney == 3)
            {

                if (!killmission[2])
                {
                    alamtext.text = $"클리어가 목전";
                    gold += 400;
                    alamtext.gameObject.SetActive(true);
                    killmission[2] = true;
                }
            }
            killmoney++;
        }
        if(!hellFire)
        {
            if(life <= 10)
            {
                gas += 400;
                alamtext.text = $"지옥불";
                alamtext.gameObject.SetActive(true);
                hellFire = true;
            }
        }
    }
    public void UpButton()
    {
        upcheck = !upcheck;
        upgradepanel.gameObject.SetActive(upcheck);
        if (panelCheck)
        {
            panelCheck = false;
        }
        else
        {
            panelCheck = true;
        }
        //panelCheck = upcheck;
        CreateCheck = false;
        panelCheck = upcheck;
        missionpanel.gameObject.SetActive(false);
        missioncheck = false;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
        rareTowerSelet.gameObject.SetActive(false);
        raretowercheck = false;
    }
    public void GasChange()
    {
        if (gold >= 100)
        {
            CreateCheck = false;
            gold -= 100;
            int random = Random.Range(1, 6);
            gas += 20 * random;
        }
    }
    public void CreatButton()
    {
        CreateCheck = !CreateCheck;
        panelCheck = CreateCheck;
    }
    public void SpeedPanelOn()
    {
        speedcheck = !speedcheck;
        speedpanel.gameObject.SetActive(speedcheck);
        panelCheck = speedcheck;
        CreateCheck = false;
        missionpanel.gameObject.SetActive(false);
        missioncheck = false;
        upgradepanel.gameObject.SetActive(false);
        upcheck = false;
        rareTowerSelet.gameObject.SetActive(false);
        raretowercheck = false;
    }
    public void MissionPanelOn()
    {
        missioncheck = !missioncheck;
        missionpanel.gameObject.SetActive(missioncheck);
        panelCheck = missioncheck;
        CreateCheck = false;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
        upgradepanel.gameObject.SetActive(false);
        upcheck = false;
        rareTowerSelet.gameObject.SetActive(false);
        raretowercheck = false;
    }
    public void RareTowerSelet()
    {
        raretowercheck = !raretowercheck;
        rareTowerSelet.gameObject.SetActive(raretowercheck);
        panelCheck = raretowercheck;
        CreateCheck = false;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
        upgradepanel.gameObject.SetActive(false);
        upcheck = false;
        missionpanel.gameObject.SetActive(false);
        missioncheck = false;
    }
    public void OnChick1x()
    {
        Time.timeScale = 1;
        timescale = 1;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
    }
    public void OnChick2x()
    {
        Time.timeScale = 2;
        timescale = 2;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
    }
    public void OnChick3x()
    {
        Time.timeScale = 3;
        timescale = 3;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
    }
    public void GameOut()
    {
        Application.Quit();
    }
    void GameOver()
    {
        Time.timeScale = 0;
        panelCheck = false;
        speedpanel.gameObject.SetActive(false);
        speedcheck = false;
        upgradepanel.gameObject.SetActive(false);
        upcheck = false;
        missionpanel.gameObject.SetActive(false);
        missioncheck = false;
        CreateCheck = false;
        unitinfo.SetActive(false);
        settingpanel.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        life = 50;
        gold = 400;
        gas = 0;
        round = 0;
        kill = 0;
        EnemyGenerate.now = 0;      
        EnemyGenerate.mobCheck = 0;
        EnemyGenerate.GenFinsh = false;
        typename = new int[8];
        upcost = new int[8];
        commoncount = new int[8];
        guncount = new int[2];
        lucky7 = 0;
        vustlr = false;
        gun = false;
        unLuck7 = false;
        unluckisluck = false;
        raretower = -1;
        hellFire = true;
        rare = 0;
        raretower = 0;
        rareOn = false;
        unluckisluckcount = 0;
        misImage[0].gameObject.SetActive(false);
        misImage[1].gameObject.SetActive(false);
        misImage[2].gameObject.SetActive(false);  
        Time.timeScale = 1;
    }
}

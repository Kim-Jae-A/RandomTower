using System;
using UnityEngine;

public class Tower : MonoBehaviour, TowerInterface
{
    [Header("À¯´Ö Á¤º¸")]
    public TowerInterface.AttackType attackType;
    public TowerInterface.TowerClass towerclass;
    public TowerInterface.TowerName towerName;
    [Header("Åõ»çÃ¼")]
    public GameObject arrow;
    [Header("À¯´Ö ½ºÅÝ")]
    public float range;
    public float attDeley;
    public float dmage;
    public float upDmage;

    [Header("Å¸°ÙÆÃ")]
    public LayerMask layer;
    public Collider[] colliders;
    public Collider short_enemy;

    Animator animator;
    float timer = 0;
    Vector3 ve;
    CreateTower create;
    SoundManager soundManager;


    // Start is called before the first frame update
    void Start()
    {
        //range = 5;
        //attDeley = 1f;
        //dmage = 10;
        soundManager = GameObject.FindWithTag("Sound").GetComponent<SoundManager>();
        animator = GetComponent<Animator>();
        create = GetComponentInParent<CreateTower>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= attDeley)
        {
            if (short_enemy != null)
            {
                ve = short_enemy.gameObject.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(ve).normalized;
                Attack();
                timer = 0;
            }
        }
        if (short_enemy == null)
        {
            animator.SetBool("isAttack", false);
        }

        colliders = Physics.OverlapSphere(transform.position, range, layer);
        if (colliders.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            short_enemy = colliders[0];
            if (short_enemy == null)
            {
                foreach (Collider col in colliders)
                {
                    float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                    if (short_distance > short_distance2)
                    {
                        short_distance = short_distance2;
                        short_enemy = col;
                    }
                }
            }
            if (short_distance > range)
            {
                short_enemy = null;
            }
        }
    }
    void Attack()
    {
        GameObject a = Instantiate(arrow);
        a.GetComponent<Arrow>().SetDmage(DPS(), (Int16)attackType);
        a.transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        a.GetComponent<Arrow>().SetVector(short_enemy.gameObject);
        SEF();
        animator.SetBool("isAttack", true);
    }
    float DPS()
    {
        return dmage + (upDmage * GameManager.UpGradeCheck(towerName));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            create.towerinfor.SetActive(true);
            create.SetNum(create.number, towerName.ToString(), towerclass.ToString());
            create.text[0].text = $"{towerName}";
            create.text[1].text = towerclass.ToString();
            create.text[2].text = $"°ø°Ý µô·¹ÀÌ : {attDeley}";
            create.text[3].text = $"µ¥¹ÌÁö : {dmage} + {upDmage * GameManager.UpGradeCheck(towerName)}";
            create.text[4].text = $"°­È­¼öÄ¡ : {GameManager.UpGradeCheck(towerName)}";
        }
    }

    void SEF()
    {
        switch ((int)towerName)
        {
            case 0: // ¿¤ÇÁ½´ÅÍ
                soundManager.SEFClip(6);
                break;
            case 1: // ¿¤ÇÁ¹ý»ç
                soundManager.SEFClip(2);
                break;
            case 2: // ÀÎ°£°Å³Ê
                soundManager.SEFClip(4);
                break;
            case 3: // ÀÎ°£Àü»ç
                soundManager.SEFClip(1);
                break;
            case 4: // ¾Ç¸¶¹ý»ç
                soundManager.SEFClip(0);
                break;
            case 5: // ¾Ç¸¶½´ÅÍ
                soundManager.SEFClip(7);
                break;
            case 6: // ¸ÞÄ«´Ð
                soundManager.SEFClip(4);
                break;
            case 7: // ¹ÂÅÏÆ®
                soundManager.SEFClip(3);
                break;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class RareTowerSelet : MonoBehaviour
{
    public TowerInterface.TowerName towerName;
    public GameObject info;
    Button but;
    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (GameManager.raretower != (int)towerName)
        {
            if (GameManager.rare > 0)
            {
                GameManager.rareOn = true;
                GameManager.raretower = (int)towerName;
            }
        }
        else
        {
            GameManager.rareOn = false;
        }
        info.SetActive(false);
        GameManager.raretowercheck = false;
    }
}

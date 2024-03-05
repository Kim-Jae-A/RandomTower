using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradTower : MonoBehaviour
{
    public TowerInterface.TowerName towerName;
    Button but;
    EventTrigger trigger;
    public GameObject obj;
    public GameObject info;
    public Text gastext;
    public Text uptext;
    Vector3 vet;
    RectTransform rect;
    

    private void Start()
    {
        trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnMouseEnterTriger((PointerEventData)data); });
        trigger.triggers.Add(entry);
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerExit;
        entry1.callback.AddListener((data) => { OnMouseExitTriger((PointerEventData)data); });
        trigger.triggers.Add(entry1);
        rect = obj.GetComponent<RectTransform>();
        but = GetComponent<Button>();
        but.onClick.AddListener(OnClickButton);
    }
    
    public void OnMouseEnterTriger(PointerEventData data)
    {
        vet = Input.mousePosition;
        gastext.text = $"{GameManager.upcost[(Int16)towerName]}";
        uptext.text = $"현재강화 {GameManager.UpGradeCheck(towerName)}";
        rect.position = vet + (new Vector3(110, -110, 0));
        obj.SetActive(true);
    }
    public void OnMouseExitTriger(PointerEventData data)
    {
        obj.SetActive(false);
    }


    void OnClickButton()
    {
        if (GameManager.upcost[(Int16)towerName] <= GameManager.gas)
        {
            GameManager.gas -= GameManager.upcost[(Int16)towerName];
            GameManager.UpGrade(towerName);
            gastext.text = $"{GameManager.upcost[(Int16)towerName]}";
            uptext.text = $"현재강화 {GameManager.UpGradeCheck(towerName)}";
            info.SetActive(false);
            //obj.SetActive(false);
            //GameManager.panelCheck = false;
        }
        else
        {
            Debug.Log("Gas 부족");
        }
    }  
}

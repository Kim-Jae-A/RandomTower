using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InforClose : MonoBehaviour
{
    public GameObject obj;

    public void OFF()
    {
        obj.SetActive(false);
    }
}

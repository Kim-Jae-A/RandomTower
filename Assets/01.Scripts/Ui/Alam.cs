using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alam : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("SetFalse", 5f);
    }
    
    void SetFalse()
    {
        gameObject.SetActive(false);
    }
}

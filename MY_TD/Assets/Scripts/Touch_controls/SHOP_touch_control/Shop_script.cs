using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_script : MonoBehaviour
{
    public static Shop_script instance;

    void Awake()
    {
        instance = this;
        instance.gameObject.SetActive(false);   
    }

    public void Activate()
    {
        instance.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        instance.gameObject.SetActive(false);
    }

}

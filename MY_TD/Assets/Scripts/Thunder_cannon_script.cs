using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_cannon_script : MonoBehaviour
{
    public GameObject thunder_ui;

    void OnMouseDown()//you have to be careful about ui
    {
        if (thunder_ui.activeSelf == false)
            thunder_ui.SetActive(true);
        else
            thunder_ui.SetActive(false);
    }


}

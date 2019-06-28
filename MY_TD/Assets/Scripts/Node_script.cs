using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_script : MonoBehaviour
{
    public static Shop_script shop_instance = Shop_script.instance;
    public static Transform last_turret_place;
    public static Vector3 pos;
    public bool is_build = false;

    void OnMouseDown()
    {
        if (Shop_script.instance.gameObject.activeSelf == true)
        {
            Shop_script.instance.gameObject.SetActive(false);
        }
        else
        {
            Shop_script.instance.gameObject.SetActive(true);
            GAME_MASTER.last_node = gameObject;
            pos = gameObject.transform.position;
            pos.z += -1f;
        }
    }


    
}

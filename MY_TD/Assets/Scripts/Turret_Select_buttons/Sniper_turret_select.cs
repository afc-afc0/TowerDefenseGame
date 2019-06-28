using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_turret_select : MonoBehaviour
{
    
    public GameObject turret_to_buid_prefab;
    public static Shop_script shop_instance = Shop_script.instance;
    private Quaternion rot;
    private int turret_price = 60;

    /*void OnMouseDown()
    {
        Debug.Log("geldi");
        Instantiate(turret_to_buid_prefab, Node_script.last_turret_place);
        Shop_script.instance.gameObject.SetActive(false);
    }*/

    public void Build_Turret()
    {

        if (GAME_MASTER.last_node.GetComponent<Node_script>().is_build == false && GAME_MASTER.money >= 60)
        { 
            rot.Set(0f, 0f, 0f, 0f);
            GAME_MASTER.money -= turret_price;
            Instantiate(turret_to_buid_prefab, Node_script.pos, rot);
            Shop_script.instance.gameObject.SetActive(false);
            GAME_MASTER.last_node.GetComponent<Node_script>().is_build = true;
        }
        else
        {
            Shop_script.instance.gameObject.SetActive(false);
            Debug.Log("Turret HERE!");
        }
    }
    
}

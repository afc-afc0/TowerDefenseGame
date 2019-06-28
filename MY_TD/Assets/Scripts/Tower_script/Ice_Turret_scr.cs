using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Turret_scr : MonoBehaviour
{
    public float slow_down_speed = 0.2f;
    public string enemy_tag = "enemy";

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == enemy_tag)
        {
            if (col.gameObject.GetComponent<Enemy_script>().is_slowed == false)
            {
                col.gameObject.GetComponent<Enemy_script>().speed -= slow_down_speed;
                col.gameObject.GetComponent<Enemy_script>().is_slowed = true;                    
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == enemy_tag)
        {
            col.gameObject.GetComponent<Enemy_script>().speed += slow_down_speed;
        }
    }

}

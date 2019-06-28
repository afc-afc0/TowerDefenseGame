using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_ice_turret_scr : MonoBehaviour
{
    private GameObject[] enemies;
    private string enemy_tag = "enemy";
    public float slow_down_speed = 0.4f;
    
    void OnMouseDown()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        Debug.Log("Activated");
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<Enemy_script>().is_slowed != true)
            {
                enemy.GetComponent<Enemy_script>().speed -= slow_down_speed;
            }
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        foreach(GameObject enem in enemies)
        {
            if(enem != null) 
            {
                enem.GetComponent<Enemy_script>().speed += slow_down_speed;
            }
        }
    }



}

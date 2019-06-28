using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan_tower_scr : MonoBehaviour
{
    private SphereCollider my_collider;
    private int damage = 20;
    public float price_vulcan = 100f;

    List<Enemy_script> enemies = new List<Enemy_script>();    

    public string enemy_tag = "enemy";


    void OnTriggerEnter(Collider enem)
    {
        Enemy_script enemy = enem.GetComponent<Enemy_script>();
        enemy.Hit_repeating(true);
    }

    void OnTriggerExit(Collider enem)
    {
        Enemy_script enemy = enem.GetComponent<Enemy_script>();
        enemy.Hit_repeating(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher_scr : MonoBehaviour
{

    public string enemy_tag = "enemy";
    private Transform target;

    Enemy_script test;  
    Queue<Enemy_script> enemies = new Queue<Enemy_script>();
    public GameObject bullet_prefab;

    void Start()
    {
        InvokeRepeating("TargetUpdate", 0, 0.1f);
        InvokeRepeating("Shoot", 0, 0.5f);
    }

    void Shoot()
    {
        if (target != null)
        {
            GameObject bulletGo = (GameObject)Instantiate(bullet_prefab, gameObject.transform.position, gameObject.transform.rotation);
            Missile_scr bulletscr = bulletGo.GetComponent<Missile_scr>();

            bulletscr.Ara(target);
        }
    }


    void TargetUpdate()
    {

        if (target == null && enemies.Count > 0)
        {
            target = enemies.Dequeue().transform;
        }
    }


    void OnTriggerEnter(Collider enem)
    {
        if (enem.tag == enemy_tag)
        {
            enemies.Enqueue(enem.GetComponent<Enemy_script>());
        }
    }

    void OnTriggerExit(Collider enem)
    {
        if (target.tag == enemy_tag)
        {
            target = null;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple_take_turret_scr : MonoBehaviour
{
    public string enemy_tag = "enemy";
    private Transform target;
    public int price_triple_fire = 60;
    Enemy_script test;
    Queue<Enemy_script> enemies = new Queue<Enemy_script>();
    public GameObject bullet_prefab;

    void Start()
    {
        InvokeRepeating("TargetUpdate", 0, 0.1f);
    }

    void Update()
    {
        Shoot();
        TargetUpdate();
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        if (target != null)
        {
            GameObject bulletGo = (GameObject)Instantiate(bullet_prefab, gameObject.transform.position, gameObject.transform.rotation);
            Bullet_script bulletscr = bulletGo.GetComponent<Bullet_script>();

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
        if (enem.CompareTag(enemy_tag))
        {
            Debug.Log("new enemy");
            enemies.Enqueue(enem.GetComponent<Enemy_script>());
        }
    }

    void OnTriggerExit(Collider enem)
    {
        if (enem.CompareTag(enemy_tag))
        {
            target = null;
        }
    }
}

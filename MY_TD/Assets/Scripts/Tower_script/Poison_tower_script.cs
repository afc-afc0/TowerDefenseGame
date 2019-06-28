using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_tower_script : MonoBehaviour
{
    public int hit_count = 4;
    public float range = 5f;

    public float fire_rate = 0.75f;

    public string enemy_tag = "enemy";
    public Transform target;
    public float turn_speed = 10f;
    private float fire_count_down = 0f;
    public GameObject bullet_prefab;

    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void Fire()
    {
        GameObject Bullet_GO = (GameObject)Instantiate(bullet_prefab, gameObject.transform.position, gameObject.transform.rotation);
        Poison_bullet_script bullet = Bullet_GO.GetComponent<Poison_bullet_script>();

        if (bullet != null)
        {
            bullet.Ara(target);
        }
    }

    void Update()
    {
        if (target == null)
            return;

        if (fire_count_down <= 0)
        {
            Fire();
            fire_count_down = 1f / fire_rate;
        }
        fire_count_down -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        float shortest_dis = Mathf.Infinity;
        GameObject closest_enemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance_to_enemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance_to_enemy < shortest_dis)
            {
                shortest_dis = distance_to_enemy;
                closest_enemy = enemy;
            }
        }
        if (closest_enemy != null && shortest_dis <= range)
        {
            target = closest_enemy.transform;
        }
        else
        {
            target = null;
        }

    }

    






}

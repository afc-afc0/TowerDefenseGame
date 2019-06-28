using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_turret_script : MonoBehaviour
{
    public float damage;
    private SphereCollider my_collider;

    public string enemy_tag = "enemy";

    void Start()
    {
        InvokeRepeating("Enemy_in_range", 0f, 0.05f);
        my_collider = gameObject.GetComponent<SphereCollider>();
        my_collider.center = gameObject.transform.position;
    }

    void Enemy_in_range()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(my_collider.center, enemy.transform.position) <= my_collider.radius)
            {
                Destroy(enemy);
                return;
            }
        }
    }
}

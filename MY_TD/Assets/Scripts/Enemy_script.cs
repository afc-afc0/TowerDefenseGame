using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_script : MonoBehaviour
{
    public float speed = 10f;
    public float health = 200f;
    public bool is_slowed = false;
    public bool is_poisened = false;

    [Header("Privates")]

    private Vector3 temp;
    private Transform target;
    private int transform_index = 0;
    private int points_length;
    private float area_damage = 10f;
    private Vector3 dir;

    void Start()
    {
        points_length = Waypoint_script.points.Length;
        target = Waypoint_script.points[0];
        dir = target.position - transform.position;
    }



    void Update()
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2)
        {
            Get_waypoint();
        }
    }



    void Get_waypoint()
    {
        if (transform_index >= points_length - 1)
        {
            Destroy(gameObject);
            return;
        }

        transform_index++;
        target = Waypoint_script.points[transform_index];
        dir = target.position - transform.position;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.GetComponentInChildren<Health_bar_scr>().RResize(health);
    }

    void Hasar()
    {
        GetDamage(area_damage);
    }


    public void Hit_repeating(bool attack)
    {
        if (attack)
        {
            InvokeRepeating("Hasar", 0f, 0.5f);
        }
        else if (!attack)
        {
            CancelInvoke("Hasar");
        }
    }


}
/*
 * 
 * public class Enemy_script : MonoBehaviour
{
    public float speed = 10f;
    public float health = 200f;
    public bool is_slowed = false;
    public bool is_poisened = false;

    [Header("Privates")]

    private Vector3 temp;
    private Transform target;
    private int transform_index = 0;
    private int points_length;
    private float area_damage = 10f;
    
    void Start()
    {
        points_length = Waypoint_script.points.Length; 
        target =  Waypoint_script.points[0];
    }

   

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,target.position) <= 0.2)
        {
            Get_waypoint();
        }
    }

    

    void Get_waypoint()
    {
        if(transform_index >= points_length - 1)
        {
            Destroy(gameObject);
            return;
        }

        transform_index++;
        target = Waypoint_script.points[transform_index];
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.GetComponentInChildren<Health_bar_scr>().RResize(health);
    }
 
    void Hasar()
    {
        GetDamage(area_damage);
    }
   

    public void Hit_repeating(bool attack)
    {
        if(attack)
        {
            InvokeRepeating("Hasar",0f,0.5f);
        }
        else if(!attack)
        {
            CancelInvoke("Hasar");
        }
    }

    
}
*/

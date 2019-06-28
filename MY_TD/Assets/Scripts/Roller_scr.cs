using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller_scr : MonoBehaviour
{

    private string enemy_tag = "enemy";
    private string waypoint_tag = "way_point";
    public float damage = 10;
    private int points_length;
    private Transform target;
    private float speed = 14f;


    void Start()
    {
        points_length = Waypoint_script.points.Length;
        target = Waypoint_script.points[points_length - 1];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) <= 0.2)
        {
            GetWayPoint();
        }
    }

    void OnTriggerEnter(Collider enem)
    {
        Debug.Log("hit");
        if(enem.CompareTag("enemy"))
        {
            enem.GetComponent<Enemy_script>().GetDamage(damage);
        }
    }

    

    void GetWayPoint()
    {
        points_length = points_length - 1;
        if(points_length == -1)
        {
            Destroy(gameObject);
            return;
        }

        target = Waypoint_script.points[points_length];
    }
}

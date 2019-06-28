using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_scr : MonoBehaviour
{
    private Transform target;
    public float speed = 1.5f;
    public float damage = 10f;
    public float exploiton_radius = 3f;
    public string enemy_tag = "enemy";
    public float price_missile_turret = 80f;

    public void Ara(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (Vector3.Distance(target.position, gameObject.transform.position) <= 0f)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance_this_frame = speed * Time.deltaTime;



        if (dir.magnitude <= distance_this_frame)
        {
            Hit_target();
            return;
        }

        transform.Translate(dir.normalized * distance_this_frame, Space.World);
        transform.LookAt(target);
    }

    void Hit_target()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,exploiton_radius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == enemy_tag)
                collider.GetComponent<Enemy_script>().GetDamage(damage);
        }

        Destroy(gameObject);

        return;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,exploiton_radius);
    }

}

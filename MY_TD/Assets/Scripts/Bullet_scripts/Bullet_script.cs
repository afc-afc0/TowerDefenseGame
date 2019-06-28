using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour
{
    private Transform target;
    public float speed = 1.5f;
    public float damage = 20f;

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

        if (Vector3.Distance(target.position,gameObject.transform.position) <= 0f)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distance_this_frame = speed * Time.deltaTime;

        

        if(dir.magnitude <= distance_this_frame)
        {
            Hit_target();
            return;
        }

        transform.Translate(dir.normalized * distance_this_frame,Space.World);
    }

    void Hit_target()
    {
        target.GetComponent<Enemy_script>().GetDamage(damage);
        Destroy(gameObject);
                       
        return;
    }
}

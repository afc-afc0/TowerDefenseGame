using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batu_tower_bullet_scr : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 0.05f;
    public string enemy_tag = "enemy";
    public float damage = 10f;

   

    public void Get_rotation(Transform form1,Transform form2)
    {
        dir =  form1.position - form2.position;
    }
    

    void Update()
    {
        gameObject.transform.Translate(dir.normalized * speed,Space.World);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == enemy_tag)
        {
            col.GetComponent<Enemy_script>().GetDamage(damage);
        }
    }

    

}

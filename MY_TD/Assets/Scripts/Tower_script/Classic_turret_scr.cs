using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classic_turret_scr : MonoBehaviour
{
    private float range = 4f;
    public float fire_rate = 0.75f;
    public string enemy_tag = "enemy";
    public float turn_speed = 10f;
    private float fire_count_down = 0f;
    public Transform fire_point;
    public GameObject bullet_prefab;
    public Transform part_to_rotate;
    Queue<Enemy_script> enemies = new Queue<Enemy_script>();
    public float price_std_turret = 50f;

    [Header("Dont Touch")]
    public Transform target;
    

    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.2f);
    }

    void Update()
    {
        TargetUpdate(); 

        if (target == null)
            return;

        Vector3 dir = target.position - part_to_rotate.position;
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rotationn = Quaternion.Lerp(part_to_rotate.rotation,look,Time.deltaTime * turn_speed).eulerAngles;
        part_to_rotate.rotation = Quaternion.Euler(0f,rotationn.y,0f);

       /* target.transform.position = Vector3.Lerp(target.transform.position, target.position, turn_speed * Time.deltaTime);
        part_to_rotate.transform.LookAt(target.transform);*/
    }

    void Fire()
    {
        if (target == null) return;

        GameObject Bullet_GO = (GameObject)Instantiate(bullet_prefab,fire_point.position,fire_point.rotation);
        Bullet_script bullet = Bullet_GO.GetComponent<Bullet_script>(); 

        if(bullet != null)
        {
            bullet.Ara(target);
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

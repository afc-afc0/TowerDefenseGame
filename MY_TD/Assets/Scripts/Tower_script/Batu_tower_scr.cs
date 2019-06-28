using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batu_tower_scr : MonoBehaviour
{
    public float fire_rate = 1f;
    public GameObject bullet_prefab;
    public Transform fire_point1;
    public Transform fire_point2;
    public Vector3 dir;

    void Start()
    {
            dir = fire_point1.position - fire_point2.position;
            InvokeRepeating("Shot",0f,fire_rate);
    }

    void Shot()
    {
          GameObject bullet = (GameObject)Instantiate(bullet_prefab, fire_point1.position, fire_point1.rotation);
          bullet.GetComponent<Batu_tower_bullet_scr>().Get_rotation(fire_point1,fire_point2);
    }




}

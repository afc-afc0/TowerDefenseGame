using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_tower_script : MonoBehaviour
{
    public GameObject Roll_prefab;
    public Transform spawn_point;


    void OnMouseDown()
    {
        Start_Roll();
    }

    void Start_Roll()
    {
        Instantiate(Roll_prefab,spawn_point.position,spawn_point.rotation);
    }
      
}

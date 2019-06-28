using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrript_hit_target : MonoBehaviour
{
    public GameObject BOMB_prefab;

    void Start()
    {
        Debug.Log("Started");
    }

    void Update()
    {
        if (Input.touchCount >= 2)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touch_pos = Camera.main.ScreenToWorldPoint(touch.position);
            touch_pos.z = 0;
            Quaternion rot = gameObject.transform.rotation;
            Instantiate(BOMB_prefab, touch_pos, rot);
            gameObject.SetActive(false);
        }
    }
}

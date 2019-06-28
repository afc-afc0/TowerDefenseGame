using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_bar_scr : MonoBehaviour
{
    private Vector3 temp; 
    
    public void RResize(float health)
    {
        temp = transform.localScale;

        temp.x = health / 100;

        transform.localScale = temp;
    }
    
}

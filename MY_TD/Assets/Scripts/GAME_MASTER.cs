using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_MASTER : MonoBehaviour
{

    public static GameObject last_node;
    public static int money;
    private int start_money = 100;

    void Awake()
    {
        money = start_money;
    }


   
}

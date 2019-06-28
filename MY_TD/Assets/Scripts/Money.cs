using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text money_text;

    void Update()
    {
        money_text.text = "€" + GAME_MASTER.money.ToString();
    }

}

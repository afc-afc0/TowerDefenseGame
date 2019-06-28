using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    static int lives = 5;
    public string enemy_tag = "enemy";

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == enemy_tag)
        {
            lives--;
            if (lives == -1)
            {
                GameOver();
                gameObject.SetActive(false);
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game over!!!!");
    }

}

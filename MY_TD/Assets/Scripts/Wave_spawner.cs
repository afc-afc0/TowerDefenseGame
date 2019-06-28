using UnityEngine;
using System.Collections;

public class Wave_spawner : MonoBehaviour
{
    public Transform start_point;
    public Transform enemy_prefab;
    private string start_point_name = "start";

    public float time_between_waves = 0.5f;
    private float countdown = 0.2f;
    private int wave_num = 0;
    private int enem_num = 0;

    void Awake()
    {
        start_point = GameObject.Find(start_point_name).transform;
    }

    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(Spawn_wave());
            countdown = time_between_waves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator Spawn_wave()
    {
       
        wave_num++;
        for (int i = 0; i < wave_num; i++)
        {
            enem_num++;
            Spawn_enemy();
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Spawn_enemy()
    {
        Instantiate(enemy_prefab, start_point.position, start_point.rotation);
    }


}

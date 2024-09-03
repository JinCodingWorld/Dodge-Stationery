using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public GameObject bookprefab;
    public GameObject Unitybookprefab;
    public GameObject Unrealbookprefab;
    public GameObject success;
    public GameManager gamemanager;

    public float rateMin1 = 2f;
    public float rateMax2 = 4f;

    public float rateMin3 = 1f;
    public float rateMax4 = 3f;

    public float rateMin5 = 0.5f;
    public float rateMax6 = 3f;

    float addtime = 0f;

    Transform target;
    float spawnRate;
    float timeAfterSpawn;
    void Start()
    {
        timeAfterSpawn = 0;
        addtime = 0f;
        spawnRate = Random.Range(rateMin1, rateMax2);
        target = FindObjectOfType<PlayerController>().transform;

    }
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        addtime += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            if (addtime < 15f)
            {
                timeAfterSpawn = 0;
                GameObject obj =
                    Instantiate(bookprefab, transform.position, Quaternion.identity); // 회전값이 없다.
                obj.transform.LookAt(target);
                spawnRate = Random.Range(rateMin1, rateMax2);
            }
            else if(addtime <30f)
            {
                //Destroy(bookprefab);
                timeAfterSpawn = 0;
                GameObject obj =
                    Instantiate(Unitybookprefab, transform.position, Quaternion.identity);
                obj.transform.LookAt(target);
                spawnRate = Random.Range(rateMin3, rateMax4);
            }
            else if (addtime < 60f)
            {
                timeAfterSpawn = 0;
                GameObject obj =
                    Instantiate(Unrealbookprefab, transform.position,  Quaternion.identity);
                obj.transform.LookAt(target);
                spawnRate = Random.Range(rateMin5, rateMax6);
            }
            else
            {
                success.SetActive(true);
                gamemanager.EndGame();
            }

        }
        
        
    }
}

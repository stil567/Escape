using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlenka : MonoBehaviour
{
    public GameObject alenka, appeal;
    public GameObject spawn;//точка появления ГГ

    void Start()
    {
        Invoke("SpawnEffects", 0.5f);
        Invoke("SpawnPerson", 1f);
    }

    void SpawnPerson()//генирация ГГ
    {
        Instantiate(alenka, spawn.transform.position, Quaternion.identity);
    }
    void SpawnEffects()//генирация эффекта
    {
        Instantiate(appeal, spawn.transform.position, Quaternion.identity);
    }
}

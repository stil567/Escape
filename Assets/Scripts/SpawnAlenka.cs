using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlenka : MonoBehaviour
{
    public GameObject alenka, appeal;

    Vector3 alenkaPos = new Vector3(0, 1, -5);
    void Start()
    {
        Invoke("SpawnEffects", 0.5f);
        Invoke("SpawnPerson", 1f);
    }

    void SpawnPerson()//генирация ГГ
    {
        Instantiate(alenka, alenkaPos, Quaternion.identity);
    }
    void SpawnEffects()//генирация эффекта
    {
        Instantiate(appeal, alenkaPos, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject nextLevelButton; //кнопка перехода на следующий уровень
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nextLevelButton.SetActive(true);//появляется кнопка перезапуска
            GameObject.FindGameObjectWithTag("Player").GetComponent<AlenkaMove>().enabled = false;//отключение перемещения гг
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject nextLevelButton; //кнопка перехода на следующий уровень
    public GameObject nextLevelText; //надпись о окончании уровня
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //появление конпки и сообщения о прохождении уровня
            nextLevelButton.SetActive(true);
            nextLevelText.SetActive(true);

            //отключение перемещения гг
            GameObject.FindGameObjectWithTag("Player").GetComponent<AlenkaMove>().enabled = false;
        }
    }
}


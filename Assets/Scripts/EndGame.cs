using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject nextLevelText; //надпись о окончании уровня
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //появление конпки и сообщения о прохождении уровня
            nextLevelText.SetActive(true);

            //отключение перемещения гг
            GameObject.FindGameObjectWithTag("Player").GetComponent<AlenkaMove>().enabled = false;
        }
    }
}
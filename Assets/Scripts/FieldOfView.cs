using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public GameObject restartButton; //кнопка перезапуска уровня
    public GameObject Noticed;//сообщение об обнаружении
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject alenka;//объект поиска

    //слои для препятствий, объектов
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeeAlenka;//проверка на видимость персонажа

    private void Start()
    {
        alenka = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine() //проверка на видимость с задержкой
    {

        WaitForSeconds wait = new WaitForSeconds(0.2f);  //фактическая задержка в процедуре 5 раз в секунду
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, targetMask); //центральная позиция,радиус, маска

        if (rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform; //первый из массива, т.к. один игрок
            Vector3 directionToTarget = (target.position - transform.position).normalized; //разница между позицией игрока и врага, получаем направление

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) //проверка на появление в поле зрения врага персонажа 
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); //находим расстояние между врагов и персонажем для ограничения луча

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)) //если не наткнулись на препятствие, то персонаж замечен
                { 
                    canSeeAlenka = true;
                    GameOver();
                }
                else
                    canSeeAlenka = false;
            }
            else
                canSeeAlenka = false;
        }
        else if (canSeeAlenka) //если раньше были в поле зрении врага
            canSeeAlenka = false;
    }
    private void GameOver()//функця проигрыша
    {
        restartButton.SetActive(true);//появляется кнопка перезапуска
        Noticed.SetActive(true);//появляется сообщение
        GetComponent<Patrol>().enabled = false;//отключение перемещения врага
        GameObject.FindGameObjectWithTag("Player").GetComponent<AlenkaMove>().enabled = false;//отключение перемещения гг
    }
}

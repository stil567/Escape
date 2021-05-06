using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlenkaMove : MonoBehaviour
{
    public float speedMove = 10f;//скорость передвижения персонажа.
    public float JumpPower = 5f;//сила прыжка.
    private float gravityForce;//гравитация
    private Vector3 moveVector;//направление персонажа

    private CharacterController ch_controller;//ссылка на компонент контроллер

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PersonalMove();
        PersonalGravity();
    }

    private void PersonalMove()
    {
        //перемещение
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;
        
        //поворот персонажа по направлению движения
        if(Vector3.Angle(Vector3.forward, moveVector) >1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);//движение по направлению
    }

    private void PersonalGravity()
    {
        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;//проверка на полет
        else gravityForce = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravityForce = JumpPower;
    }
}

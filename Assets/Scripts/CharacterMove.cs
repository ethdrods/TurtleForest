
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    //Transform���� ī�޶� �����ӿ� ���� �޶����Ƿ�, //CameraTransform ���� ����
    public CharacterController characterController;
    //CharacterController�� 3D ������Ʈ�� �����ϱ�
    public float moveSpeed = 10f;
    //�̵� �ӵ�
    public float jumpSpeed = 10f;
    //���� �ӵ�
    public float gravity = -20f;
    //�߷�
    public float yVelocity = 0;
    //Y�� ������
    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //h ������ Ű������ ���ΰ� (��, ��) �� �о�� ����� �ѱ��.
        float v = Input.GetAxis("Vertical");
        //v ������ Ű������ ���ΰ� (��, ��) �� �о�� ����� �ѱ��.
    
        Vector3 moveDirection = new Vector3(h, 0, v);
        //(X��, y��, 2�� = h ����, 0, v ����) ���� �о�� ���� Vector3���� ���� //�ش� ���� vector3 ������ moveDirection ������ �ѱ��.
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        //moveDirection ���� ī�޶� ��ġ
        moveDirection *= moveSpeed;
        //�������� moveDirection ���� moveDirection * movespeed ���� ���� ���� ��.
        if (characterController.isGrounded)
        //����, characterController�� ���� �پ��ִٸ�
        {
            yVelocity = 0;
            //y�� ������ ���� 0�̰�,
            if (Input.GetKeyDown(KeyCode.Space))
            //�����̽� �� Ű�� ���� ������ �ǽ��ϰ�,
            {
                yVelocity = jumpSpeed;
                //����ڰ� ������ jumpspeed
            }
        }
        yVelocity += (gravity * Time.deltaTime);

        moveDirection.y = yVelocity;
        //����� yVelocity ���� moveDirection.y (Y�� ������ ����) �� �Ѱ��ش�.
        characterController.Move(moveDirection * Time.deltaTime);
        //���������� characterController�� �������� ���� * Time. deltaTime ��
    }

}


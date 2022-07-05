using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJ_GameraMove : MonoBehaviour
{

    // �ٶ� Ÿ��
    public GameObject player;
    // �ٶ󺸴� �Ÿ�
    public float distance = 25;
    float x;
    float y;
    bool position2 = true;
    int positionCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1��Ī 3��Ī ��Ŭ������ ��ȯ
        CameraRotate();

        if (Input.GetButtonDown("Fire2"))
        {
            positionCount++;
        }

        if(positionCount > 0)
        {
            Fire2Position();

            if(positionCount > 1)
            {
                CameraRotate();
                positionCount = 0;
            }
        }

    }


    void CameraRotate()
    {
        // ���콺 �¿� �̵� ����
        x += Input.GetAxis("Mouse X");
        // ���콺 ���� �̵� ����
        y -= Input.GetAxis("Mouse Y");
        // �̵����� ���� ī�޶� �ٶ󺸴� ���� ����
        transform.rotation = Quaternion.Euler(y, x, 0);
        // ���ư� �� �ִ� ���� ����
        y = Mathf.Clamp(y, -12, 32);
        // ī�޶�� �÷��̾��� �Ÿ�����
        Vector3 reDistance = new Vector3(0.0f, -10, distance);
        transform.position = player.transform.position - transform.rotation * reDistance;
    }

    void Fire2Position()
    {
        // ���콺 �¿� �̵� ����
        x += Input.GetAxis("Mouse X");
        // ���콺 ���� �̵� ����
        y -= Input.GetAxis("Mouse Y");
        // �̵����� ���� ī�޶� �ٶ󺸴� ���� ����
        transform.rotation = Quaternion.Euler(y, x, 0);
        // ���ư� �� �ִ� ���� ����
        y = Mathf.Clamp(y, -12, 32);
        // ī�޶�� �÷��̾��� �Ÿ�����
        Vector3 reDistance = new Vector3(-10, -5, 15);
        transform.position = player.transform.position - transform.rotation * reDistance;
        Debug.Log("ddd");
    }
}

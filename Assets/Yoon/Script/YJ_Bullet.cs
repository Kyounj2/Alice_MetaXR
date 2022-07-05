using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���ư��� �ʹ�
// �ʿ���� : �ӵ�
public class YJ_Bullet : MonoBehaviour
{
    // �ʿ���� : �ӵ�
    public float speed = 200f;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Camera.main.transform.rotation;
        //.LookAt(Camera.main.transform.forward);
        // ������ ���ư��� �ʹ� (�� ��ġ�� �չ���)

        transform.position += dir * speed * Time.deltaTime;
        dir.Normalize();

    }
}

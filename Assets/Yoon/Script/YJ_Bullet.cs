using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���ư��� �ʹ�
// �ʿ���� : �ӵ�
public class YJ_Bullet : MonoBehaviour
{
    // �ʿ���� : �ӵ�
    public float speed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ���ư��� �ʹ�
        Vector3 dir = Vector3.forward;
        transform.position += dir * speed * Time.deltaTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJ_PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 3;
    public float dashSpeed = 10;
    public int jumpCount = 2;
    bool grounded = false;
    float yVelocity;
    float gravity = -9.81f;
    Vector3 dir = Vector3.zero;
    CharacterController cc;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //�̵�����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        //���� ��������� �߷¼��� �ߴ�
        if (cc.isGrounded)
        {
            yVelocity = 0;
            jumpCount = 2;
            jumpPower = 3;
            grounded = true;
        }

        //��������
        yVelocity += gravity * Time.deltaTime;
        // ���� ����������
        if (grounded && jumpCount > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
                //������ �ι������� �ϰ�ʹ�
                //������ �Ҷ����� ī���͸� ���̰�
                jumpCount--;
            }

            //����ī���Ͱ� 1���� �������
            else if (jumpCount < 1)
            {
                // ������ ���ϰ� �Ѵ�
                jumpPower = 0;
            }
        }
        dir.y = yVelocity;

        cc.Move(dir * speed * Time.deltaTime);

        // �������� �ϰ�ʹ�
        // ������ ����Ű�� ������ �ӵ��� �ι�� ��� �������� ������� ���ƿ�
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("p");
            // ���� ����Ű�� 2�� �ȿ� �� ������
            float dashTime = 0;             
            dashTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W) && dashTime<2)
            {
                print("pp");
                // Dash �Լ��� �ҷ��´�
                Dash();                
                dashTime = 0;                
            }
        }

        void Dash()
        {
            // 2. �ӵ��� �ι�� ������
            // 3. �� 10�� �� ������� ���ƿ��� (�׽�Ʈ)
            cc.Move(dir * dashSpeed * Time.deltaTime);
            float dashTime = 0;
            dashTime += Time.deltaTime;

            if (dashTime > 10)
            {
                cc.Move(dir * speed * Time.deltaTime);
                dashTime = 0;
            }               
        }
    }
}


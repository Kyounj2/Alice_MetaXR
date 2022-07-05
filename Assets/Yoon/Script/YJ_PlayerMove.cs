using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJ_PlayerMove : MonoBehaviour
{
    public float speed = 100f;
    public float jumpPower = 3f;
    public float dashSpeed = 150f;
    public Transform camPivot;
    public Transform moving_object;
    //public int jumpCount = 2;
    bool canDoubleJump = false;
    //bool dash = false;
    //bool grounded = false;
    //bool time = false;
    //int wDashCount = 0;
    //float dashTime = 0;
    //float yVelocity;
    float gravity = -9.81f;
    float diry;
    float doubleJump = 1f;
    float currentTime;
    Vector3 dir = Vector3.zero;
    Vector3 playerPosition;
    Vector3 targetPosition;
    Vector3 conDirAngle;
    Vector3 camPivotAngle;
    public bool UseCameraRotation = true;
    CharacterController cc;
    private Camera currentCamera;



    // Start is called before the first frame update
    void Start()
    {
        // ĳ���� �̵��� ���� ��Ʈ�ѷ�
        cc = GetComponent<CharacterController>();
        // ī�޶� ������ ������������ ī�޶�
        currentCamera = FindObjectOfType<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        // �⺻�̵�
        Move();
        // ���⿡ ���� �ü�ó��
        Turn();
        // ����
        Jump();


        cc.Move(dir * speed * Time.deltaTime);

        // �뽬
        //Dash();

        //��������1

        //���� ��������� �߷¼��� �ߴ�
        /*if (cc.isGrounded)
        {
            yVelocity = 0;
            jumpCount = 2;
            jumpPower = 3;
            grounded = true;
        }

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
        dir.y = yVelocity;*/

        //

        // �뽬����
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            wDashCount++;
            print(wDashCount);
        }

        if (wDashCount >= 2)
        {
            dashTime += Time.deltaTime;

            if (dashTime < 0.1)
            {
                time = true;
                StartCoroutine("Dash");
            }

            else if (dashTime > 0.1)
            {
                wDashCount = 0;
                dashTime = 0;
            }
        }*/


    }
    void Move()
    {
        //�̵�����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();


        if (Input.GetButton("Fire2"))
        {
            //ī�޶�?�����ִ�?������?��?��������?�����Ѵ�.
            dir = Camera.main.transform.TransformDirection(dir);
        }


        //ī�޶� �������� �����ش�.
        if (UseCameraRotation)
        {
            //ī�޶��� yȸ���� ���ؿ´�.
            Quaternion v3Rotation = Quaternion.Euler(0f, currentCamera.transform.eulerAngles.y, 0f);
            //�̵��� ���͸� ������.
            dir = v3Rotation * dir;
            //Debug.Log(currentCamera.transform.eulerAngles.y.ToString());
        }

    }

    void Turn()
    {
        // �����̴� ���� �ٶ󺸱�
        transform.LookAt(transform.position + dir);
    }
    void Jump()
    {
        // ���࿡ �ٴڿ� ����ִٸ� (������������)
        if (cc.isGrounded)
        {
            // �ε巴�� ������������ �ٴڿ� ������ y���� 0���� �����ϱ�
            dir.y = 0;
            canDoubleJump = true;

            // �����̽��ٸ� ������ �������� y�� (��������)
            if (Input.GetButtonDown("Jump"))
            {
                diry = jumpPower;
            }
        }
        // �������� ���� (�ٴڿ� ���� �ʴ��� �ѹ� �� ��������)
        else
        {
            // ������ư�� ������ ���������� true�϶�
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                // ��������
                diry = jumpPower * doubleJump;
                // 3���� ���ϵ��� ����
                canDoubleJump = false;
            }
        }
        // �ε巯�� �������� (�߷¿� deltatime)
        diry += gravity * Time.deltaTime;
        dir.y = diry;
    }

    /*void Dash()
    {
        // ����Ű�� �ι� ������ ���� �ٶ󺸴� �������� ������ �̵��ϰ�ʹ�
        // ���� ����Ű�� �ѹ� ������ dash ture
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentTime += Time.deltaTime;
            if(currentTime > 0.5f)
            {
                dash = true;
                currentTime = 0;
            }
            print("1"+dash);
            print(currentTime);
        }

        // �ѹ� �� ������
        if (Input.GetKeyDown(KeyCode.W) && dash)
        {
            // �� �չ������� ������ �̵�
            Vector3 dir2 = transform.forward;
            cc.Move(dir2 * dashSpeed * Time.deltaTime);

            dash = false;

            print("2"+dash);
        }

    }*/
    /*IEnumerator Dash()
    {
        playerPosition = transform.position;
        float target = 30;
        targetPosition = playerPosition + new Vector3(0, 0, target);
        print("11");

        while (true)
        {
            if (time == true)
            {
                print("22");
                float go = dashSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, go);
                target -= go;
                
                if(target < 0 )
                {
                    time = false;
                    yield break;
                }
                yield return null;
            }
            else
            {
                print("33");
                yield break;
            }
        }
    }*/


}





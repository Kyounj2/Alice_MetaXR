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

        //이동구현
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        //땅에 닿아있을때 중력설정 중단
        if (cc.isGrounded)
        {
            yVelocity = 0;
            jumpCount = 2;
            jumpPower = 3;
            grounded = true;
        }

        //점프구현
        yVelocity += gravity * Time.deltaTime;
        // 땅에 닿아있을경우
        if (grounded && jumpCount > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpPower;
                //점프를 두번까지만 하고싶다
                //점프를 할때마다 카운터를 줄이고
                jumpCount--;
            }

            //점프카운터가 1보다 작을경우
            else if (jumpCount < 1)
            {
                // 점프를 못하게 한다
                jumpPower = 0;
            }
        }
        dir.y = yVelocity;

        cc.Move(dir * speed * Time.deltaTime);

        // 더블데쉬를 하고싶다
        // 빠르게 방향키를 누르면 속도가 두배로 잠깐 빨라지고 원래대로 돌아옴
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("p");
            // 만약 방향키를 2초 안에 또 누르면
            float dashTime = 0;             
            dashTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W) && dashTime<2)
            {
                print("pp");
                // Dash 함수를 불러온다
                Dash();                
                dashTime = 0;                
            }
        }

        void Dash()
        {
            // 2. 속도가 두배로 빨라짐
            // 3. 약 10초 후 원래대로 돌아오기 (테스트)
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


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
        // 캐릭터 이동을 위한 컨트롤러
        cc = GetComponent<CharacterController>();
        // 카메라 방향을 가져오기위한 카메라
        currentCamera = FindObjectOfType<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        // 기본이동
        Move();
        // 방향에 따른 시선처리
        Turn();
        // 점프
        Jump();


        cc.Move(dir * speed * Time.deltaTime);

        // 대쉬
        //Dash();

        //점프구현1

        //땅에 닿아있을때 중력설정 중단
        /*if (cc.isGrounded)
        {
            yVelocity = 0;
            jumpCount = 2;
            jumpPower = 3;
            grounded = true;
        }

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
        dir.y = yVelocity;*/

        //

        // 대쉬구현
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
        //이동구현
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();


        if (Input.GetButton("Fire2"))
        {
            //카메라가?보고있는?방향을?앞?방향으로?변경한다.
            dir = Camera.main.transform.TransformDirection(dir);
        }


        //카메라 방향으로 돌려준다.
        if (UseCameraRotation)
        {
            //카메라의 y회전만 구해온다.
            Quaternion v3Rotation = Quaternion.Euler(0f, currentCamera.transform.eulerAngles.y, 0f);
            //이동할 벡터를 돌린다.
            dir = v3Rotation * dir;
            //Debug.Log(currentCamera.transform.eulerAngles.y.ToString());
        }

    }

    void Turn()
    {
        // 움직이는 방향 바라보기
        transform.LookAt(transform.position + dir);
    }
    void Jump()
    {
        // 만약에 바닥에 닿아있다면 (무한점프방지)
        if (cc.isGrounded)
        {
            // 부드럽게 떨어지기위해 바닥에 있을땐 y값을 0으로 설정하기
            dir.y = 0;
            canDoubleJump = true;

            // 스페이스바를 누르면 점프값을 y로 (점프구현)
            if (Input.GetButtonDown("Jump"))
            {
                diry = jumpPower;
            }
        }
        // 더블점프 구현 (바닥에 있지 않더라도 한번 더 점프가능)
        else
        {
            // 점프버튼을 누르고 더블점프가 true일때
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                // 점프가능
                diry = jumpPower * doubleJump;
                // 3단은 못하도록 막기
                canDoubleJump = false;
            }
        }
        // 부드러운 점프구현 (중력에 deltatime)
        diry += gravity * Time.deltaTime;
        dir.y = diry;
    }

    /*void Dash()
    {
        // 방향키를 두번 누르면 내가 바라보는 방향으로 빠르게 이동하고싶다
        // 내가 방향키를 한번 누르면 dash ture
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

        // 한번 더 누르면
        if (Input.GetKeyDown(KeyCode.W) && dash)
        {
            // 내 앞방향으로 빠르게 이동
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





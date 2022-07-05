using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJ_GameraMove : MonoBehaviour
{

    // 바라볼 타겟
    public GameObject player;
    // 바라보는 거리
    public float distance = 25;
    float x;
    float y;
    int positionCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1인칭 3인칭 우클릭으로 변환
        CameraRotate();

        if (Input.GetButtonDown("Fire2"))
        {
            positionCount++;
        }

        if(positionCount > 0)
        {
            Fire2Position();
            YJ_PlayerMove.Instance.Turn2();
            YJ_PlayerFire.Instance.Fire();

            if (positionCount > 1)
            {
                CameraRotate();
                positionCount = 0;
                YJ_PlayerMove.Instance.turn2 = false;
            }
        }

    }


    void CameraRotate()
    {
        // 마우스 좌우 이동 누적
        x += Input.GetAxis("Mouse X");
        // 마우스 상하 이동 누적
        y -= Input.GetAxis("Mouse Y");
        // 이동량에 따라 카메라가 바라보는 방향 조정
        transform.rotation = Quaternion.Euler(y, x, 0);
        // 돌아갈 수 있는 각도 제한
        y = Mathf.Clamp(y, -12, 32);
        // 카메라와 플레이어의 거리조정
        Vector3 reDistance = new Vector3(0.0f, -10, distance);
        transform.position = player.transform.position - transform.rotation * reDistance;
    }

    void Fire2Position()
    {
        // 마우스 좌우 이동 누적
        x += Input.GetAxis("Mouse X");
        // 마우스 상하 이동 누적
        y -= Input.GetAxis("Mouse Y");
        // 이동량에 따라 카메라가 바라보는 방향 조정
        transform.rotation = Quaternion.Euler(y, x, 0);
        // 돌아갈 수 있는 각도 제한
        y = Mathf.Clamp(y, -12, 32);
        // 카메라와 플레이어의 거리조정
        Vector3 reDistance = new Vector3(-10, -5, 15);
        transform.position = player.transform.position - transform.rotation * reDistance;

    }
}

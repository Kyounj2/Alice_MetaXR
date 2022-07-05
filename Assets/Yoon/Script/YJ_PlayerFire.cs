using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 왼쪽 버튼을 누르면 여기서 총알이 발사될것이다.
// 필요사항 : 총알
public class YJ_PlayerFire : MonoBehaviour
{
    // 필요사항 : 총알
    public GameObject bulletFactory;
    public bool fire = false;
    public static YJ_PlayerFire Instance = null;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame

    // 만약에 우클릭을 하면 화면 위치를 바꾸고 싶다.
    // 화면 위치를 바꾸고싶다
    // 우클릭을 하면
    
    void Update()
    {

    }

    public void Fire()
    {
        // 마우스 왼쪽 버튼을 누르면 여기서 총알이 발사될것이다.
        // 마우스 왼쪽 버튼 클릭
        if (Input.GetButtonDown("Fire1"))
        {
            // 총알의 위치도 함께 가져와야 다른 방향으로 쏠 수 있음
            GameObject bullet = Instantiate(bulletFactory, transform.position, transform.rotation);

            // 내 위치에 총알 오브젝트 소환
            bullet.transform.position = transform.position;
        }
    }
}

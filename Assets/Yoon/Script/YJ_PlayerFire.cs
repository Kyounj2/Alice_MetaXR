using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 왼쪽 버튼을 누르면 여기서 총알이 발사될것이다.
// 필요사항 : 총알
public class YJ_PlayerFire : MonoBehaviour
{
    // 필요사항 : 총알
    public GameObject bulletFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼을 누르면 여기서 총알이 발사될것이다.
        // 마우스 왼쪽 버튼 클릭
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            // 내 위치에 총알 오브젝트 소환
            bullet.transform.position = transform.position;
        }
    }
}

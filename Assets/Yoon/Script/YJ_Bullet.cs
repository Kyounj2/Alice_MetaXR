using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 앞으로 나아가고 싶다
// 필요사항 : 속도
public class YJ_Bullet : MonoBehaviour
{
    // 필요사항 : 속도
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
        // 앞으로 나아가고 싶다 (내 위치의 앞방향)

        transform.position += dir * speed * Time.deltaTime;
        dir.Normalize();

    }
}

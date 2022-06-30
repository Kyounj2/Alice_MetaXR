using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtMove : MonoBehaviour
{
    public float speed = 100;
    public float dashSpeed = 500;
    int wDashCount = 0;
    float dashTime = 0;
    bool time = false;
    Vector3 dir = Vector3.zero;
    Vector3 playerPosition;
    Vector3 targetPosition;
    CharacterController cc;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W))
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
        }
    }
    IEnumerator Dash()
    {
        while (true)
        {
            if (time == true)
            {
                playerPosition = transform.position;
                targetPosition = playerPosition + new Vector3(0, 0, 10);

                transform.position = Vector3.MoveTowards(transform.position, targetPosition, dashSpeed * Time.deltaTime);

                time = false;
                yield return null;
            }
            else
            {
                yield break;
            }
        }
    }
}
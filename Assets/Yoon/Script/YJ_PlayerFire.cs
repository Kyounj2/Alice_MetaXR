using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 ���� ��ư�� ������ ���⼭ �Ѿ��� �߻�ɰ��̴�.
// �ʿ���� : �Ѿ�
public class YJ_PlayerFire : MonoBehaviour
{
    // �ʿ���� : �Ѿ�
    public GameObject bulletFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ���� ��ư�� ������ ���⼭ �Ѿ��� �߻�ɰ��̴�.
        // ���콺 ���� ��ư Ŭ��
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            // �� ��ġ�� �Ѿ� ������Ʈ ��ȯ
            bullet.transform.position = transform.position;
        }
    }
}

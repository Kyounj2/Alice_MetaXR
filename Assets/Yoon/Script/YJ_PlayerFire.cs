using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���콺 ���� ��ư�� ������ ���⼭ �Ѿ��� �߻�ɰ��̴�.
// �ʿ���� : �Ѿ�
public class YJ_PlayerFire : MonoBehaviour
{
    // �ʿ���� : �Ѿ�
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

    // ���࿡ ��Ŭ���� �ϸ� ȭ�� ��ġ�� �ٲٰ� �ʹ�.
    // ȭ�� ��ġ�� �ٲٰ�ʹ�
    // ��Ŭ���� �ϸ�
    
    void Update()
    {

    }

    public void Fire()
    {
        // ���콺 ���� ��ư�� ������ ���⼭ �Ѿ��� �߻�ɰ��̴�.
        // ���콺 ���� ��ư Ŭ��
        if (Input.GetButtonDown("Fire1"))
        {
            // �Ѿ��� ��ġ�� �Բ� �����;� �ٸ� �������� �� �� ����
            GameObject bullet = Instantiate(bulletFactory, transform.position, transform.rotation);

            // �� ��ġ�� �Ѿ� ������Ʈ ��ȯ
            bullet.transform.position = transform.position;
        }
    }
}

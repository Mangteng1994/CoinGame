using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    //���������Ľ��Ԥ�Ƽ�
    public GameObject CoinPre;
    //��ҽ�ɫ
    private Transform player;

    void Start()
    {
        //ͨ����ǩ�ҵ���ҽ�ɫ
        player = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //�����������ҽ�ɫ�ľ���
        float dis = Vector3.Distance(transform.position,player.position);
        //�������С��2m����ס������
        if (dis<2&&Input.GetMouseButton(0))
        {
            //����������Ӹ���
            if (Random.Range(0,10)>5)
            {
                Instantiate(CoinPre, transform.position, Quaternion.identity);
            }
            //ɾ������
            Destroy(gameObject);
        }
    }
}

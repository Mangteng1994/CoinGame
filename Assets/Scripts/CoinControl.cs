using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    // Start is called before the first frame update
    //��ҵ�����
    public static int Count=0;
    //��Ϸ���
    public Transform player;
    //�������
    public AudioSource audioSource;
    //ʤ����Ч
    public GameObject EffectPre;
    void Start()
    {
        //ͨ����ǩ�ҵ���ҽ�ɫ
        player = GameObject.FindWithTag("Player").transform.GetChild(0);
        //��ȡ���ֲ��������
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //��������ҵľ���
        float dis = Vector3.Distance(player.position,transform.position);
        //�������С��1.5m
        if (dis<1.5f)
        {
            //�������+1
            Count++;
            //���ųԽ������
           audioSource.PlayOneShot(Resources.Load<AudioClip>("Coin/coin_01"));
            //�����ǰ�������
            Debug.Log("��ý�ң���ǰ���Ϊ��"+Count);
            //�������������ڻ����3
            if (Count>=3)
            {
                //ʵ����ʤ����Ч
                GameObject go = Instantiate(EffectPre, transform.position, transform.rotation);
                //8s��ɾ����Ч
                Destroy(go, 8f);
            }
            //�ӳ�ɾ������
            Destroy(gameObject,0.3f);
            //ɾ���ű�
            Destroy(this);
        }
    }
}

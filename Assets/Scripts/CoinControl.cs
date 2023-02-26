using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    // Start is called before the first frame update
    //金币的数量
    public static int Count=0;
    //游戏玩家
    public Transform player;
    //音乐组件
    public AudioSource audioSource;
    //胜利特效
    public GameObject EffectPre;
    void Start()
    {
        //通过标签找到玩家角色
        player = GameObject.FindWithTag("Player").transform.GetChild(0);
        //获取音乐播放器组件
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //自身与玩家的距离
        float dis = Vector3.Distance(player.position,transform.position);
        //如果距离小于1.5m
        if (dis<1.5f)
        {
            //金币数量+1
            Count++;
            //播放吃金币声音
           audioSource.PlayOneShot(Resources.Load<AudioClip>("Coin/coin_01"));
            //输出当前金币数量
            Debug.Log("获得金币，当前金币为："+Count);
            //如果金币数量大于或等于3
            if (Count>=3)
            {
                //实例化胜利特效
                GameObject go = Instantiate(EffectPre, transform.position, transform.rotation);
                //8s后删除特效
                Destroy(go, 8f);
            }
            //延迟删除自身
            Destroy(gameObject,0.3f);
            //删除脚本
            Destroy(this);
        }
    }
}

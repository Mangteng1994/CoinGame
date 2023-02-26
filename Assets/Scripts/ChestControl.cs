using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    //关联制作的金币预制件
    public GameObject CoinPre;
    //玩家角色
    private Transform player;

    void Start()
    {
        //通过标签找到玩家角色
        player = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //获得自身与玩家角色的距离
        float dis = Vector3.Distance(transform.position,player.position);
        //如果距离小于2m并按住鼠标左键
        if (dis<2&&Input.GetMouseButton(0))
        {
            //随机数，增加概率
            if (Random.Range(0,10)>5)
            {
                Instantiate(CoinPre, transform.position, Quaternion.identity);
            }
            //删除宝箱
            Destroy(gameObject);
        }
    }
}

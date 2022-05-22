using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;  //玩家

    public GameObject monster;  //怪物

    public Transform monsterLocation;  //怪物生成位置
    public Transform[] monsters;  

    private void Awake()
    {
        MonsterAppear();
    }


    /// <summary>
    /// 生成怪物
    /// </summary>
    private void MonsterAppear() 
    {
        monsters = monsterLocation.GetComponentsInChildren<Transform>();

        for (int i = 1; i < 4; i++)
        {
            Instantiate(monster, monsters[i].position, Quaternion.identity, monsters[i]);
        }
        
    }


}

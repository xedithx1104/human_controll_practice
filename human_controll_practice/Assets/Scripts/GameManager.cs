using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;  //���a

    public GameObject monster;  //�Ǫ�

    public Transform monsterLocation;  //�Ǫ��ͦ���m
    public Transform[] monsters;  

    private void Awake()
    {
        MonsterAppear();
    }


    /// <summary>
    /// �ͦ��Ǫ�
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

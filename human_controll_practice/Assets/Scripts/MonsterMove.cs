using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float speed = 0.5f;

    public bool canMove = false;
    public string moveType = "go";

    public GameObject monstTest;
    public GameObject player;
    public Animator monsterAnim;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        monstTest = transform.GetChild(0).transform.gameObject;
        player = FindObjectOfType<PlayerControl>().transform.gameObject;
        monsterAnim = monstTest.GetComponent<Animator>();
        Vector3 moveDir;
        
        
        if (canMove)
        {            

            switch (moveType)
            {
                case "go":                                      
                    Vector3 playerLocation = player.transform.position;
                    print(playerLocation);
                    moveDir = playerLocation - monstTest.transform.position;
                    monsterAnim.SetBool("Walk_Anim", true);
                    monstTest.transform.Translate(moveDir.normalized * speed * Time.deltaTime);
                    break;
                case "back":
                    Vector3 spawnLocation = transform.position;
                    print(spawnLocation);
                    moveDir = spawnLocation - monstTest.transform.position;
                    monsterAnim.SetBool("Walk_Anim", true);
                    monstTest.transform.Translate(moveDir.normalized * speed * Time.deltaTime);
                    if ((monstTest.transform.position - spawnLocation).magnitude <= 0.1f)
                    {
                        monsterAnim.SetBool("Walk_Anim", false);
                        canMove = false;
                    }
                    break;
            }
        }
    }
}

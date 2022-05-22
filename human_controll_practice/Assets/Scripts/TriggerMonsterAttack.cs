using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonsterAttack : MonoBehaviour
{
    

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            GetComponent<MonsterMove>().canMove = true;
            GetComponent<MonsterMove>().moveType = "go";
            print("ok~");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<MonsterMove>().canMove = true;
            GetComponent<MonsterMove>().moveType = "back";
            print("bye~");
        }
    }


}

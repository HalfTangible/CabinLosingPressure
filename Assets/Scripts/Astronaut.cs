using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    Room thisRoom; //Room the astronaut is in
    float pressure; //Pressure of space suit
    bool suitBreached;
    float repairSkill;
    bool haveTools;
    bool canAct;
    bool isPanicking;
    bool isMoving;

    Vector2 currentPos;
    Vector2 targetPos;

    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        //agent.updateUpAxis = false; //If we add this then the agent can't go up and down. Which is a problem because I NEED THEM TO BE ABLE TO DO SO.

        suitBreached = false;
        pressure = 1;
        repairSkill = 1;
        haveTools = false;
        canAct = true;
        isPanicking = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.rotation = new Vector3(0, 0, 0);

        if (NeedToMove() && !isPanicking)
        {
            Walking();
        }
        else
        {
            isMoving = false;
        }

        if (pressure < .3 || isPanicking || isMoving)
        {
            canAct = false;
        }
        else { canAct = true;}

        if (canAct)
        {

            if (suitBreached)
            {
                pressure -= Time.deltaTime;
            }

            if (haveTools && thisRoom.IsDamaged())
            {
                Repair();
            }


        }
    }

    void Repair()
    {
        thisRoom.BeingRepaired(repairSkill);
    }

    void Walking()
    {

    }

    bool NeedToMove()
    {
        return true;
        //If you're not at your target position or at least close to it, then yes.
        
        //Get the differences.


    }


}


/*namespace damageLevels
{
    public enum dmg
    {
        none, damaged, badlyDamaged, destroyed, dead
    }
}*/

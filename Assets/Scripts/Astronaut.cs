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

    GameObject selectionIndicator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        //agent.updateUpAxis = false; //If we add this then the agent can't go up and down. Which is a problem because I NEED THEM TO BE ABLE TO DO SO.

        selectionIndicator = transform.Find("Indicator").gameObject;
        Deselect();

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

        if (isPanicking)
        {
            //Set speed to 0 and play a panicking animation
        }
        else
        {
            //Return speed to normal
        }

        if (pressure < .3 || isPanicking || isMoving)
        {
            canAct = false;
        }
        else { canAct = true;}


        if (suitBreached)
        {
            pressure -= Time.deltaTime;
        }


        if (canAct)
        {



            if (haveTools && thisRoom.IsDamaged())
            {
                Repair();
            }


        }
    }

    void SetSelected(bool visible)
    {
        selectionIndicator.SetActive(visible);
    }

    public void Select()
    {
        SetSelected(true);
    }

    public void Deselect()
    {
        SetSelected(false);
    }

    void Repair()
    {
        thisRoom.BeingRepaired(repairSkill);
    }

    public void Walking(Vector3 pos)
    {
        agent.destination = new Vector3 (pos.x, pos.y, 0); //setting the Z to 0 fixed both the slight offset movement problem (other than on walls) and got the thing moving.
        UnityEngine.Debug.Log("agent destination set");
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

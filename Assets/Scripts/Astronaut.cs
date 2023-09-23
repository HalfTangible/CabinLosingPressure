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
    float hDir;
    float damage;

    Vector2 currentPos;
    Vector2 targetPos;

    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;

    GameObject selectionIndicator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        //agent.updateUpAxis = false; //If we add this then the agent can't go up and down. Which is a problem because I NEED THEM TO BE ABLE TO DO SO.

        animator = GetComponent<Animator>();


        selectionIndicator = transform.Find("Indicator").gameObject;
        Deselect();

        suitBreached = false;
        pressure = 1;
        repairSkill = 1;
        haveTools = false;
        canAct = true;
        isPanicking = false;
        hDir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        Animate();
        
        /*
         if this astronaut overlaps with a closed door, the astronaut pauses.

        agent.Stop();
        agent.Resume();
         */

        transform.rotation = Quaternion.Euler(0, hDir, 0);
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

    public void Damage(float amount)
    {
        damage += amount;
    }

    void Repair()
    {
        thisRoom.BeingRepaired(repairSkill);
    }

    public void Walking(Vector3 pos)
    {
        //Stop current movement first?
        //agent.Stop();
        agent.velocity = new Vector3(0, 0, 0);
        agent.destination = new Vector3 (pos.x, pos.y, 0); //setting the Z to 0 fixed both the slight offset movement problem (other than on walls) and got the thing moving.
        UnityEngine.Debug.Log("agent destination set");
        //agent.Resume();
    }

    bool NeedToMove()
    {
        return true;
        //If you're not at your target position or at least close to it, then yes.
        
        //Get the differences.


    }

    void Animate()
    {
        if (agent.velocity.x < 0)
            hDir = 180;
        else if(agent.velocity.x > 0)
            hDir = 0;

        if (agent.velocity.magnitude > .01)
        {
            animator.Play("Walking");
        }
        else {
            animator.Play("Idle");
        }
    }
    /*
    void WaitingForDoor()
    {
        if(BlockedByDoor())
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

    }*/

    /*
    bool BlockedByDoor()
    {

        GameObject overlap;
        
        Airlock theairlock = overlap.GetComponent<Airlock>();

        theAirlock


        return true;
    }*/

    //triggers on every frame that you're within another collider
    private void OnTriggerStay2D(Collider2D c) {

        //Check colliders you overlap with.
        Airlock theAirlock = c.gameObject.GetComponent<Airlock>();
        
        if(theAirlock == null) //If there's no airlock, keep going
            agent.isStopped = false;
        else if(theAirlock != null) //If there's an airlock, check if it's sealed
            agent.isStopped = !theAirlock.CanWalkThrough();
        
        //If it is, agent.isStopped = true;
        //If it isn't, agent.isStopped = false;
    }

}


/*namespace damageLevels
{
    public enum dmg
    {
        none, damaged, badlyDamaged, destroyed, dead
    }
}*/

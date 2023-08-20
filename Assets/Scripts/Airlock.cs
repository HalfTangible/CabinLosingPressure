using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Airlock : MonoBehaviour
{
    bool sealedShut;
    public GameObject room1Obj;
    public GameObject room2Obj;

    Room room1;
    Room room2;

    BoxCollider2D collider;
    BoxCollider2D triggerCollider;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        //get the scripts from room1obj and room2obj

        room1 = GetRoomScript(room1Obj);
        room2 = GetRoomScript(room2Obj);
        animator = GetComponent<Animator>();
        sealedShut = true;
        BoxCollider2D[] c = GetComponents<BoxCollider2D>();
        
        //Find the collider that isn't a trigger (should only be 2)

        foreach (BoxCollider2D c2 in c)
        {
            if (c2.isTrigger == false)
                collider = c2;
            else
                triggerCollider = c2;
        }


    }

    Room GetRoomScript(GameObject theRoom)
    {
        return theRoom.GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Pressure flows between the two rooms if the door isn't sealed
        if (!sealedShut)
        {
            EqualizePressure();
        }

        
        //When an astronaut is nearby and a button pressed the door opens


    }

    public void TriggerDoor()
    {

        UnityEngine.Debug.Log("Trigger door");

        bool isOpen = animator.GetBool("Open");
        bool isDamaged = animator.GetBool("Damaged");

        //If the airlock is damaged, then it cannot be sealed or opened properly
        
        if (isDamaged)
            SendWarning();
        else if (isOpen)
            CloseDoor();
        else if (!isOpen)
            OpenDoor();

    }

    void SendWarning()
    {
        UnityEngine.Debug.Log("Door is damaged and cannot be opened.");

    }

    void OpenDoor()
    {
        UnityEngine.Debug.Log("Open door.");
        animator.SetBool("Open", true);
        sealedShut = false;
        collider.enabled = false;
    }

    void CloseDoor()
    {
        UnityEngine.Debug.Log("Close door.");
        animator.SetBool("Open", false);
        sealedShut = true;
        collider.enabled = true;
    }

    void DamagedDoor()
    {

        UnityEngine.Debug.Log("Door damaged.");
        animator.SetBool("Damaged", true);
        sealedShut = false;
        collider.enabled = true;
    }

    void DoorRepaired()
    {
        UnityEngine.Debug.Log("Door fully repaired.");
        animator.SetBool("Damaged", false);
        CloseDoor();
    }

    void EqualizePressure()
    {
        float r1 = room1.pressure;
        float r2 = room2.pressure;

        //The airlock will try to equalize the air pressure between the rooms it connects.
        if (r1 < r2)
        {
            EqualizePressure(r1, r2);
        }
        else if (r2 < r1)
            EqualizePressure(r2, r1);
    }

    void EqualizePressure(float hasLess, float hasMore)
    {
        float c = Time.deltaTime;
        float toEqualize = (hasMore - hasLess) / 2;

        if (toEqualize < Time.deltaTime)
        {
            //Take the difference, divide by 2, and make them equalize
            hasLess += toEqualize;
            hasMore -= toEqualize;
            
        }
        else {
            hasLess += hasLess;
            hasMore -= hasLess;
        }
        

    }
}

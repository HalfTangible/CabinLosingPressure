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

    // Start is called before the first frame update
    void Start()
    {
        sealedShut = true;

        //get the scripts from room1obj and room2obj
        room1 = GetRoomScript(room1Obj);
        room2 = GetRoomScript(room2Obj);
    }

    Room GetRoomScript(GameObject theRoom)
    {
        return theRoom.GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the door is open, deactivate the collider/navmesh.
        if(sealedShut)
        {
            //this.Collider2D.enabled?
        }else if (!sealedShut)
        {
            EqualizePressure();
            //this.Collider2D.disabled?
        }


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

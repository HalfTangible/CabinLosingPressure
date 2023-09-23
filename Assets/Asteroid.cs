using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    int size;
    float distance; //How long until it hits the room.
    float speed; //how quickly it moves.
    Room target;

    // Start is called before the first frame update
    void Start()
    {
        size = 1;
        speed = 1;
        distance = 10;

        //Select a room at random.
    }

    // Update is called once per frame
    void Update()
    {
        if (distance > 0)
            distance -= (speed * Time.deltaTime);

        if(distance <= 0)
        {
            Hits(target);
        }    

    }

    void Hits(Room aRoom)
    {

    }

    //Scanner room functionality should probably work per room?
    //How about the scanner room both creates and tracks the asteroids?
}

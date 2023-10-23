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
        //Make this asteroid a child of the room
            //Why?
            /*
            
            When I implement scanner functionality, the warning symbol will need to access all of the asteroids heading for the room.
            Doing it this way means that each warning symbol can check its children for the shortest link rather than having the scanner room do it
            Then the warning symbol can just check if the scanner room is active for the early warning system.
            It'll separtate and simplify the code
            
             */
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
        //do damage
    }

    //Scanner room functionality should probably work per room?
    //How about the scanner room both creates and tracks the asteroids?
}

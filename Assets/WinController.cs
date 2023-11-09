using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    bool allDead;
    //List<Astronaut> astronauts;
    Astronaut[] astronauts;

    // Start is called before the first frame update
    void Start()
    {
        allDead = false;
        astronauts = FindObjectsOfType<Astronaut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SomeoneDied()
    {

        allDead = true;

        foreach (Astronaut astronaut in astronauts)
        {
            if(astronaut.isAlive())
            {
                allDead = false;
                break;
            }
        }

        //Check to see if all astronauts are dead
        //If they are, then you lose.
        if (allDead)
            youLose();
    }

    void youWin()
    {
        //Show victory screen
        //Add time 
    }

    void youLose()
    {
        //Show losing screen
        //Offer a chance to start the game again
    }


}

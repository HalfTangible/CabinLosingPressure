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

    // Start is called before the first frame update
    void Start()
    {
        suitBreached = false;
        pressure = 1;
        repairSkill = 1;
        haveTools = false;
        canAct = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (pressure < .3)
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
}


/*namespace damageLevels
{
    public enum dmg
    {
        none, damaged, badlyDamaged, destroyed, dead
    }
}*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float pressure;
    bool breached; //marks whether the room is open to the void of space;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        pressure = 1;
        breached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (breached)
        {
            pressure -= (Time.deltaTime * damage);
        }
    }

    public void hitByAsteroid(int dmg)
    {
        damage += dmg;
    }

    public void BeingRepaired(float repairSkill)
    {
        damage -= Time.deltaTime;
    }

    public bool IsDamaged()
    {
        return (damage > 0);
    }
}

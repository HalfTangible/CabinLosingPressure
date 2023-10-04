using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour
{
    public TextMeshProUGUI damageTextBox;
    public float pressure;
    bool breached; //marks whether the room is open to the void of space;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        damageTextBox = GetComponentInChildren<TextMeshProUGUI>();
        pressure = 1;
        breached = false;
    }

    // Update is called once per frame
    void Update()
    {
        damageTextBox.text = "Damage: " + damage.ToString() + "\nAtm: " + pressure;


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

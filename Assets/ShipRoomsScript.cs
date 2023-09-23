using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipRoomsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Room[] GetAllRooms()
    {
        return GetComponentsInChildren<Room>();
    }

    Room GetRandomRoom()
    {
        //UnityEngine.Random rnd = new Random();

        Room[] allRooms = GetAllRooms();

        int rIndex = UnityEngine.Random.Range(0, allRooms.Length);

        return allRooms[rIndex];
    }
}

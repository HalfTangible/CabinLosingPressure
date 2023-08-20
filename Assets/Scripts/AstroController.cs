using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    //private GameObject selectedObj;

    List<Astronaut> selectedAstronauts;

    private Vector3 startPos;
    private Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        //selectedObj = GameObject.Find("RedAstro");
        selectedAstronauts = new List<Astronaut>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //if (selectedObj == null)
        //    UnityEngine.Debug.Log("Your mom.");
        //https://www.youtube.com/watch?v=mCIkCXz9mxI

        if (Input.GetMouseButtonDown(0)) //if left click
        {
            selectedAstronauts.Clear();
            //Cast a ray to whatever you're selecting
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //Need mouse world position
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Check if there's a door at the position and if there is open it.
            //Put in Up instead maybe?


            

            

        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            UnityEngine.Debug.Log("startPos: " + startPos);
            UnityEngine.Debug.Log("endPos: " + endPos);

            //Select all colliders within the space
            Collider2D[] selectingUnits = Physics2D.OverlapAreaAll(startPos, endPos);
            UnityEngine.Debug.Log("selectedUnits: " +  selectingUnits.Length);
            //Add all selected objects of type Astronaut
            foreach (Collider2D unit in selectingUnits)
            {
             
                Astronaut astroScript = unit.GetComponent<Astronaut>();
                Airlock airlockScript = unit.GetComponent<Airlock>();

                if (astroScript != null)
                    selectedAstronauts.Add(astroScript);
                else if (airlockScript != null && unit.isTrigger) //This way on doors it doesn't trigger twice because we have two colliders.
                    airlockScript.TriggerDoor();   
            }
            //If there aren't any, check if there's an overlap with a object of type airlock
            //If there is, OpenOrClose().

            
        }

        if (Input.GetMouseButtonDown(1)) //if right click
        {
            //Set selected astronaut's destination to these coordinates.
            
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UnityEngine.Debug.Log("endPos: " + endPos);
            /*
            Astronaut a = selectedObj.GetComponent<Astronaut>();
            a.Walking(endPos);
            UnityEngine.Debug.Log("Agent: " + a);*/

            foreach (Astronaut a in selectedAstronauts)
            {
                UnityEngine.Debug.Log("Setting agent endpoint: " + endPos);
                a.Walking(endPos);
            }
        }


    }
}

/* //Thanks Yoreki https://forum.unity.com/threads/select-one-gameobject-by-click.836002/
 If (Input.GetMouseButtonUp(0))
    {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if(Physics.Raycast(ray, out hit)) // you can also only accept hits to some layer and put your selectable units in this layer
    {
        if(hit.collider.tag == "Player"){
            controlledUnit = hit.transform.gameObject; // if using custom type, cast the result to type here
        } else{
           controlledUnit = null;
        }
    }
}
 */

/*
 public class MoveIndicator : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Follow mouse

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ-90);
        transform.rotation = Quaternion.Euler(playerPos.rotation.x, playerPos.rotation.y, rotZ-90);

        //Set the indicator's position to be a unit away from the player.
        //transform.position = Vector();

        //transform.RotateAround(playerPos.position, Vector3.up, 20 * Time.deltaTime);

    }
}
 */



/*if (Physics2D.Raycast(ray, out hit)) // you can also only accept hits to some layer and put your selectable units in this layer
{
    if (hit.collider.tag == "Astronaut") //Check if you're clicking an astronaut. If you are, then they're selected.
    {
        selectedObj = hit.transform.gameObject;
        UnityEngine.Debug.Log("Astronaut selected.");
    }
    else if (hit.collider.tag == "Airlock") //If not, check if it's a door. If yes, open it.
    {
        hit.transform.gameObject.GetComponent<Airlock>().OpenAndClose();
        //selectedObj = hit.transform.gameObject;
        //selectedObj.GetComponent<Airlock>().OpenAndClose();
        UnityEngine.Debug.Log("Airlock selected.");
    }
    else
    {
        selectedObj = null;
        UnityEngine.Debug.Log("Nothing found to select, deselected.");
    }
}*/

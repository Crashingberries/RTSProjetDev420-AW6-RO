using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour {
    float vitesse = 200f;
    float limite = 10f;


    // Use this for initialization
    void Start () {        
    }

    // Update is called once per frame
    void Update () {

        Vector3 position = transform.position;

        if (Input.GetKey("up") || Input.mousePosition.y >= Screen.height - limite)
        {
            position.z += vitesse * Time.deltaTime;
        }
        if (Input.GetKey("left") || Input.mousePosition.x <=limite)
        {
            position.x -= vitesse * Time.deltaTime;
        }
        if (Input.GetKey("down") || Input.mousePosition.y <= limite)
        {
            position.z -= vitesse * Time.deltaTime;
        }
        if (Input.GetKey("right") || Input.mousePosition.x >= Screen.width - limite)
        {
            position.x += vitesse * Time.deltaTime;
        }


        transform.position = position;
		
    }
}

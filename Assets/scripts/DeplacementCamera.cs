//Alex Thibeault
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour {
    public float vitesse = 200f;
    float limite = 10f;
    public float minX =105f , maxX = 400f;
    public float minZ =-52f, maxZ =348;

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
        position.z =Mathf.Clamp(position.z, minZ, maxZ);
        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
		
    }
}

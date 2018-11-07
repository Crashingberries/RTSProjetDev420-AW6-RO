using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementUnit : MonoBehaviour
{

   
    private Transform UnitActuel;
   
    private bool EstPlace;
   
    // Use this for initialization
   
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

  
    public void ChoisirUnit(GameObject b)
    {
        EstPlace = false;
        UnitActuel = ((GameObject)Instantiate(b)).transform;
    }

}

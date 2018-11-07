using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireUnit : MonoBehaviour
{

    public GameObject[] units;
    

    // Use this for initialization
    void Start()
    {
       // placement = GetComponent<PlacementBatiment>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (GUI.Button(new Rect(Screen.height / 2, Screen.height / 15f + Screen.height / 12f * i, 100, 30), units[i].name))
            {
                //Instantie l'unite a un point predefini
                Instantiate(units[i], new Vector3(137, 0, 450), Quaternion.identity);
            }
        }
    }
}

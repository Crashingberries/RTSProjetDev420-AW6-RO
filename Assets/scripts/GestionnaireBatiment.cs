using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireBatiment : MonoBehaviour {

    public GameObject[] batiments;
    private PlacementBatiment placementBatiment;

	// Use this for initialization
	void Start () {
        placementBatiment = GetComponent<PlacementBatiment>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        for (int i = 0; i < batiments.Length; i++)
        {
            if(GUI.Button(new Rect(Screen.height / 20,Screen.height/15f + Screen.height / 12f * i, 100, 30),batiments[i].name)){
                placementBatiment.ChoisirBatiment(batiments[i]);
            }
        }
    }
}

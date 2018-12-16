using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Batiment : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //private void OnMouseDown()
    //{
    //    ToggleCanvas();
    //}

    public void ToggleCanvas()
    {
        Debug.Log("HUD_BATIMENT : ONMOUSEDOWN");
        GameObject.FindObjectOfType<Hud_Manager>().CanvasActif(gameObject.transform.Find("Canvas").gameObject);

    }
}

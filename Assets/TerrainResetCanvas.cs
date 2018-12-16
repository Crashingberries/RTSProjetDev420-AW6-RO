using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainResetCanvas : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            GameObject.FindObjectOfType<Hud_Manager>().ResetCanvas();
        }
    }
}

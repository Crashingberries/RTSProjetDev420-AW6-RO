using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour {
    public int PV { get; set; }
    public int Armure { get; set; }
    public int PvMax { get; set; }
    public int ArmureMax { get; set; }
    public Position Pos { get; set; }

    private Construction()
    {
        PV = 0; Armure = 0; PvMax = 0; ArmureMax = 0; Pos = new Position();

    }
    private Construction(int PvM)
    {
        PV = PvM; PvMax = PvM; Armure = 0; ArmureMax = 0; Pos = new Position();
    }
    private Construction(int PvM, int AMax)
    {
        PV = PvM; PvMax = PvM; Armure = AMax; ArmureMax = AMax; Pos = new Position() ;
    }
    // Update is called once per frame
    void Update () {
		
	}
    // Use this for initialization
    void Start()
    {

    }
}

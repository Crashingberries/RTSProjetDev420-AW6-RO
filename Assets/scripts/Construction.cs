using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class Construction : MonoBehaviour
    {
        public int PV { get; set; }
        public int Armure { get; set; }
        public int PvMax { get; set; }
        public int ArmureMax { get; set; }
        public Position Pos { get; set; }
        //j'ai ajoute
        public string Nom { get; set; }
        public int CoutOr { get; set; }
        public int CoutBois { get; set; }

        public Construction()
        {
            //ajouté les 3 parametres
            PV = 0; Armure = 0; PvMax = 0; ArmureMax = 0; Pos = new Position(); Nom = ""; CoutOr = 0; CoutBois = 0;

        }

        //j'ai ajoute
        public Construction(int unPV, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois)
        {
            PV = unPV; PvMax = PV; Armure = uneArmure; ArmureMax = Armure; Pos = unePosition; Nom = unNom; CoutOr = unCoutOr; CoutBois = unCoutBois;
        }

        public Construction(int PvM)
        {
            PV = PvM; PvMax = PvM; Armure = 0; ArmureMax = 0; Pos = new Position(); Nom = ""; CoutOr = 0; CoutBois = 0;
        }
        public Construction(int PvM, int AMax)
        {
            PV = PvM; PvMax = PvM; Armure = AMax; ArmureMax = AMax; Pos = new Position(); Nom = ""; CoutOr = 0; CoutBois = 0;
        }

        public void SubirDegats(int _degats)
        {
            if (Armure > 0)
            {
                Armure -= _degats;
                if (Armure < 0)
                {
                    //PV + Armure;
                    Armure = 0;
                }
            }
            else
            {
                PV -= _degats;
                if (PV <= 0)
                {
                    this.Mourir();
                }
            }
        }


        //j'ai ajoute
        public void Mourir()
        {
            //à definir dans Unity
        }

        public void SubirReperations(int _reparations)
        {
            PV += _reparations;
        }

        public void SubirFortifications(int _fortifications)
        {
            Armure += _fortifications;
        }
        // Update is called once per frame
        void Update()
        {

        }
        // Use this for initialization
        void Start()
        {

        }
    }

}
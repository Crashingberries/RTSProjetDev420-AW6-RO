using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    //j'ai renomme la classe Unit en Unite
    public abstract class Unite : Construction
    {
        public int VitesseDeplacement { get; set; }//renomme Vitesse en VitesseDeplacement
        public bool EnDeplacement { get; set; }
        public bool EnAttaque { get; set; }
        public Position PointDeplacement { get; set; } // <- La position ou l'unite est en train de se deplacer
        public object Cible { get; set; } // <- Batiment à attaquer, ressource naturelle à exploiter...
        public int PorteeMin { get; set; }
        public int PorteeMax { get; set; }
        public int PuissanceAttaque { get; set; }//renomme en PuissanceAttaque
        public int VitesseAttaque { get; set; }//j'ai ajoute

        
        

        //public Texture2D MenuIcon { get; set; }

        //j'ai ajoute
        public Unite() : base()
        {
            VitesseDeplacement = 0;
            PuissanceAttaque = 0;
            VitesseAttaque = 0;
            PorteeMin = 0;
            PorteeMax = 0;
            Cible = new Construction();
            PointDeplacement = new Position();
            EnDeplacement = false;
            EnAttaque = false;
        }

        //j'ai ajoute
        public Unite(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois,
            int uneVitesseDeplacement, int unePuissanceAttaque, int unePorteeMin, int unePorteeMax, int uneVitesseAttaque) :
            base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois)
        {
            VitesseDeplacement = uneVitesseDeplacement;
            EnDeplacement = false;
            EnAttaque = false;
            PointDeplacement = null;
            PorteeMin = unePorteeMin;
            PorteeMax = unePorteeMax;
            PuissanceAttaque = unePuissanceAttaque;
            VitesseAttaque = uneVitesseAttaque;
        }

      
        /*public Unite(int PvM, int PaM, Position _pos) : base(PvM, PaM, _pos)
        {
            PV = PvM; PvMax = PvM;
            Armure = PaM; ArmureMax = PaM;
            Pos = new Position();
            VitesseDeplacement = 100;
            EnDeplacement = false;
            EnAttaque = false;
            PointDeplacement = null;
            Cible = null;
            PorteeMax = 0; // nombres Non significatifs... 
            PorteeMin = 0; //
            PuissanceAttaque = 1;   //
        }*/

        /*public Unite(int PvM, int PaM, Position _pos, int _vitesse, bool _enDepl, Position _pointDepl, object _cible, int _attaque) : base(PvM, PaM, _pos)
        {
            PV = PvM; PvMax = PvM;
            Armure = PaM; ArmureMax = PaM;
            Pos = new Position();
            VitesseDeplacement = _vitesse;
            EnDeplacement = _enDepl;
            EnAttaque = false;
            PointDeplacement = _pointDepl;
            Cible = _cible;
            PorteeMax = 0; // nombres Non significatifs... 
            PorteeMin = 0; //
            PuissanceAttaque = _attaque;
        }*/

        public void Deplacer(Position _pos)
        {
            PointDeplacement = _pos;
            EnDeplacement = true;
        }

        public virtual void Attaquer(ref Construction _construction)
        {
            _construction.SubirDegats(PuissanceAttaque);
        }

    }
}
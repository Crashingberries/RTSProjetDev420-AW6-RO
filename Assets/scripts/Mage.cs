using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class Mage : Unite
    {

        public Texture2D image;
        public Mage() : base()
        {

        }

        public Mage(int unPv, int uneArmure, Position unePosition, string unNom, int unCoutOr, int unCoutBois, int uneVitesseDeplacement, int unePuissanceAttaque, int unePorteeMin, int unePorteeMax, int uneVitesseAttaque) :
            base(unPv, uneArmure, unePosition, unNom, unCoutOr, unCoutBois, uneVitesseDeplacement, unePuissanceAttaque, unePorteeMin, unePorteeMax, uneVitesseAttaque)
        {

        }

        public void Attaquer(Construction cible)
        {

        }
    }
}
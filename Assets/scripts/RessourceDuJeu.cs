﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RessourceDuJeu  {

    public static event EventHandler MontantOrChangement;
    public static event EventHandler MontantBoisChangement;
    public static event EventHandler MontantPopChangement;

    private static int montantOr = 10;
    private static int montantBois = 10;
    private static int montantPop = 10;

    public static void SetMontantOr(int montant)
    {
        montantOr += montant;
        if (MontantOrChangement != null) MontantOrChangement(null, EventArgs.Empty);
    }
    
    public static int GetMontantOr()
    {
        return montantOr;
    }

    public static void SetMontantBois(int montant)
    {
        montantBois += montant;
        if (MontantBoisChangement != null) MontantBoisChangement(null, EventArgs.Empty);
    }

    public static int GetMontantBois()
    {
        return montantBois;
    }

    public static void SetMontantPop(int ValeurPop)
    {
        if (montantPop + ValeurPop < 200)
        {
            montantPop += ValeurPop;
        }
        // Else Empecher Action --> Population max atteinte
        if (MontantPopChangement != null) MontantPopChangement(null, EventArgs.Empty);
    }

    public static int GetMontantPop()
    {
        return montantPop;
    }


}

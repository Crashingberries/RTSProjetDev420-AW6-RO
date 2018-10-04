using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RessourceDuJeu  {

    public static event EventHandler MontantOrChangement;

    private static int montantOr;

    public static void IncrementerOr()
    {
        montantOr++;
        if (MontantOrChangement != null) MontantOrChangement(null, EventArgs.Empty);
    }

    public static int GetMontantOr()
    {
        return montantOr;
    }
	
}

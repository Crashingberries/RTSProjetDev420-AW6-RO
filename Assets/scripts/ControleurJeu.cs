using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurJeu : MonoBehaviour {

    private static ControleurJeu instance;
    [SerializeField] private Transform orNode;
    

	private void Awake()
    {
        instance = this;
    }

    private Transform GetRessourceNode()
    {
        return orNode;
    }

    public static Transform GetRessourceNode_Static()
    {
        return instance.GetRessourceNode();
    }
}

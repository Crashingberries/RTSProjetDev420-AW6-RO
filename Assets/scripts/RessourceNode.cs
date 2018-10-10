using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceNode {

    private Transform ressourceNodeTransform;
    public RessourceNode(Transform ressourceNodeTransform)
    {
        this.ressourceNodeTransform = ressourceNodeTransform;
    }
    
    public Vector3 GetPosition()
    {
        return ressourceNodeTransform.position;
    }
    

	
}

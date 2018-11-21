using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireArbre : MonoBehaviour {
    Terrain tmp;
    TerrainData terrain;
    TreeInstance[] treeInstances;
    TreeInstance[] originaltreeInstances;
    private List<TreeInstance> TreeInstances;
    public GameObject ArbreCollider;
    int treesHP = 5;
    GameObject ArbreTmp;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // did we click on a tree?
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            // This ray will see where we clicked er chopped
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Did we hit anything at that point, out as far as 10 units?
            if (Physics.Raycast(ray, out hit,500000))
            {
                // Did we even click er chop on the terrain/tree?
                if (hit.collider.name.Contains("Arbre"))
                {
                    ArbreTmp = hit.collider.gameObject;
                }
             

                // Remove the tree from the terrain tree
                if (treesHP != 0)
                {
                    Debug.Log("Tree's HPs = " + treesHP);
                    treesHP--;
                }
                else
                {
                   /* Debug.Log("HP = 0, destroyed");
                    treesHP = 5;

                    //Remove the tree from the terrain tree
                    TreeInstances.RemoveAt(closestTreeIndex);
                    terrain.treeInstances = TreeInstances.ToArray();

                    // Now refresh the terrain, getting rid of the darn collider
*/
                }
            }
        }
    }
}

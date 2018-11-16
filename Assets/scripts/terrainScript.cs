using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainScript : MonoBehaviour
{
  
    TerrainData terrain;
    TreeInstance[] treeInstances;
    TreeInstance[] originaltreeInstances;
    private List<TreeInstance> TreeInstances;
    int treesHP = 5;

    // Use this for initialization
    private void Start()
    {
        TreeInstances = new List<TreeInstance>(Terrain.activeTerrain.terrainData.treeInstances);
        originaltreeInstances = Terrain.activeTerrain.terrainData.treeInstances;

        Debug.Log("Tree Instances:" + TreeInstances.Count);
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
            if (Physics.Raycast(ray, out hit, 10.0f) && TreeInstances.Count > 0)
            {
                // Did we even click er chop on the terrain/tree?
                if (hit.collider.name != Terrain.activeTerrain.name)
                {
                    
                    // No, must have been a frantic attack on a giant spider >:)
                    return;
                }

                // We hit the "terrain"! Now, how high is the ground at that point?
                float sampleHeight = Terrain.activeTerrain.SampleHeight(hit.point);

                // If the height of the exact point we clicked/chopped at or below ground level, all we did
                // was chop dirt.
                if (hit.point.y <= sampleHeight + 0.01f)
                {
                    
                    return;
                }

                TerrainData terrain = Terrain.activeTerrain.terrainData;
                TreeInstance[] treeInstances = terrain.treeInstances;

                // Our current closest tree initializes to far away
                float maxDistance = float.MaxValue;
                // Track our closest tree's position
                Vector3 closestTreePosition = new Vector3();
                // Let's find the closest tree to the place we chopped and hit something
                int closestTreeIndex = 0;
                for (int i = 0; i < treeInstances.Length; i++)
                {
                    TreeInstance currentTree = treeInstances[i];
                    // The the actual world position of the current tree we are checking
                    Vector3 currentTreeWorldPosition = Vector3.Scale(currentTree.position, terrain.size) + Terrain.activeTerrain.transform.position;

                    // Find the distance between the current tree and whatever we hit when chopping
                    float distance = Vector3.Distance(currentTreeWorldPosition, hit.point);

                    // Is this tree even closer?
                    if (distance < maxDistance)
                    {
                        maxDistance = distance;
                        closestTreeIndex = i;
                        closestTreePosition = currentTreeWorldPosition;
                    }
                }

                // Remove the tree from the terrain tree
                if (treesHP != 0)
                {
                    Debug.Log("Tree's HPs = " + treesHP);
                    treesHP--;
                }
                else
                {
                    Debug.Log("HP = 0, destroyed");
                    treesHP = 5;

                    //Remove the tree from the terrain tree
                    TreeInstances.RemoveAt(closestTreeIndex);
                    terrain.treeInstances = TreeInstances.ToArray();

                    // Now refresh the terrain, getting rid of the darn collider
                    float[,] heights = terrain.GetHeights(0, 0, 0, 0);
                    terrain.SetHeights(0, 0, heights);

                    
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        Terrain.activeTerrain.terrainData.treeInstances = originaltreeInstances;
    }
}
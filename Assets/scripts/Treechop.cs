using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeChop : MonoBehaviour
{
    //This removes trees from the terrain as a sort of LOD system to reduce detail on lower end machines.
    private Terrain[] terrains;

    private TreeInstance[][] treeInstancesOriginal;  //Jagged array that holds a copy of the original trees when a scene is first loaded.

    TreeInstance[] DeepCopyTreeInstances(TreeInstance[] source)
    {
        //A TreeInstance array for all the trees on one of the terrains.
        TreeInstance[] treeInstance = new TreeInstance[source.Length];

        //Iterate over each treeInstance in the source (the original trees in the scene) and copy them into the new treeInstance array:
        for (int i = 0; i < source.Length; i++)
        {
            treeInstance[i].color.a = source[i].color.a;
            treeInstance[i].color.r = source[i].color.r;
            treeInstance[i].color.g = source[i].color.g;
            treeInstance[i].color.b = source[i].color.b;

            treeInstance[i].heightScale = source[i].heightScale;

            treeInstance[i].lightmapColor.a = source[i].lightmapColor.a;
            treeInstance[i].lightmapColor.r = source[i].lightmapColor.r;
            treeInstance[i].lightmapColor.g = source[i].lightmapColor.g;
            treeInstance[i].lightmapColor.b = source[i].lightmapColor.b;

            treeInstance[i].position.x = source[i].position.x;
            treeInstance[i].position.y = source[i].position.y;
            treeInstance[i].position.z = source[i].position.z;

            treeInstance[i].prototypeIndex = source[i].prototypeIndex;

            treeInstance[i].rotation = source[i].rotation;
            treeInstance[i].widthScale = source[i].widthScale;
        }

        return treeInstance;
    }

    void OnLevelWasLoaded()
    {
        print("ModifyTrees");
        terrains = Terrain.activeTerrains;

        //Create the first dimension of the array.  This is indexed by the terrain number.  The second dimension of the array will hold the individual TreeInstances (the trees).
        //This way every terrain in the scene can hold a different number of trees.
        treeInstancesOriginal = new TreeInstance[terrains.Length][];

        //Iterate through all terrains
        for (int iTerrain = 0; iTerrain < terrains.Length; iTerrain++)
        {
            //This creates and fills the second dimension of the jagged array for this terrain:
            treeInstancesOriginal[iTerrain] = DeepCopyTreeInstances(terrains[iTerrain].terrainData.treeInstances);

            //Create a list that will hold the new trees:
            List<TreeInstance> newTreeInstances = new List<TreeInstance>();

            //Go through each tree in this terrain and add it to our new list, skipping every other tree for starters:
            for (int iTree = 0; iTree < treeInstancesOriginal[iTerrain].Length; iTree += 2)
            {
                newTreeInstances.Add(treeInstancesOriginal[iTerrain][iTree]);
            }

            //Point the terrain data to the new list of trees:
            terrains[iTerrain].terrainData.treeInstances = new TreeInstance[newTreeInstances.Count];
            terrains[iTerrain].terrainData.treeInstances = newTreeInstances.ToArray();
        }

    }

    public void RestoreTrees()
    {
        print("RestoreTrees");
        ////Restore the original trees
        for (int iTerrain = 0; iTerrain < terrains.Length; iTerrain++)
        {
            terrains[iTerrain].terrainData.treeInstances = treeInstancesOriginal[iTerrain];
        }

    }

}

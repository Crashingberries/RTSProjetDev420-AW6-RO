using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class RecolteBois : MonoBehaviour
{

    // Player, Range
    public int harvestTreeDistance;        // Set [Inspector] min. distance from Player to Tree for your scale?
    public bool rotateOuvrier = true;    // Should we rotate the player to face the Tree? 
    private Transform myTransform;        // Player transform for cache
    
    // Terrains, Hit
    private Terrain terrain;            // Derived from hit...GetComponent<Terrain>
    private RaycastHit hit;                // For hit. methods
    private string lastTerrain;            // To avoid reassignment/GetComponent on every Terrain click

    // Tree, GameManager
        // Prefab to spawn at terrain tree loc for TIIIIIIMBER!
    private GestionnaireRessource rMgr;    // Resource manager script
    public float respawnTimer;            // Duration of terrain tree respawn timer
    public List<TreeInstance> newTrees = new List<TreeInstance>();
    void Start()
    {


     

        if (harvestTreeDistance <= 0)
        {
            Debug.Log("harvestTreeDistance unset in Inspector, using value: 6");
            harvestTreeDistance = 6;
        }

        if (respawnTimer <= 0)
        {
            Debug.Log("respawnTimer unset in Inspector, using quick test value: 15");
            respawnTimer = 15;
        }

        myTransform = transform;
        lastTerrain = null;
        rMgr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GestionnaireRessource>();

    }


    void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f))
            {

                // Did we click a Terrain?
                if (hit.collider.gameObject.GetComponent<Terrain>() == null)
                {
                    
                    return;
                }
                               // Did we click on the same Terrain as last time (or very first time?)
                if (lastTerrain == null || lastTerrain != hit.collider.tag)
                {
                    
                    terrain = hit.collider.gameObject.GetComponent<Terrain>();
                    Debug.Log("Ca devrait cliquer");
                    lastTerrain = terrain.name;
                }

                // Was it the terrain or a terrain tree, based on SampleHeight()
                float groundHeight = terrain.SampleHeight(hit.point);

                if (hit.point.y - .2f > groundHeight)
                {

                    // It's a terrain tree, check Proximity and Harvest
                    if (CheckProximity())
                    {
                        Debug.Log("ca devrait recolter");
                        HarvestWood();
                        
                    }
              

                }
            }
        }
    }


    private bool CheckProximity()
    {
        Debug.Log("La proximite est checker");
        bool inRange = true;
        float clickDist = Vector3.Distance(myTransform.position, hit.point);

        if (clickDist > harvestTreeDistance)
        {
            Debug.Log("Out of Range");
            inRange = false;
        }

        return inRange;
      

    }

    private bool CheckRecentUsage(string _terrainName, int _treeINDEX)
    {
        bool beenUsed = false;

        for (int cnt = 0; cnt < rMgr.managedTrees.Count; cnt++)
        {
            if (rMgr.managedTrees[cnt].terrainName == _terrainName && rMgr.managedTrees[cnt].treeINDEX == _treeINDEX)
            {
                Debug.Log("Tree has been used recently");
                beenUsed = true;
            }
        }

        return beenUsed;
    }


    private void HarvestWood()
    {
        
        int treeIDX = -1;
        int treeCount = terrain.terrainData.treeInstances.Length;
        float treeDist = harvestTreeDistance;
        Vector3 treePos = new Vector3(0, 0, 0);

        // Notice we are looping through every terrain tree, 
        // which is a caution against a 15,000 tree terrain


        // var newTrees = new List<TreeInstance>(terrain.terrainData.treeInstances);
        //TreeChop treeChop = FindObjectOfType<TreeChop>();
        
        
     //Copie de mon treeInstance dans mon newTrees mais index out of range
       
        
        /* for (int cnt = 0; cnt < treeCount; cnt++)
        {
            newTrees[cnt] = terrain.terrainData.treeInstances[cnt];
        }*/


            for (int cnt = 0; cnt<treeCount; cnt++)
        {

            Vector3 thisTreePos = Vector3.Scale(terrain.terrainData.treeInstances[cnt].position, terrain.terrainData.size) + terrain.transform.position;
            float thisTreeDist = Vector3.Distance(thisTreePos, hit.point);
           

            if (thisTreeDist < treeDist)
            {
                treeIDX = cnt;
                treeDist = thisTreeDist;
                treePos = thisTreePos;
                Recolte.enRecolteBois = true;
              
                // Code qui devrait remplacer mon instance de terrain par mon array newTrees ou l'arbre viser devrait avoir disparu
                /*newTrees.RemoveAt(treeIDX);
                
                terrain.terrainData.treeInstances = newTrees.ToArray();
                float[,] heights = terrain.terrainData.GetHeights(0, 0, 0, 0);
                terrain.terrainData.SetHeights(0, 0, heights);*/                

                break;
                


            }
            
        }


        if (treeIDX == -1)
        {
            Debug.Log("Out of Range");
            return;
        }

        if (!CheckRecentUsage(terrain.name, treeIDX))
        {

            // Success - all tests passed
            // Place a cube to show the tree, the ResourceManager will remove it after a time
            // Obviously tweak to your liking, just a visual aid to show it worked
           
            GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
            marker.transform.position = treePos;
            Debug.Log("Ca se rend ici?");
            // Example of spawning a placed tree at this location, just for demo purposes
            // it will slide through terrain and disappear in 4 seconds
           

           
            // Add this terrain tree and cube to our Resource Manager for demo purposes
            rMgr.AddTerrainTree(terrain.name, treeIDX, Time.time + respawnTimer, marker.transform);

            if (rotateOuvrier)
            {
                Vector3 lookRot = new Vector3(hit.point.x, myTransform.position.y, hit.point.z);
                myTransform.LookAt(lookRot);
            }

        }
    }
    
}
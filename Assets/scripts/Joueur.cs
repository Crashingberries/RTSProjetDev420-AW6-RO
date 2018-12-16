using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



public class Joueur : NetworkBehaviour
{
    public GameObject cameraJ1, cameraJ2, ouvrierStart, baseStart, JoueurManager, BatimentTmp;
    public Material MatJ1, MatJ2;
    Material MatJoueur;
    public int Num; //{ get; set; }
    public string Nom; //{ get; set; }
    public string Couleur;//{ get; set; }
    public bool Vaincu; //{ get; set; } // <- Si le joueur a perdu OU declare forfait
    public bool Vainqueur; //{ get; set; } // <- Si le joueur a gagne (il est le seul restant...)



    public Joueur()
    {
        Num = 0;
        Nom = "";
        Couleur = "blanc";
        Vaincu = false;
        Vainqueur = false;
    }

    public Joueur(int _num, string _nom)
    {
        Num = _num;
        Nom = _nom;
        Vaincu = false;
        Vainqueur = false;
        switch (Num)
        {
            case 1:
                Couleur = "Rouge";
                break;
            case 2:
                Couleur = "Bleu";
                break;
            case 3:
                Couleur = "Vert";
                break;
            case 4:
                Couleur = "Bleu clair";
                break;
            case 5:
                Couleur = "Jaune";
                break;
            case 6:
                Couleur = "Mauve";
                break;
            case 7:
                Couleur = "Orange";
                break;
            case 8:
                Couleur = "Brun";
                break;
        }
    }
    //===========================================
    // Actions joueur
    //===========================================
    public void Abandonner()
    {
        Vaincu = true;
    }

    private void Start()
    {

        if (!isServer)
        {
            if (isLocalPlayer)
            {
                Debug.Log("Joueur::Start -- Joueur2");
                gameObject.tag = ("Joueur2");
                Instantiate(cameraJ2);
                CmdSpawnJoueur2();
                MatJoueur = MatJ2;
            }
        }
        else
        {
            if (isLocalPlayer)
            {
                Debug.Log("Joueur::Start -- Joueur1");
                gameObject.tag = ("Joueur1");
                Instantiate(cameraJ1);
                CmdSpawnJoueur1();
                MatJoueur = MatJ1;
            }
        }

    }
    [Command]
    void CmdSpawnJoueur1()
    {
        GameObject go = Instantiate(JoueurManager);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        go = Instantiate(baseStart, new Vector3(84.4f, 0, 409.3f), Quaternion.Euler(0, 0, 0));
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        NetworkIdentity Base = go.GetComponent<NetworkIdentity>();
        go = Instantiate(ouvrierStart, new Vector3(59.26f, 0, 427.09f), Quaternion.Euler(0, 0, 0));
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        NetworkIdentity Ouvrier = go.GetComponent<NetworkIdentity>();
        RpcSpawnTag(Base, Ouvrier);
    }
    [Command]
    void CmdSpawnJoueur2()
    {
        GameObject go = Instantiate(JoueurManager);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        go = Instantiate(baseStart, new Vector3(406.9f, 0, 96.3f), Quaternion.Euler(0, 0, 0));
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        NetworkIdentity Base = go.GetComponent<NetworkIdentity>();
        go = Instantiate(ouvrierStart, new Vector3(431.29f, 0, 64.9f), Quaternion.Euler(0, 0, 0));
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        NetworkIdentity Ouvrier = go.GetComponent<NetworkIdentity>();
        RpcSpawnTag(Base, Ouvrier);
    }
    [ClientRpc]
    void RpcSpawnTag(NetworkIdentity b, NetworkIdentity o)
    {
        if (gameObject.tag == "Untagged") { gameObject.tag = "Joueur2"; }
        Material mat;
        b.gameObject.tag = gameObject.tag;
        o.gameObject.tag = gameObject.tag + "Unit";
        o.gameObject.transform.Find("Quad").gameObject.tag = gameObject.tag + "Unit";
        for (int x = 0; x < o.gameObject.transform.childCount; x++)
        {
            if (o.gameObject.tag == "Joueur1Unit")
            {
                mat = MatJ1;
            }
            else
            {
                mat = MatJ2;
            }
            if (o.gameObject.transform.GetChild(x).name.Contains("WK"))
            {

                SkinnedMeshRenderer tmp = o.gameObject.transform.GetChild(x).gameObject.GetComponent<SkinnedMeshRenderer>();
                tmp.material = mat;
            }
        }
    }
    public void SetAuth(NetworkInstanceId objectId, NetworkIdentity player)
    {
        CmdSetAuth(objectId, player);
    }
    [Command]
    public void CmdSetAuth(NetworkInstanceId objectId, NetworkIdentity player)
    {
        var iObject = NetworkServer.FindLocalObject(objectId);
        var networkIdentity = iObject.GetComponent<NetworkIdentity>();
        var otherOwner = networkIdentity.clientAuthorityOwner;

        if (otherOwner == player.connectionToClient)
        {
            return;
        }
        else
        {
            if (otherOwner != null)
            {
                networkIdentity.RemoveClientAuthority(otherOwner);
            }
            networkIdentity.AssignClientAuthority(player.connectionToClient);
        }
    }
    /*
     *Fonctions qui permettent de gérer la mine
     * 
     * Ce premier bloc sert à la destruction de celle-ci une fois qu'elle est vide de ressources.
     */

    public void DetruireRessource(NetworkIdentity m)
    {
        Debug.Log("Joueur::DetruireRessource");

        CmdDetruireMine(m);
    }
    [Command]
    void CmdDetruireMine(NetworkIdentity m)
    {
        Debug.Log("Joueur::CmdDetruireRessource");

        RpcDetruireMine(m);
        Destroy(m.gameObject);
    }
    [ClientRpc]
    void RpcDetruireMine(NetworkIdentity m)
    {
        Debug.Log("Joueur::RpcDetruireRessource");

        Destroy(m.gameObject);
    }

    /*
     * Ce deuxième bloc gère l'update des ressources de la mine à travers le serveur. De cette façon, lorsque la valeur de la mine change, 
     * celle-ci est mise à jour sur le serveur.
     */
    public void UpdateRessource(int valeur, NetworkIdentity ress)
    {
        Debug.Log("Joueur::UpdateRessource");
        CmdUpdateRessource(valeur, ress);
    }
    [Command]
    void CmdUpdateRessource(int valeur, NetworkIdentity ress)
    {
        Debug.Log("Joueur::CmdUpdateRessource");
        if (ress.gameObject.GetComponent<Minerai>() != null)
        {
            ress.gameObject.GetComponent<Minerai>().Ressources -= valeur;
        }
        else
        {
            ress.gameObject.GetComponent<Arbre>().Ressources -= valeur;
        }
        RpcUpdateRessource(valeur, ress);
    }
    [ClientRpc]
    void RpcUpdateRessource(int valeur, NetworkIdentity ress)
    {
        Debug.Log("Joueur::RpcUpdateRessource");
        if (ress.gameObject.GetComponent<Minerai>() != null)
        {
            ress.gameObject.GetComponent<Minerai>().Ressources -= valeur;
        }
        else
        {
            ress.gameObject.GetComponent<Arbre>().Ressources -= valeur;
        }
    }

    public void ActionCreationBatiment(int placement, Vector3 pos)
    {
        CmdActionCreationBatiment(placement, pos);
    }
    [Command]
    public void CmdActionCreationBatiment(int placement, Vector3 pos)
    {
        Debug.Log("Joueur :: CmdActionCreationBatiment");
        GameObject tmp = JoueurManager.GetComponent<PlacementBatiment>().ListeBatiment[placement];
        GameObject go = Instantiate(tmp, pos, tmp.transform.rotation);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        BatimentTmp = go;
        BatimentTmp.transform.Find("Quad").gameObject.SetActive(false);
        RpcActionCreationBatiment(BatimentTmp.GetComponent<NetworkIdentity>(), pos);
        StartCoroutine(EnConstruction(BatimentTmp, pos));
    }
    [ClientRpc]
    void RpcActionCreationBatiment(NetworkIdentity UpdateVisuel, Vector3 pos)
    {
        Debug.Log("Joueur :: RpcActionCreationBatiment");
        BatimentTmp = UpdateVisuel.gameObject;
        BatimentTmp.transform.Find("Quad").gameObject.SetActive(false);
        StartCoroutine(EnConstruction(BatimentTmp, pos));
    }

    IEnumerator EnConstruction(GameObject batimentActuel, Vector3 placement)
    {
        //batimentActuel.transform.Find("Quad").gameObject.SetActive(false);
        Transform f = batimentActuel.transform.Find("Canvas");
        for (float i = 10; i >= 0; i = i - 0.3f)
        {
            Vector3 newPos = new Vector3(placement.x, placement.y - i, placement.z);
            batimentActuel.transform.position = newPos;
            yield return new WaitForSeconds(0.2f);
        }
        if (isLocalPlayer)
        {
            f.gameObject.SetActive(true);
        }
    }

    public void CreerUnit(int placement, Vector3 pos)
    {
        CmdCreerUnit(placement, pos);
    }
    [Command]
    void CmdCreerUnit(int placement, Vector3 pos)
    {
        Debug.Log("JOUEUR:: CmdCreerUnit ==>" + gameObject.tag);
        GameObject tmp = JoueurManager.GetComponent<PlacementBatiment>().ListeUnit[placement];
        tmp.tag = gameObject.tag + "Unit";
        tmp.transform.Find("Quad").tag = gameObject.tag + "Unit";
        Material mat;
        for (int x = 0; x < tmp.transform.childCount; x++)
        {
            if (tmp.tag == "Joueur1Unit")
            {
                mat = MatJ1;
            }
            else
            {
                mat = MatJ2;
            }
            if (tmp.transform.GetChild(x).name.Contains("WK"))
            {

                SkinnedMeshRenderer MeshTmp = tmp.transform.GetChild(x).gameObject.GetComponent<SkinnedMeshRenderer>();
                MeshTmp.material = mat;
            }
        }
        GameObject go = Instantiate(tmp, pos, tmp.transform.rotation);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        RpcCreerUnitInfo(go.GetComponent<NetworkIdentity>(), gameObject.tag);
    }
    [ClientRpc]
    void RpcCreerUnitInfo(NetworkIdentity id, string JoueurTag)
    {
        Debug.Log("JOUEUR:: RpcCreerUnitInfo ==>"+JoueurTag);
        id.gameObject.tag = JoueurTag + "Unit";
        id.gameObject.transform.Find("Quad").tag = JoueurTag + "Unit";
        Material mat;
        for (int x = 0; x < id.gameObject.transform.childCount; x++)
        {
            if (id.gameObject.tag == "Joueur1Unit")
            {
                mat = MatJ1;
            }
            else
            {
                mat = MatJ2;
            }
            if (!id.gameObject.transform.GetChild(x).name.Contains("Quad")&& !id.gameObject.transform.GetChild(x).name.Contains("Sphere"))
            {

                SkinnedMeshRenderer MeshTmp = id.gameObject.transform.GetChild(x).gameObject.GetComponent<SkinnedMeshRenderer>();
                if (MeshTmp != null) { MeshTmp.material = mat; }
                
            }
        }
    }

}

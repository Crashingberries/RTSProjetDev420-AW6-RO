using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RTS
{
    public class RectangleSelection: MonoBehaviour
    {
        //ajoute toutes les unités de la scène
        public GameObject[] toutesUnites;

        //le rectangle qui va être créé
        public RectTransform rectangleSelectionTrans;

        /*pour le debug
        public Transform sphere1;
        public Transform sphere2;
        public Transform sphere3;
        public Transform sphere4;
        */

        public Material matNormal;
        public Material matHighlight;
        public Material matSelection;

        [System.NonSerialized]
        public List<GameObject> uniteSelectionnees = new List<GameObject>();

        GameObject highlightCetteUnite;

        float delais = 0.15f;
        float tempsDeClick = 0f;

        Vector3 rectanglePositionDepart;
        Vector3 rectanglePositionFin;

        bool aCreeRectangle;

        Vector3 hautGauche, hautDroit, basGauche, basDroit;

        
        const int CLIC_DROIT = 1;

        void Start()
        {
            //désactive le rectangle
            rectangleSelectionTrans.gameObject.SetActive(false);
        }

        void Update()
        {
            toutesUnites= GameObject.FindGameObjectsWithTag("Friendly");
            SelectionnerUnites();
            HighlightUnite();
            if (Input.GetMouseButton(CLIC_DROIT))
            {
                MouvementUnite();
            }
        }

        void SelectionnerUnites()
        {
            bool enTrainDeCliquer = false;
            bool enTrainDeMaintenir = false;

            if (Input.GetMouseButtonDown(0))
            {
                tempsDeClick = Time.time;

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f, 1 << 8))
                {
                    rectanglePositionDepart = hit.point;
                    //log
                    Debug.Log(rectanglePositionDepart);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - tempsDeClick <= delais)
                {
                    enTrainDeCliquer = true;
                }

                if (aCreeRectangle)
                {
                    aCreeRectangle = false;

                    rectangleSelectionTrans.gameObject.SetActive(false);

                    uniteSelectionnees.Clear();

                    for (int i = 0; i < toutesUnites.Length; i++)
                    {
                        GameObject uniteActuelle = toutesUnites[i];
                        if (EstDansPolygone(uniteActuelle.transform.position))
                        {
                            uniteActuelle.GetComponent<MeshRenderer>().material = matSelection;
                            if (uniteActuelle.name != "Quad")
                            {
                                uniteSelectionnees.Add(uniteActuelle);
                                //log
                                Debug.Log(uniteActuelle + "à été ajouté(e) dans la sélection");
                            }
                        }
                        else
                        {
                            uniteActuelle.GetComponent<MeshRenderer>().material = matNormal;
                        }
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (Time.time - tempsDeClick > delais)
                {
                    enTrainDeMaintenir = true;
                }
            }
            if (enTrainDeCliquer)
            {
                for (int i = 0; i < uniteSelectionnees.Count; i++)
                {
                    uniteSelectionnees[i].GetComponent<MeshRenderer>().material = matNormal;
                }

                uniteSelectionnees.Clear();

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f))
                {
                    if (hit.collider.CompareTag("Friendly"))
                    {
                        GameObject uniteActive = hit.collider.gameObject;
                        uniteActive.GetComponent<MeshRenderer>().material = matSelection;
                        uniteSelectionnees.Add(uniteActive);
                    }
                }
            }

            if (enTrainDeMaintenir)
            {
                if (!rectangleSelectionTrans.gameObject.activeInHierarchy)
                {
                    rectangleSelectionTrans.gameObject.SetActive(true);
                }

                rectanglePositionFin = Input.mousePosition;

                AfficherRectangle();
                if (aCreeRectangle)
                {
                    for (int i = 0; i < toutesUnites.Length; i++)
                    {
                        
                        GameObject uniteActuelle = toutesUnites[i];

                        if (EstDansPolygone(uniteActuelle.transform.position))
                        {
                            uniteActuelle.GetComponent<MeshRenderer>().material = matHighlight;
                        }
                        else
                        {
                            uniteActuelle.GetComponent<MeshRenderer>().material = matNormal;
                        }
                    }
                }
            }
        }

        void HighlightUnite()
        {
            if (highlightCetteUnite != null)
            {
                bool estSelectionne = false;
                for  (int i = 0; i< uniteSelectionnees.Count; i++)
                {
                    if(uniteSelectionnees[i] == highlightCetteUnite)
                    {
                        estSelectionne = true;
                        break;
                    }
                }

                if (!estSelectionne)
                {
                    highlightCetteUnite.GetComponent<MeshRenderer>().material = matNormal;
                }

                highlightCetteUnite = null;
            }

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f))
            {
                if (hit.collider.CompareTag("Friendly"))
                {
                    GameObject objActuel = hit.collider.gameObject;

                    bool estSelectionne = false;
                    for(int i =0; i<uniteSelectionnees.Count; i++)
                    {
                        if (uniteSelectionnees[i] == objActuel)
                        {
                            estSelectionne = true;
                            break;
                        }
                    }
                
                    if (!estSelectionne)
                    {
                        highlightCetteUnite = objActuel;

                        highlightCetteUnite.GetComponent<MeshRenderer>().material = matHighlight;
                    }
                }
            }
        }

        bool EstDansPolygone(Vector3 positionUnite)
        {
            bool estDansPolygone = false;

            if (EstDansTriangle(positionUnite, hautGauche, basGauche, hautDroit))
            {
                return true;
            }

            if (EstDansTriangle(positionUnite, hautDroit, basGauche, basDroit))
            {
                return true;
            }
            //log
            Debug.Log(estDansPolygone);
            return estDansPolygone;
        }

        bool EstDansTriangle(Vector3 p, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            bool estDansTriangle = false;

            float denominateur = ((p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z));
            float a = ((p2.z - p3.z) * (p.x - p3.x) + (p3.x - p2.x) * (p.z - p3.z)) / denominateur;
            float b = ((p3.z - p1.z) * (p.x - p3.x) + (p1.x - p3.x) * (p.z - p3.z)) / denominateur;
            float c = 1 - a - b;

            if (a >= 0f && a <= 1f && b >= 0f && b <= 1f && c >= 0f && c <= 1f)
            {
                estDansTriangle = true;
            }

            return estDansTriangle;
        }

        void AfficherRectangle()
        {
            Vector3 rectangleStartScreen = Camera.main.WorldToScreenPoint(rectanglePositionDepart);

            rectangleStartScreen.z = 0f;

            Vector3 milieu = (rectangleStartScreen + rectanglePositionFin) / 2f;

            rectangleSelectionTrans.position = milieu;

            float sizeX = Mathf.Abs(rectangleStartScreen.x - rectanglePositionFin.x);
            float sizeY = Mathf.Abs(rectangleStartScreen.y - rectanglePositionFin.y);

            rectangleSelectionTrans.sizeDelta = new Vector2(sizeX, sizeY);

            hautGauche = new Vector3(milieu.x - sizeX / 2f, milieu.y + sizeY / 2f, 0f);
            hautDroit = new Vector3(milieu.x + sizeX / 2f, milieu.y + sizeY / 2f, 0f);
            basGauche = new Vector3(milieu.x - sizeX / 2f, milieu.y - sizeY / 2f, 0f);
            basDroit = new Vector3(milieu.x + sizeX / 2f, milieu.y - sizeY / 2f, 0f);

            RaycastHit hit;
            int i = 0;
            bool a = false;
            bool b = false;
            bool c = false;
            bool d = false;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(hautGauche), out hit, 200f, 1 << 8))
            {
                hautGauche = hit.point;
                i++;
                //log
                Debug.Log(hautGauche);
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(hautDroit), out hit, 200f, 1 << 8))
            {
                hautDroit = hit.point;
                i++;
                //log
                Debug.Log(hautDroit);
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(basGauche), out hit, 200f, 1 << 8))
            {
                basGauche = hit.point;
                i++;
                //log
                Debug.Log(basGauche);
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(basDroit), out hit, 200f, 1 << 8))
            {
                basDroit = hit.point;
                i++;
                //log
                Debug.Log(basDroit);
            }

            aCreeRectangle = false;
            if (i == 4)
            {
                /*sphere1.position = hautGauche;
                sphere2.position = hautDroit;
                sphere3.position = basGauche;
                sphere4.position = basDroit;*/

                aCreeRectangle = true;
            }
            
        }
        public void MouvementUnite()
        {
            foreach (GameObject element in uniteSelectionnees)
            {
                //log
                Debug.Log(element.name+"s'est mis à bouger");
                element.GetComponent<PlayerMovements>().SetPositionCible();
            }
        }
    }
}
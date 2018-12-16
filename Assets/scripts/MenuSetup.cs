using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RTS
{
    public class MenuSetup : MonoBehaviour
    {

        public GameObject allie;
        public bool UpdateGui = false;
        public static List<Texture2D> UnitIconTextures = new List<Texture2D>();
        
        GUIContent content;
        
        public string Description;
     
        public GameObject MainCamRS;

        private RectangleSelection rs;
        public List<GameObject> ListeUnite;

        void Start()
        {

            rs = MainCamRS.GetComponent<RectangleSelection>();
            ListeUnite = rs._uniteSelectionnees;
        }
        void OnGUI()
        {
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 70, 375, 70),"");
            using (var areaScope = new GUILayout.AreaScope(new Rect(Screen.width / 2 - 300, Screen.height - 70, 375, 70)))
            {
               
                GUILayout.BeginHorizontal(GUILayout.Width(Screen.width / 2 - 200));
                GUILayout.FlexibleSpace();

                if ((ListeUnite.Count) == 1)
                {
                  
                    Description = ListeUnite[0].name + System.Environment.NewLine + ListeUnite[0].transform.Find("Canvas").Find("Slider").gameObject.GetComponent<Slider>().value+"/100";
                    content = new GUIContent(Description, ListeUnite[0].GetComponent<PlayerMovements>().image);
                    GUILayout.Box(content);
                
                }


                else if ((ListeUnite.Count) > 1)
                {
                  
                    foreach (GameObject go in ListeUnite)
                    {
                        if (go != null)
                        {
                            content = new GUIContent(go.GetComponent<PlayerMovements>().image);
                        }
                        

                        GUILayout.Box(content);
                       
                    }
                }


                if (UpdateGui)
                {
                    for (int i = 0; i < ListeUnite.Count; i++)
                    {
                        Debug.Log("Test: Nombre d'unites selectionnes: " + i);
                                               
                            var ouv = ListeUnite[i].GetComponent<PlayerMovements>();

                            UnitIconTextures.Add(ouv.image);
                        Debug.Log("Test: Y a t-il "+i+" Icones ?");
                    }
                    
                    Debug.Log("Test: Arret");
                    UpdateGui = false;

                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                
                //GUILayout.EndArea();
            }

        }
    }
}
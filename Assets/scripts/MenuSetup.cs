using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class MenuSetup : MonoBehaviour
    {

        public GameObject allie;
        public bool UpdateGui = false;
        public static List<Texture2D> UnitIconTextures = new List<Texture2D>();
        
        GUIContent content;
        
        public string Description;
        //GameObject Rectangle selection
        public GameObject MainCamRS;

        private RectangleSelection rs;
        public List<GameObject> ListeUnite;

        void Start()
        {

            rs = MainCamRS.GetComponent<RectangleSelection>();
            ListeUnite = rs._uniteSelectionnees;
            MainCamRS = GameObject.Find("Main Camera");
        }

        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                ListeUnite.Clear();
                GUI.enabled = false;
                UnitIconTextures.Clear();


            }
        }
        void OnGUI()
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 70, 400, 70),"");
            using (var areaScope = new GUILayout.AreaScope(new Rect(Screen.width / 2 - 200, Screen.height - 70, 400, 70)))
            {
                //GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 200));
                GUILayout.BeginHorizontal(GUILayout.Width(Screen.width / 2 - 200));
                GUILayout.FlexibleSpace();

                if ((UnitIconTextures.Count) == 1)
                {
                  
                    Description = "ouvrier " + System.Environment.NewLine + "100/100";
                    content = new GUIContent(Description, UnitIconTextures[0]);
                    GUILayout.Box(content);
                
                }


                else if ((UnitIconTextures.Count) > 1)
                {
                  
                    foreach (Texture2D image in UnitIconTextures)
                    {
                        //image.Compress(true);
                        //if (UnitIconTextures.Count > 5)
                        //{
                        //    image.Resize(10, 10);
                        //    image.Apply();
                           
                        //}
                        //if (UnitIconTextures.Count > 10)
                        //{
                        //    image.Resize(10, 10);
                        //    image.Apply();
                       
                        //}
                        content = new GUIContent(image);

                        GUILayout.Box(content);
                       
                    }
                }


                if (UpdateGui)
                {
                    for (int i = 0; i < ListeUnite.Count; i++)
                    {
                        Debug.Log("Test des i :" + i);
                        if (ListeUnite[i].GetComponent<ouvrier>() != null)
                        {
                           
                            var ouv = ListeUnite[i].GetComponent<ouvrier>();

                            UnitIconTextures.Add(ouv.Image);
                      
                        }
                    }
                    
                    Debug.Log("jte criss les break");
                    UpdateGui = false;

                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                
                //GUILayout.EndArea();
            }

        }
    }
}
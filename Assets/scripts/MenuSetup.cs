using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS {
    public class MenuSetup : MonoBehaviour
    {

        public GameObject allie;
       
        public static List<Texture2D> UnitIconTextures = new List<Texture2D>();
        GUIContent content;
        public string Description;
        //GameObject Rectangle selection
        public GameObject MainCamRS;
        
        public RectangleSelection rs;
        public List<GameObject> ListeUnite;
        
        void Start()
        {
            MainCamRS = GameObject.Find("Main Camera");
            rs = MainCamRS.GetComponent<RectangleSelection>();
           
            ListeUnite = rs._uniteSelectionnees;
            
            for (int i = 0; i < ListeUnite.Count; i++)
            {

            }
            //Ca fonctionne sous ce commentaire
            Description = "         " + "ouvrier" + System.Environment.NewLine + "         100/100";
            allie = GameObject.Find("Allie");
            if (allie != null)
            {
                var ouv1 = allie.GetComponent<ouvrier>();
               
                UnitIconTextures.Add(item: ouv1.Image);
                Debug.Log("Nombre icon dans liste: " + UnitIconTextures.Count);
                if ((UnitIconTextures.Count) == 1)
                {
                    content = new GUIContent(Description, UnitIconTextures[0]);
                    
                }



            }
        }
        void OnGUI()
        {
            //Debug.Log("nombre unite: " + ListeUnite.Count);
            //for (int i = 0; i < RectangleSelection._uniteSelectionnees.Count); i++) 




            //GUIStyle Container = new GUIStyle();
           // GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height - 300, 400, 100),UnitIconTextures[0]);
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 200),content);
        }

    }
}
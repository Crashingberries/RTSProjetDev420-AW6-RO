using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class AttaqueManager : MonoBehaviour {

//    public GameObject attaquant;
//    public GameObject cible;
//    private GameObject cibleAReparer;
//    public Slider PvBar;

//    public int ATTAQUE;
//    public int RANGE;
//    public float VIT_ATTAQUE;
//    public bool ALERTE;
//    public bool BATIMENT;

//    private Collider[] ennemis;

//    private HealthManager pv_ennemi;
//    private Rigidbody r_attaquant;
//    public AudioSource _se_degats;
//    public AudioSource _se_detruit;
//    private bool detruit = false;
//    private float nextfire;

//    private bool placer_cible_reparer = false;
//    private bool en_reparation = false;
//    public GameObject icon_reparer;

//    public Animator anim;

//    // Use this for initialization
//    void Start () {
//        anim = attaquant.GetComponent<Animator>();
//        r_attaquant = attaquant.GetComponent<Rigidbody>();
//    }
	
//	// Update is called once per frame
//	void Update () {
//        UpdateCilblesPossibles();
//        if (ALERTE) { Attaquer(GetCible()); }
//        //for (int i = 0; i < ennemis.Length; i++)
//        //{
//        //    if (ennemis[i] != null) { print(ennemis[i].gameObject); }
//        //}

//        if (placer_cible_reparer)
//        {
//            icon_reparer.transform.position = GetMousePosition();
//        }
//    }

//    public void UpdateCilblesPossibles()
//    {
//        ennemis = Physics.OverlapSphere(attaquant.transform.position, RANGE);
//        for (int i = 0; i < ennemis.Length; i++)
//        {
//            if (ennemis[i].gameObject.GetComponent<AttaqueManager>() == null || ennemis[i].gameObject == attaquant)
//            {
//                ennemis[i] = null;
//            }
//        }
//    }

//    public AttaqueManager GetCible()
//    {
//        for (int i = 0; i < ennemis.Length; i++)
//        {
//            AttaqueManager am_cible = null;
//            if (ennemis[i] != null)
//            {
//                am_cible = ennemis[i].gameObject.GetComponent<AttaqueManager>();
//            }
//            if (am_cible != null)
//            {
//                cible = ennemis[i].gameObject;
//                return am_cible;
//            }
//        }
//        return null;
//    }

//    public void Attaquer(AttaqueManager _cible)
//    {
//        if (_cible != null)
//        {
//            anim.SetBool("Attaque", true);
//            anim.SetBool("Attaque", false);
//            if (Time.time > nextfire)
//            {
//                //print("Attaque : " + cible.name + ", PV : " + _cible.PvBar.name);
//                nextfire = Time.time + VIT_ATTAQUE;

//                if (_cible.PvBar.value >= 0)
//                {
//                    anim.SetBool("Attaque", true);
//                    // _se_degats.Play();
//                    if (true)
//                    {
//                        _cible.PvBar.value -= ATTAQUE;
//                    }
//                    cible.GetComponent<Animator>().SetTrigger("SubirDegat");
//                    if (_cible.PvBar.value <= 0)
//                    {
//                        _cible.GetComponent<Animator>().SetTrigger("EstMort");
//                        Destroy(GameObject.Find(_cible.PvBar.name));
//                        Destroy(cible);
//                    }
//                }
//            }
//        }
//    }

//    public void PlacerCibleAReparer()
//    {
//        if (placer_cible_reparer) { placer_cible_reparer = false; icon_reparer.SetActive(false); }
//        else { placer_cible_reparer = true; icon_reparer.SetActive(true); }
//    }







//    private Vector3 GetMousePosition()
//    {
//        Vector3 pos = new Vector3();
//        Plane plane = new Plane(Vector3.up, transform.position);
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        float point = 0f;
//        if (plane.Raycast(ray, out point))
//        {
//            pos = ray.GetPoint(point);
//        }
//        return pos;
//    }

//    /* NON UTILISÉ POUR LE MOMENT */

//    public void Alerter()
//    {
//        //if((r_attaquant.position.x - cible.position.x <= rayon && r_attaquant.position.x - cible.position.x >= -rayon) && (r_attaquant.position.z - cible.position.z <=rayon && r_attaquant.position.z - cible.position.z >= -rayon))
//        //{
//        //    print("ALERTER");
//        //    Deplacer(cible.position.x, cible.position.z);
//        //}
//        //r_attaquant.MovePosition(new Vector3());
//        float _x = r_attaquant.position.x;
//        float _z = r_attaquant.position.z;
//    }

//    public void Deplacer(float x, float z)
//    {
//        if (!Input.anyKey)
//        {
//            if (r_attaquant.position.x > x)
//            {
//                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x - 1, r_attaquant.position.y, r_attaquant.position.z));
//            }
//            else if (r_attaquant.position.x < x)
//            {
//                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x + 1, r_attaquant.position.y, r_attaquant.position.z));
//            }
//            if (r_attaquant.position.z > z)
//            {
//                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x, r_attaquant.position.y, r_attaquant.position.z - 1));
//            }
//            else if (r_attaquant.position.z < z)
//            {
//                r_attaquant.MovePosition(new Vector3(r_attaquant.position.x, r_attaquant.position.y, r_attaquant.position.z + 1));
//            }
//        }
//    }

    
//}

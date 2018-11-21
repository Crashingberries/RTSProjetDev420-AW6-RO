//par Julien Veillette-Bérubé

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovements : MonoBehaviour {
    [SerializeField][Range(1, 200)]
    private float vitesse = 10;
    private Vector3 positionCible;
    private bool enMouvement;
    private Animator animator;

    const int CLIC_DROIT = 1;
    const int CLIC_GAUCHE = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
		positionCible = transform.position;
		enMouvement = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(CLIC_DROIT))
        {
			SetPositionCible();
        }
		if (enMouvement)
        {
			BougerJoueur();
        }
        else
        {
            animator.SetBool("EnMouvement", false);
        }
        /*if (Input.GetMouseButton(0))
        {
            this.AttributionCible();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Terrain")
        {
            if (other.tag != "Friendly") {
                transform.LookAt(other.transform);
                animator.SetBool("Attaque", true);
                enMouvement = false;
                print(other.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Attaque", false);
    }

    void SetPositionCible()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if(plane.Raycast (ray, out point))
        {
			positionCible = ray.GetPoint(point);
        }

		enMouvement = true;
    }

    void BougerJoueur()
    {
        animator.SetBool("EnMouvement", true);
		transform.LookAt(positionCible);
		transform.position = Vector3.MoveTowards(transform.position, positionCible, vitesse * Time.deltaTime);

		if(transform.position == positionCible)
        {
			enMouvement = false;
        }

		Debug.DrawLine(transform.position, positionCible, Color.red);

    }

    /*void AttributionCible()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.transform.gameObject.tag == "Ennemi")
            {
                this.SetCible(hit.transform.GetComponent<Rigidbody>());
            }
        }
    }*/
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour {
    public Rigidbody cible;
    public Rigidbody self;
    private Animator animator;
    public int portee;

    public Rigidbody GetCible()
    {
        return this.cible;
    }

    public void SetCible(Rigidbody cible)
    {
        this.cible = cible;
    }

    // Use this for initialization
    void Start()
    {
        animator = self.GetComponent<Animator>();
        portee = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.AttributionCible();
        }
        if (cible != null)
        {
            if ((self.position.x - cible.position.x <= portee && self.position.x - cible.position.x >= -portee) && (self.position.z - cible.position.z <= portee && self.position.z - cible.position.z >= -portee))
            {
                animator.SetBool("Attaque", true);
                animator.SetBool("EnMouvement", false);
            } 
        }
    }

    void AttributionCible()
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
    }
}

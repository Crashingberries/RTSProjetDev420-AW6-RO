using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovements : MonoBehaviour {
    [SerializeField][Range(1, 20)]
    private float vitesse = 10;

    private Vector3 positionCible;
    private bool enMouvement;

    const int RIGHT_MOUSE_BUTTON = 1;

	// Use this for initialization
	void Start () {
		positionCible = transform.position;
		enMouvement = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(RIGHT_MOUSE_BUTTON))
        {
			SetPositionCible();
        }

		if (enMouvement)
        {
			BougerJoueur();
        }
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
		transform.LookAt(positionCible);
		transform.position = Vector3.MoveTowards(transform.position, positionCible, vitesse * Time.deltaTime);

		if(transform.position == positionCible)
        {
			enMouvement = false;
        }

		Debug.DrawLine(transform.position, positionCible, Color.red);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour {
	
	void Update () {

        //Lo destruyo a los 10 segundos
        Destroy(gameObject, 10);

    }
}
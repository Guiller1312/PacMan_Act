using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    public float velocidad = 0.1f;
	GameObject ColeccionableV;
	public Vector3 movimiento;
	public float movimientoH;
	public float movimientoV;
	public float velocidadV = 0.02f;
	public Text textoContador;
	public int puntuacion = 0;
	
	
	void FixedUpdate () {

        //Capturo el movimiento en los ejes
         movimientoH = Input.GetAxis("Horizontal");
         movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento
         movimiento = new Vector3(movimientoH, 0, movimientoV);

        //Muevo el jugador
        transform.position += -movimiento * velocidad;
	
		
	}
	private void OnTriggerEnter(Collider other)
    {

        //Si se come al Coleccionable que da velocidad
        if (other.gameObject.CompareTag("ColeccionableV")){

		velocidad += velocidadV;
		}
		 //Debug.Log (other.gameObject.tag);
    if (other.gameObject.tag == "Enemigo"){
        puntuacion = puntuacion + 10;
        textoContador.text = puntuacion.ToString();
    }
		
	}
	public void updateScore(int points){
    Debug.Log ("updateScore");
    puntuacion = puntuacion + points;
    textoContador.text = puntuacion.ToString();
		}
	}



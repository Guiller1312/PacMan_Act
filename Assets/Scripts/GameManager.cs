using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject enemigo, coleccionable, coleccionableV;
    public Vector3 posicion;
    public int numeroEnemigos;
    public float esperaInicial;
    public float esperaEntreEnemigos;
    public float esperaEntreOlas, esperaEntreColeccionables, esperaEntreColeccionablesV;
	//array de posiciones donde apareceran los enemigos
	public float [] posEx = {-4.1f, 3.8f, 6.85f, 1.6f, -7.23f, -8.8f, 9.1f};
	public float [] posEz = {-7.3f, -3.9f, -5.9f, 5.4f, 5.4f, -3, 0.86f};
	public static GameManager gm;
	public GameObject mainCanvas;
	public Text textScoreMainCanvas;
	public GameObject gameOverCanvas;
    public Text textScoreGameOver;
	public enum gameStates {Playing, Death, GameOver};
	GameObject jugador;
	public gameStates gameState = gameStates.Playing;
	private IsLive live; 

	void Start() {  

        //LLamo a la rutina de crear enemigos
        StartCoroutine(crearEnemigos());

        //LLamo a la rutina de crear coleccionables
        StartCoroutine(crearColeccionables());

		if (jugador == null) { //Si no se ha informado el Player busca un objeto con el Tag Playe. 
            jugador = GameObject.Find("Jugador");
        }
             
        live = jugador.GetComponent<IsLive>(); //Recuperamos el script isLive del player y lo guardamos en una variable. 
        gameState = gameStates.Playing; //Cambiamos el estado a Playing. 
 
        // Desactivamos el Canvas gameOver, just in case. 
        gameOverCanvas.SetActive (false);

    }
		
    IEnumerator crearEnemigos()
    {
       //Espero un tiempo antes de crear enemigos
       yield return new WaitForSeconds(esperaInicial);

        //Bucle durante toda la vida del juego
        while (true)
        {
            //Bucle de número de enemigos
            for (int i = 0; i < numeroEnemigos; i++)
            {
			
                //Instancio el enemigo en una posición aleatoria del tablero
                //Vector3 posicionEnemigo = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
				int indicePos = Random.Range(0,7);
				Vector3 posicionEnemigo = new Vector3((posEx[indicePos]), posicion.y, (posEz[indicePos]));
                Quaternion rotacionEnemigo = Quaternion.identity;
                Instantiate(enemigo, posicionEnemigo, rotacionEnemigo);

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreEnemigos);
            }

            //Espero un tiempo entre oleadas de enemigos
            yield return new WaitForSeconds(esperaEntreOlas);
        }
    }

    IEnumerator crearColeccionables()
    {
        yield return new WaitForSeconds(esperaInicial);
        while (true)
        {
            //Instancio el coleccionable en una posición aleatoria del tablero
            Vector3 posicionColeccionable = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
            Quaternion rotacionColeccionable = Quaternion.identity;
            Instantiate(coleccionable, posicionColeccionable, rotacionColeccionable);

			Vector3 posicionColeccionableV = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
            Quaternion rotacionColeccionableV = Quaternion.identity;
			Instantiate(coleccionableV, posicionColeccionableV, rotacionColeccionableV);

            //Espero un tiempo entre la creación de cada coleccionable
            yield return new WaitForSeconds(esperaEntreColeccionables);
			yield return new WaitForSeconds(esperaEntreColeccionablesV);
               

        }
		}

		void Update () {
        switch (gameState)
        {
        case gameStates.Playing:
                if (live.live == false)
                    {
                        gameState = gameStates.GameOver;
                        mainCanvas.SetActive (false);
                        gameOverCanvas.SetActive (true);
                         
                        textScoreGameOver.text = textScoreMainCanvas.text;
                         
                    } 
 
                break;
 
 
            case gameStates.GameOver:
                // nothing
                break;
        }
 
    
}
}
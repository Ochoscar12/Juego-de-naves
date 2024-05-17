using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Libreria de UI para poder modificar variables de tipo texto.

public class Jugador : MonoBehaviour
{
    //Velocidad
    public float speed;//Variable para velocidad de movimiento de nuestra nave.
    public Rigidbody2D rb;// Variable para definicion del RigidBody.
    private float directionY;
    private Vector2 direction;
    public GameObject PlayerBullet;//Variables para la posicion del laser
    public GameObject bulletPosition;

    private int puntos; //variable para almacenar puntos
    private int record; //variable para almacenar record
    public Text puntostexto; //para actualizar el el texto osea los puntos
    public Text recordtexto; //para actualizar record



    void Start() //Vuelvo a agregar el void Start porque necesito declarar que al inicio los puntos esten en 0
    {
        puntos = 0;
        if (!PlayerPrefs.HasKey("record")) //recordatorio personal no olvidar quitar el punto y coma en los if :(
        {
            PlayerPrefs.SetInt("record" , 0);
        }
        record = PlayerPrefs.GetInt("record"); //todas estas lineas son para poder mandar a llamar los Player prefs
        // y que el juego recuerde si en una sesion anterior hay records distintos.
        recordtexto.text = record.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))//Definimos que al presionar el boton espacio del teclado se active el disparo.
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);//Funciones para definir donde se encuentra donde saldra el
            bullet.transform.position = bulletPosition.transform.position;//disparo.
        }
        //Funciones para definir direccion.
        directionY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(0f, directionY).normalized;
    }
    private void FixedUpdate()
    {
        //Formula para velocidad y direccion.
        rb.velocity = new Vector2(0f, direction.y * speed);
        //Funcion agregada para limitar el movimiento del jugador.
        rb.position = new Vector2 (rb.position.x,Mathf.Clamp(rb.position.y, -3.41f,3.41f));
    }
    //Funcion para detectar colision.
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Golpe detectado");
        /*
        Time.timeScale = 0f; //Para implementar fin de partida
        */
        puntos++; //Agregamos aqui los puntos para poder que al momento de detectar el golpe sume 1 punto.
        puntostexto.text = puntos.ToString(); //Para que se actualice el texto y que la variable se convierta a string
        if (puntos > record)
        {
            record = puntos;
            recordtexto.text = record.ToString();
            PlayerPrefs.SetInt("record", record); //lo mismo que con los puntos solo que comprobando si los puntos
            // o el record es mayor.
        }
        //Agregar funcion para destruccion de objetos.
        Destroy(collision.gameObject);
    }
}

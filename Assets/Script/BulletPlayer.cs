using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletPlayer : MonoBehaviour
{
    float speed;//Variable para definir velocidad del laser
    public Rigidbody2D rb;//Rigidbody para que detecte un cuerpo
    void Start()
    {
        speed = 8f;//Definimos la velocidad del laser
    }

    void Update()
    {
        Vector2 position =  transform.position;//Lineas para especificar el movimiento y trayectoria del laser.
        position = new Vector2 (position.x  + speed * Time.deltaTime, position.y);
        transform.position = position;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));//En esta linea definimos que si el laser
        if(transform.position.x > max.x)//pasa del limite de la camara en X este se elimine para no cargar memoria extra.
        {
            Destroy(gameObject);
        }
    }
        void OnCollisionEnter2D(Collision2D collision)//Esto es para poder detectar colisiones.
    {
        Debug.Log("Golpe detectado");//Mandamos un mensaje a la consola para confirmar el contacto.
        Destroy(collision.gameObject);//Al momento que el laser toque a un enemigo lo elimina.
    }
}

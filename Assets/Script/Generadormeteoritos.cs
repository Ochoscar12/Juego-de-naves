using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Generadormeteoritos : MonoBehaviour
{
    //Declaracion de variables para posicionamiento random en X y Y de los meteoritos
    public GameObject prefabricadoMeteorito;
    private float randomX;
    private float randomY;
    private int Meteoritosingame;
    void Start()
    {
        //Meteoritosingame es un contador que declaro en 0 para que se entienda que al iniciar esta en 0.
        Meteoritosingame = 0;
        StartCoroutine(olasdeMeteoritos());
    }
    public void CrearMeteorito()
    {

        //Se establece el rango en el que se quiere que aparezcan los meteoritos.
        randomX=Random.Range(12.5f,13.5f);
        randomY=Random.Range(-3.4f,3.4f);
        GameObject a = Instantiate(prefabricadoMeteorito) as GameObject;
        //GetComponent es literalmetne traduciendolo para traer el componente rigidbody y poder darle la fuerza
        //Que se va a utilizar.
        //El AddRelativeForce añade la fuerza y con el Vector 2 lo definimos al eje horizontal, luego defino las fuerzas.
        a.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-200f,0f));
        //Formula para poder declarar la posicion en la que "caeran" los meteoritos.
        a.transform.position = new Vector3(randomX, randomY , 0f);

        //Contador para no crear meteoritos infinitos.
        Meteoritosingame++;
    }
    IEnumerator olasdeMeteoritos()
    {
        while(true)
        {
            //Esta funcion de abajo sirve para poder indicarle a unity que cada 2 segundos se creen
            //los meteoritos y no se creen de un solo.
            yield return new WaitForSeconds(2.5f);
            if (Meteoritosingame < 15)
            {
                CrearMeteorito();
            }
        }
    }
}

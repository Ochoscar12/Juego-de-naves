using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuingame : MonoBehaviour
{

    public void Regresar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

}
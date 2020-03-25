using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionManejadores : MonoBehaviour
{
    public int nvert;
    
    public GameObject nuevoManejador;
    public GameObject malla;
    public GameObject manejador;

    ManejarManejadores manejarManejadores;
    

    void Start()
    {
        manejarManejadores = manejador.GetComponent<ManejarManejadores>();
        
        nvert = CubeMeshData.vertices.Count;

        GenerarBolas();
    }


    void Update()
    {
       
    }

    void GenerarBolas()
    {
        for (int i = 0; i < nvert; i++)
        {
            manejarManejadores.indiceVertice = i;

            nuevoManejador = Instantiate(manejador, CubeMeshData.vertices[i], Quaternion.identity);
        }

    }
}
    

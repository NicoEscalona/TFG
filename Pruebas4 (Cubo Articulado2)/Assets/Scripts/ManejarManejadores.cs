using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarManejadores : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    bool isDragging = false;
    public int indiceVertice;

    public GameObject manejadores;
    public GameObject malla;
    public GameObject generadorManejadores;

    MeshGeneration meshGeneration;
    GeneracionManejadores generacionManejadores;

    void Start()
    {
        generadorManejadores = GameObject.FindGameObjectWithTag("GeneradorManejadores");
        malla = GameObject.FindGameObjectWithTag("Mesh");
        meshGeneration = GameObject.FindGameObjectWithTag("Mesh").GetComponent<MeshGeneration>();
        manejadores = this.gameObject;
        generacionManejadores = generadorManejadores.GetComponent<GeneracionManejadores>();
    }

    void Update()
    {
        /*
        if(Input.GetKey("k"))
        {
            DestruirBolas();
        }
        */
    }
    
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        isDragging = true;

        CubeMeshData.vertices[indiceVertice] = manejadores.gameObject.transform.position;
        meshGeneration.UpdateMesh();
        //Debug.Log(indiceVertice + "," + CubeMeshData.vertices[indiceVertice] + ">" + manejadores.gameObject.transform.position);
        isDragging = false;

        meshGeneration.CrearCubo();
        meshGeneration.UpdateMesh();
    }

    void DestruirBolas()
    {
        //gameObject.Destroy;
    }
}

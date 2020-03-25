
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    Mesh mesh;
    public int totalTris;

    public List<Vector3> vertices;
    public List<int> trianglesd;
    MeshCollider meshCollider;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        
        //Debug.Log(CubeMeshData.triangles.Count);
        //Debug.Log(CubeMeshData.triangles[2]);

        //totalTris = CubeMeshData.triangles[CubeMeshData.triangles.Count-1].triangulo;

        totalTris = (CubeMeshData.triangles.Count / 3) - 1;

        //Debug.Log(CubeMeshData.triangles[CubeMeshData.triangles.Count - 1].triangulo);

        Debug.Log(CubeMeshData.triangles.Count);

        CrearCubo();

        UpdateMesh();
    }

    void Start()
    {
        
       
    }


    void Update()
    {
        vertices.Clear();
        trianglesd.Clear();
        
        if (Input.GetKeyDown("n"))
        {
            Debug.Log("Ray shot");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.Log(hit.triangleIndex);

                int triangulo = (hit.triangleIndex) * 3;

                Debug.Log(triangulo);
                //Debug.Log(CubeMeshData.triangles[triangulo]);
                
                CubeMeshData.triangles.Remove(CubeMeshData.triangles[triangulo]);
                CubeMeshData.triangles.Remove(CubeMeshData.triangles[triangulo]);
                CubeMeshData.triangles.Remove(CubeMeshData.triangles[triangulo]);

                totalTris = (CubeMeshData.triangles.Count / 3) - 1;

                UpdateMesh();
            }
        }
    }

    public void CrearCubo()
    {
        
        
        vertices = new List<Vector3>();
        trianglesd = new List<int>();

        for (int i = 0; i <= totalTris; i++)
        {
            
            CrearTriangulo(i);
        }
    }

    public void CrearTriangulo(int dir)
    {

        for (int i = 0; i < 3; i++)
        {
            int triangulodir = CubeMeshData.triangles[dir*3 + i].vertice;
            //Debug.Log(triangulodir);
            Vector3 vectori = CubeMeshData.vertices[triangulodir];

            vertices.Add(vectori);
        }
        
        //vertices.AddRange(CubeMeshData.faceVertices(dir)); //Añadir vertices de esta cara i a la lista de vertices

        //Triangular los últimos 4 certices de la lista entre sí

        int vCount = vertices.Count;


        trianglesd.Add(vCount - 3);
        trianglesd.Add(vCount - 3 + 1);
        trianglesd.Add(vCount - 3 + 2);
       
    }

    public void UpdateMesh()
    {
        Destroy(meshCollider);
        meshCollider = gameObject.AddComponent<MeshCollider>();
        mesh.Clear();

        CrearCubo();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = trianglesd.ToArray();
        mesh.RecalculateNormals();

        meshCollider.sharedMesh = mesh;
    }
}

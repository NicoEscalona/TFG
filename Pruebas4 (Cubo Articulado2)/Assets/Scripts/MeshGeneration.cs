
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
    public List<Vector3> caraSubdiv;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        
        //Debug.Log(CubeMeshData.triangles.Count);
        //Debug.Log(CubeMeshData.triangles[2]);

        //totalTris = CubeMeshData.triangles[CubeMeshData.triangles.Count-1].triangulo;

        totalTris = (CubeMeshData.triangles.Count / 3) - 1;

        //Debug.Log(CubeMeshData.triangles[CubeMeshData.triangles.Count - 1].triangulo);

        Debug.Log(CubeMeshData.triangles.Count);

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

                /*
                Debug.Log(triangulo);
                //Debug.Log(CubeMeshData.triangles[triangulo]);

                //Almacenar vertices originales de la cara
                int indiceVert1 = CubeMeshData.triangles[triangulo];
                int indiceVert2 = CubeMeshData.triangles[triangulo+1];
                int indiceVert3 = CubeMeshData.triangles[triangulo+2];

                
                Debug.Log(indiceVert1);
                Debug.Log(indiceVert2);
                Debug.Log(indiceVert3);

                
                caraSubdiv.Add(CubeMeshData.vertices[CubeMeshData.triangles[triangulo]]);
                caraSubdiv.Add(CubeMeshData.vertices[CubeMeshData.triangles[triangulo+1]]);
                caraSubdiv.Add(CubeMeshData.vertices[CubeMeshData.triangles[triangulo+2]]);

                //subdividir aritsas de la cara original
                Vector3 nuevoVertice1 = (caraSubdiv[0] - caraSubdiv[1]) * 0.5f;
                Vector3 nuevoVertice2 = (caraSubdiv[1] - caraSubdiv[2]) * 0.5f;
                Vector3 nuevoVertice3 = (caraSubdiv[2] - caraSubdiv[0]) * 0.5f;
                

                

                //Eliminar cara original
                CubeMeshData.triangles.Remove(CubeMeshData.triangles[triangulo]);
                CubeMeshData.triangles.Remove(CubeMeshData.triangles[triangulo]);
                CubeMeshData.triangles.Remove(CubeMeshData.triangles[triangulo]);
                */

                CubeMeshData.triangles.RemoveAt(triangulo);
                CubeMeshData.triangles.RemoveAt(triangulo);
                CubeMeshData.triangles.RemoveAt(triangulo);



                /*
                //triangular la cara subdividida
                CubeMeshData.vertices.Add(nuevoVertice1);
                CubeMeshData.vertices.Add(nuevoVertice2);
                CubeMeshData.vertices.Add(nuevoVertice3);

                //triangular la cara subdividida
                int totalVert = CubeMeshData.vertices.Count;

                
                CubeMeshData.triangles.Add(new nodo(totalTris + 1, indiceVert1));
                CubeMeshData.triangles.Add(new nodo(totalTris + 1, totalVert - 2));
                CubeMeshData.triangles.Add(new nodo(totalTris + 1, totalVert - 1));

                CubeMeshData.triangles.Add(new nodo(totalTris + 2, totalVert - 2));
                CubeMeshData.triangles.Add(new nodo(totalTris + 2, indiceVert2));
                CubeMeshData.triangles.Add(new nodo(totalTris + 2, totalVert));

                CubeMeshData.triangles.Add(new nodo(totalTris + 2, totalVert - 1));
                CubeMeshData.triangles.Add(new nodo(totalTris + 2, totalVert));
                CubeMeshData.triangles.Add(new nodo(totalTris + 2, totalVert - 2));
                

                CubeMeshData.triangles.Add(indiceVert1);
                CubeMeshData.triangles.Add(totalVert - 2);
                CubeMeshData.triangles.Add(totalVert - 1);

                CubeMeshData.triangles.Add(totalVert - 2);
                CubeMeshData.triangles.Add(indiceVert2);
                CubeMeshData.triangles.Add(totalVert);

                CubeMeshData.triangles.Add(totalVert - 1);
                CubeMeshData.triangles.Add(totalVert);
                CubeMeshData.triangles.Add(totalVert - 2);
                */

                totalTris = ((CubeMeshData.triangles.Count ) / 3) - 1;

                UpdateMesh();
                
            }
        }
    }

    public void CrearCubo()
    {
        //totalTris = (CubeMeshData.triangles.Count / 3) - 1;

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
            //int triangulodir = CubeMeshData.triangles[dir*3 + i].vertice;
            int triangulodir = CubeMeshData.triangles[dir * 3 + i];
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

        Debug.Log("triangles:");

        for (int i = 0; i < CubeMeshData.triangles.Count; i++)
        {
            Debug.Log(i + ", " + CubeMeshData.triangles[i]);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = trianglesd.ToArray();
        mesh.RecalculateNormals();

        meshCollider.sharedMesh = mesh;
    }
}

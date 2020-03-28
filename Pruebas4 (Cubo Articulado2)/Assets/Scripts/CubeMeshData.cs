using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubeMeshData
{
    public static List<Vector3> vertices = new List<Vector3>
    {
        new Vector3(  1,  1,  1),
        new Vector3( -1,  1,  1),
        new Vector3( -1, -1,  1),
        new Vector3(  1, -1,  1),
        new Vector3( -1,  1, -1),
        new Vector3(  1,  1, -1),
        new Vector3(  1, -1, -1),
        new Vector3( -1, -1, -1)
    };

    public class nodo
    {
        //Creador de triangulos con dos atributos: triangulo al que pertenece y número de vértice.
        
        public int triangulo;
        public int vertice;

        public nodo(int nuevoTriangulo, int nuevoVertice)
        {
            triangulo = nuevoTriangulo;
            vertice = nuevoVertice;
        }
    }

    
    public static List<int> triangles = new List<int>
    {
        //Creador de triángulos simple.
        
        0, 1, 2,
        0, 2, 3,
        1, 4, 7,
        1, 7, 2,
        4, 5, 6,
        4, 6, 7,
        5, 0, 3,
        5, 3, 6,
        1, 0, 5,
        1, 5, 4,
        6, 2, 7,
        6, 3, 2
    };
    

    /*
    public static List<nodo> triangles = new List<nodo>
    {
        new nodo (  0, 0), new nodo (  0, 1), new nodo (  0, 2),
        new nodo (  1, 0), new nodo (  1, 2), new nodo (  1, 3),
        new nodo (  2, 1), new nodo (  2, 4), new nodo (  2, 7),
        new nodo (  3, 1), new nodo (  3, 7), new nodo (  3, 2),
        new nodo (  4, 4), new nodo (  4, 5), new nodo (  4, 6),
        new nodo (  5, 4), new nodo (  5, 6), new nodo (  5, 7),
        new nodo (  6, 5), new nodo (  6, 0), new nodo (  6, 3),
        new nodo (  7, 5), new nodo (  7, 3), new nodo (  7, 6),
        new nodo (  8, 1), new nodo (  8, 0), new nodo (  8, 5),
        new nodo (  9, 1), new nodo (  9, 5), new nodo (  9, 4),
        new nodo ( 10, 6), new nodo ( 10, 2), new nodo ( 10, 7),
        new nodo ( 11, 6), new nodo ( 11, 3), new nodo ( 11, 2),

    };
    */

}

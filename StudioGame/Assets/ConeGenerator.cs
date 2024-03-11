using UnityEngine;
using System;

public class ConeGenerator : MonoBehaviour
{
    public int segments = 20;
    public float radius = 1f;
    public float height = 2f;

    void Start()
    {
        GenerateCone();
    }

    void GenerateCone()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[segments + 1 + 1];
        int[] triangles = new int[segments * 3];

        vertices[0] = Vector3.zero;

        float angleIncrement = (2f * Mathf.PI) / segments;
        for (int i = 1; i <= segments; i++)
        {
            float angle = angleIncrement * i;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices[i] = new Vector3(x, 0f, z);
        }

        vertices[segments + 1] = new Vector3(0f, height, 0f);

        // Generate triangles for the cone sides
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 1) % segments + 1;
        }

        // Generate triangles for the cone bottom
        for (int i = 0; i < segments; i++)
        {
            triangles[(segments * 3) + i * 3] = i + 1;
            triangles[(segments * 3) + i * 3 + 1] = segments + 1;
            triangles[(segments * 3) + i * 3 + 2] = (i + 1) % segments + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}

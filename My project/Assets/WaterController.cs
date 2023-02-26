using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float waveSpeed = 1f;
    public float waveHeight = 0.1f;
    public float damping = 0.1f;

    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] normals;
    private Vector4[] tangents;
    private Vector2[] uv;
    private Color[] colors;
    private float[] waveTimers;
    private float[] targetHeights;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        vertices = mesh.vertices;
        normals = mesh.normals;
        tangents = mesh.tangents;
        uv = mesh.uv;
        colors = mesh.colors;

        waveTimers = new float[vertices.Length];
        targetHeights = new float[vertices.Length];
    }

    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            waveTimers[i] += Time.deltaTime * waveSpeed;
            targetHeights[i] = Mathf.Sin(waveTimers[i]) * waveHeight;
            vertices[i] += normals[i] * (targetHeights[i] - vertices[i].y) * damping;
            tangents[i] = new Vector4(1f, 0f, 0f, -1f);
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.tangents = tangents;
    }

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] == hit.point)
                {
                    waveTimers[i] = 0f;
                    targetHeights[i] = waveHeight;
                    break;
                }
            }
        }
    }
}

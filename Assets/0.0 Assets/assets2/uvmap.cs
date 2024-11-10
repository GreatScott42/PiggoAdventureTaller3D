using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uvmap : MonoBehaviour
{
    MeshFilter meshfilter;
    Mesh mesh;
    public Vector2 textureScale = Vector2.one;
    // Start is called before the first frame update
    void Start()
    {
        meshfilter = GetComponent<MeshFilter>();
        mesh = meshfilter.mesh;
        Vector2[] uvmap = mesh.uv;
        UpdateUVs();
        /*//front
        uvmap[0] = new Vector2(0,0);
        uvmap[1] = new Vector2(0.333f, 0);
        uvmap[2] = new Vector2(0, 0.333f);
        uvmap[3] = new Vector2(0.333f, 0.333f);
        //top
        uvmap[4] = new Vector2(0.334f, 0.333f);
        uvmap[5] = new Vector2(0.666f, 0.333f);
        uvmap[8] = new Vector2(0.334f, 0);
        uvmap[9] = new Vector2(0.666f, 0);
        //back
        uvmap[6] = new Vector2(1, 0);
        uvmap[7] = new Vector2(0.667f, 0);
        uvmap[10] = new Vector2(1, 0.333f);
        uvmap[11] = new Vector2(0.667f, 0.333f);
        //bottom
        uvmap[12] = new Vector2(0, 0.334f);
        uvmap[13] = new Vector2(0, 0.666f);
        uvmap[14] = new Vector2(0.333f, 0.666f);
        uvmap[15] = new Vector2(0.333f, 0.334f);
        //left
        uvmap[16] = new Vector2(0.334f, 0.334f);
        uvmap[17] = new Vector2(0.334f, 0.666f);
        uvmap[18] = new Vector2(0.666f, 0.666f);
        uvmap[19] = new Vector2(0.666f, 0.334f);
        //right
        uvmap[20] = new Vector2(0.667f, 0.334f);
        uvmap[21] = new Vector2(0.667f, 0.666f);
        uvmap[22] = new Vector2(1, 0.666f);
        uvmap[23] = new Vector2(1, 0.334f);

        mesh.uv = uvmap;*/

    }
    /*
    void UpdateUVs()
    {
        Vector2[] uvMap = new Vector2[mesh.vertices.Length];

        Vector3 size = transform.localScale;

        // Front
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(size.x * textureScale.x, 0);
        uvMap[2] = new Vector2(0, size.y * textureScale.y);
        uvMap[3] = new Vector2(size.x * textureScale.x, size.y * textureScale.y);

        // Top
        uvMap[4] = new Vector2(0, 0);
        uvMap[5] = new Vector2(size.x * textureScale.x, 0);
        uvMap[8] = new Vector2(0, size.z * textureScale.y);
        uvMap[9] = new Vector2(size.x * textureScale.x, size.z * textureScale.y);

        // Back
        uvMap[6] = new Vector2(0, 0);
        uvMap[7] = new Vector2(size.x * textureScale.x, 0);
        uvMap[10] = new Vector2(0, size.y * textureScale.y);
        uvMap[11] = new Vector2(size.x * textureScale.x, size.y * textureScale.y);

        // Bottom
        uvMap[12] = new Vector2(0, 0);
        uvMap[13] = new Vector2(0, size.z * textureScale.y);
        uvMap[14] = new Vector2(size.x * textureScale.x, size.z * textureScale.y);
        uvMap[15] = new Vector2(size.x * textureScale.x, 0);

        // Left
        uvMap[16] = new Vector2(0, 0);
        uvMap[17] = new Vector2(0, size.y * textureScale.y);
        uvMap[18] = new Vector2(size.z * textureScale.x, size.y * textureScale.y);
        uvMap[19] = new Vector2(size.z * textureScale.x, 0);

        // Right
        uvMap[20] = new Vector2(0, 0);
        uvMap[21] = new Vector2(0, size.y * textureScale.y);
        uvMap[22] = new Vector2(size.z * textureScale.x, size.y * textureScale.y);
        uvMap[23] = new Vector2(size.z * textureScale.x, 0);

        mesh.uv = uvMap;
    }
    */
    /*
    void UpdateUVs()
    {
        Vector2[] uvMap = new Vector2[mesh.vertices.Length];

        Vector3 size = transform.localScale;

        // Front
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(size.x, 0);
        uvMap[2] = new Vector2(0, size.y);
        uvMap[3] = new Vector2(size.x, size.y);

        // Top
        uvMap[4] = new Vector2(0, 0);
        uvMap[5] = new Vector2(size.x, 0);
        uvMap[8] = new Vector2(0, size.z);
        uvMap[9] = new Vector2(size.x, size.z);

        // Back
        uvMap[6] = new Vector2(0, 0);
        uvMap[7] = new Vector2(size.x, 0);
        uvMap[10] = new Vector2(0, size.y);
        uvMap[11] = new Vector2(size.x, size.y);

        // Bottom
        uvMap[12] = new Vector2(0, 0);
        uvMap[13] = new Vector2(0, size.z);
        uvMap[14] = new Vector2(size.x, size.z);
        uvMap[15] = new Vector2(size.x, 0);

        // Left
        uvMap[16] = new Vector2(0, 0);
        uvMap[17] = new Vector2(0, size.y);
        uvMap[18] = new Vector2(size.z, size.y);
        uvMap[19] = new Vector2(size.z, 0);

        // Right
        uvMap[20] = new Vector2(0, 0);
        uvMap[21] = new Vector2(0, size.y);
        uvMap[22] = new Vector2(size.z, size.y);
        uvMap[23] = new Vector2(size.z, 0);

        mesh.uv = uvMap;
    }
    */
    /*
    void UpdateUVs()
    {
        Vector2[] uvMap = new Vector2[mesh.vertices.Length];

        Vector3 size = transform.localScale;

        // Front
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(0.333f * size.x, 0);
        uvMap[2] = new Vector2(0, 0.333f * size.y);
        uvMap[3] = new Vector2(0.333f * size.x, 0.333f * size.y);

        // Top
        uvMap[4] = new Vector2(0.334f, 0.333f * size.y);
        uvMap[5] = new Vector2(0.666f * size.x, 0.333f * size.y);
        uvMap[8] = new Vector2(0.334f, 0);
        uvMap[9] = new Vector2(0.666f * size.x, 0);

        // Back
        uvMap[6] = new Vector2(1 * size.x, 0);
        uvMap[7] = new Vector2(0.667f, 0);
        uvMap[10] = new Vector2(1 * size.x, 0.333f * size.y);
        uvMap[11] = new Vector2(0.667f, 0.333f * size.y);

        // Bottom
        uvMap[12] = new Vector2(0, 0.334f);
        uvMap[13] = new Vector2(0, 0.666f * size.y);
        uvMap[14] = new Vector2(0.333f * size.x, 0.666f * size.y);
        uvMap[15] = new Vector2(0.333f * size.x, 0.334f);

        // Left
        uvMap[16] = new Vector2(0.334f, 0.334f);
        uvMap[17] = new Vector2(0.334f, 0.666f * size.y);
        uvMap[18] = new Vector2(0.666f * size.x, 0.666f * size.y);
        uvMap[19] = new Vector2(0.666f * size.x, 0.334f);

        // Right
        uvMap[20] = new Vector2(0.667f, 0.334f);
        uvMap[21] = new Vector2(0.667f, 0.666f * size.y);
        uvMap[22] = new Vector2(1 * size.x, 0.666f * size.y);
        uvMap[23] = new Vector2(1 * size.x, 0.334f);

        mesh.uv = uvMap;
    }
    */
    void UpdateUVs()
    {
        Vector2[] uvMap = new Vector2[mesh.vertices.Length];

        Vector3 size = transform.localScale;

        // Front
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(0.333f * size.x * textureScale.x, 0);
        uvMap[2] = new Vector2(0, 0.333f * size.y * textureScale.y);
        uvMap[3] = new Vector2(0.333f * size.x * textureScale.x, 0.333f * size.y * textureScale.y);

        // Top
        uvMap[4] = new Vector2(0.334f * textureScale.x, 0.333f * size.y * textureScale.y);
        uvMap[5] = new Vector2(0.666f * size.x * textureScale.x, 0.333f * size.y * textureScale.y);
        uvMap[8] = new Vector2(0.334f * textureScale.x, 0);
        uvMap[9] = new Vector2(0.666f * size.x * textureScale.x, 0);

        // Back
        uvMap[6] = new Vector2(1 * size.x * textureScale.x, 0);
        uvMap[7] = new Vector2(0.667f * size.x * textureScale.x, 0);
        uvMap[10] = new Vector2(1 * size.x * textureScale.x, 0.333f * size.y * textureScale.y);
        uvMap[11] = new Vector2(0.667f * size.x * textureScale.x, 0.333f * size.y * textureScale.y);

        // Bottom
        uvMap[12] = new Vector2(0, 0.334f * textureScale.y);
        uvMap[13] = new Vector2(0, 0.666f * size.y * textureScale.y);
        uvMap[14] = new Vector2(0.333f * size.x * textureScale.x, 0.666f * size.y * textureScale.y);
        uvMap[15] = new Vector2(0.333f * size.x * textureScale.x, 0.334f * textureScale.y);

        // Left
        uvMap[16] = new Vector2(0.334f * size.x * textureScale.x, 0.334f * size.y * textureScale.y);
        uvMap[17] = new Vector2(0.334f * size.x * textureScale.x, 0.666f * size.y * textureScale.y);
        uvMap[18] = new Vector2(0.666f * size.x * textureScale.x, 0.666f * size.y * textureScale.y);
        uvMap[19] = new Vector2(0.666f * size.x * textureScale.x, 0.334f * size.y * textureScale.y);

        // Right
        uvMap[20] = new Vector2(0.667f * size.x * textureScale.x, 0.334f * size.y * textureScale.y);
        uvMap[21] = new Vector2(0.667f * size.x * textureScale.x, 0.666f * size.y * textureScale.y);
        uvMap[22] = new Vector2(1 * size.x * textureScale.x, 0.666f * size.y * textureScale.y);
        uvMap[23] = new Vector2(1 * size.x * textureScale.x, 0.334f * size.y * textureScale.y);

        mesh.uv = uvMap;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            UpdateUVs();
            transform.hasChanged = false;
        }
    }
}

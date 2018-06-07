using System.Collections.Generic;
using UnityEngine;

namespace Anueves1.UnityMeshCreation
{
    public static class MeshCreator
    {
        public static void GenerateGrid(this MeshFilter filter, float detailLevel = 10, bool recalculateNormals = false)
        {
            //If it has a mesh.
            if(filter.mesh != null)
            {
                //Clear it.
                filter.mesh.Clear();
            }

            //Create a new mesh and name it.
            var gridMesh = new Mesh {name = "Grid"};

            var vertices = new List<Vector3>();
            var triangles = new List<int>();
            
            for (var x = 0; x < detailLevel; x++)
            {
                //Generate one quad for each place we want it to be at.
                for (var y = 0; y < detailLevel; y++)
                    GetQuadValues(new Vector3(x, 0, y), ref vertices, ref triangles);
            }

            gridMesh.vertices = vertices.ToArray();
            gridMesh.triangles = triangles.ToArray();

            //If needed, calculate normals.
            if (recalculateNormals)
                gridMesh.RecalculateNormals();

            //Assign the mesh.
            filter.mesh = gridMesh;
        }

        private static void GetQuadValues(Vector3 position, ref List<Vector3> vertices, ref List<int> triangles, bool clockwise = true)
        {
            var verts = new Vector3[6];

            verts[0] = Vector3.zero + position;
            verts[1] = Vector3.right + position;
            verts[2] = Vector3.right + Vector3.forward + position;

            verts[3] = Vector3.forward + position;
            verts[4] = Vector3.zero + position;
            verts[5] = Vector3.right + Vector3.forward + position;

            var tris = new int[6];

            if(clockwise)
            {
                tris[0] = 2 + triangles.Count;
                tris[1] = 1 + triangles.Count;
                tris[2] = 0 + triangles.Count;

                tris[3] = 5 + triangles.Count;
                tris[4] = 4 + triangles.Count;
                tris[5] = 3 + triangles.Count;
            }
            else
            {
                tris[0] = 0 + triangles.Count;
                tris[1] = 1 + triangles.Count;
                tris[2] = 2 + triangles.Count;

                tris[3] = 3 + triangles.Count;
                tris[4] = 4 + triangles.Count;
                tris[5] = 5 + triangles.Count;
            }

            vertices.AddRange(verts);

            triangles.AddRange(tris);
        }
    }
}
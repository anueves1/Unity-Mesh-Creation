using Unity.Entities;
using UnityEngine;

namespace Anueves1.UnityMeshCreation
{
    public class ProceduralMeshSystem : ComponentSystem 
    {
        private struct Components
        {
            public ProceduralMeshComponent PMesh;

            public MeshRenderer Renderer;

            public MeshFilter Filter;

            public MeshCollider Collider;
        }

        protected override void OnStartRunning()
        {
            //Go trough all the entities.
            foreach (var entity in GetEntities<Components>())
            {
                //Create a grid.
                entity.Filter.GenerateGrid(entity.PMesh.DetailLevel, true);

                //Make sure the collisions work.
                entity.Collider.sharedMesh = entity.Filter.mesh;
                
                //Apply the material.
                entity.Renderer.material = entity.PMesh.Material;
            }
        }

        protected override void OnUpdate()
        {
            
        }
    }
}
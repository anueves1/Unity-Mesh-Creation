using UnityEngine;

namespace Anueves1.UnityMeshCreation
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
    public class ProceduralMeshComponent : MonoBehaviour
    {
        public int DetailLevel;
        
        [Header("Settings")]
        [Space(5f)]
        
        public Material Material;
    }
}
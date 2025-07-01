using UnityEngine;

[ExecuteAlways] // So it works in the editor without running the scene
public class ColliderGizmos : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        if (box == null) return;

        Gizmos.color = Color.red;

        // Position and size considering the object's transformations
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.matrix = rotationMatrix;

        Gizmos.DrawWireCube(box.center, box.size);
    }
}
using UnityEngine;


public class ExplosiveBarrelTrigger : MonoBehaviour
{
    public float radius = 0.0f;
    public Transform player;

    void OnDrawGizmos()
    {
        Vector2 player_pos = player.position;
        Vector2 barrel_pos = gameObject.transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(barrel_pos, player_pos);
        
        float distance = MathLibrary.SqrMagnitudeBetweenVectors(player_pos, barrel_pos);
        bool inside = distance <= radius * radius;
        UnityEditor.Handles.color = inside ? Color.red : Color.green;
        UnityEditor.Handles.DrawWireDisc(barrel_pos, Vector3.back, radius);
    }
}

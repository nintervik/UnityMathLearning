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
        
        float distance = MathLibrary.MagnitudeBetweenVectors(player_pos, barrel_pos);

        if (distance <= radius)
            UnityEditor.Handles.color = Color.red;
        else
            UnityEditor.Handles.color = Color.green;

        UnityEditor.Handles.DrawWireDisc(barrel_pos, Vector3.back, radius);
    }
}

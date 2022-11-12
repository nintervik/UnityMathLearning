using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizSpaces : MonoBehaviour
{
    public Transform world_space;
    public Transform local_space;
    public Transform item;
    public TextMesh pos_label;

    void OnDrawGizmos()
    {
        Vector3 local_space_pos = local_space.position;
        Vector3 item_local_pos = item.localPosition;

        // WORLD X AXIS
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3.right);

        // WORLD Y AXIS
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, Vector3.up);

        // LOCAL X AXIS
        Gizmos.color = Color.magenta;
        Vector3 right_local_space =  local_space.position + local_space.right;
        Gizmos.DrawLine(local_space.position, local_space.position + local_space.right);

        // LOCAL Y AXIS
        Gizmos.color = Color.blue;
        Vector3 up_local_space =  local_space.position + local_space.up;
        Gizmos.DrawLine(local_space.position, local_space.position + local_space.up);

        // LOCAL POINT
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(item.position, 0.05f);

        // LOCAL TO SPACE CALCULATION
        Vector3 world_pos_guess = MathLibrary.LocalToWorld(local_space, item.localPosition);
        
        pos_label.text = ("GUESS WORLD POS: " + world_pos_guess + "\nREAL WORLD POS: " + item.position);
    }
}

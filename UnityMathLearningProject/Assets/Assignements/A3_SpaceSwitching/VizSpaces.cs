using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizSpaces : MonoBehaviour
{
    public Transform world_space;
    public Transform local_space;
    public Transform local_item;
    public Transform world_item;
    public TextMesh pos_label;

    void OnDrawGizmos()
    {
        Vector3 local_space_pos = local_space.position;
        Vector3 item_local_pos = local_item.localPosition;

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
        Gizmos.DrawSphere(local_item.position, 0.05f);

        // LOCAL TO SPACE CALCULATION
        Vector3 world_pos_guess = MathLibrary.LocalToWorld(local_space, local_item.localPosition);
        
        pos_label.text = ("GUESS WORLD POS: " + world_pos_guess + "\nREAL WORLD POS: " + local_item.position);

        float local_x = MathLibrary.GetScalarProjection(world_item.position, local_space.right);
        float local_y = MathLibrary.GetScalarProjection(world_item.position, local_space.up);

        Vector3 local_pos_guess = new Vector3(local_x, local_y);

        //print("REAL LOCAL POS: " + world_item.localPosition);
        print("GUESS LOCAL POS: " + local_pos_guess);
    }
}

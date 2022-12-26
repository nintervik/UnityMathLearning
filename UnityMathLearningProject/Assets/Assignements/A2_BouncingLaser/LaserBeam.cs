using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float max_distance = 0.0f;
    public uint max_bounces = 0;

    void OnDrawGizmos()
    {
        Vector3 dir = gameObject.transform.up;
        Vector3 origin_pos = gameObject.transform.position;
        Vector3 end_pos = Vector3.zero;

        RaycastHit hit;

        Gizmos.color = Color.red;

        for (int i = 0; i < max_bounces; i++)
        {
            Physics.Raycast(origin: origin_pos, direction: dir,
            maxDistance: max_distance, hitInfo: out hit);

            end_pos = hit.point;

            if (end_pos == Vector3.zero)
            {
                end_pos = origin_pos + dir * max_distance;
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(end_pos, new Vector3(4.0f, 4.0f, 4.0f));
                Gizmos.color = Color.red;
            }
            else
                Gizmos.DrawSphere(hit.point, 2.25f);

            Gizmos.DrawLine(origin_pos, end_pos);
                
            origin_pos = end_pos;

            dir = MathLibrary.ReflectVector(dir, hit.normal);
        }
    }
}

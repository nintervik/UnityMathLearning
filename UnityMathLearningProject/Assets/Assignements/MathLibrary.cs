using UnityEngine;


public class MathLibrary
{
    public static float VectorMagnitude(Vector2 a)
    {
        // This is the same as doing Mathf.Sqrt(Dot(a, a))
        return Mathf.Sqrt(a.x * a.x + a.y * a.y);
    }

    public static float VectorSqrMagnitude(Vector2 a)
    {
        // This is the same as doing Mathf.Dot(a, a)
        return a.x * a.x + a.y * a.y;
    }

    public static float MagnitudeBetweenVectors(Vector2 a, Vector2 b)
    {
        Vector2 distance_vec = new Vector2(b.x - a.x, b.y - a.y);
        return VectorMagnitude(distance_vec);
    }

    public static float SqrMagnitudeBetweenVectors(Vector2 a, Vector2 b)
    {
        Vector2 distance_vec = new Vector2(b.x - a.x, b.y - a.y);
        return VectorSqrMagnitude(distance_vec);
    }

    public static Vector3 Normalize(Vector3 a)
    {
        return (a / VectorMagnitude(a));
    }

    public static float Dot(Vector3 a, Vector3 b)
    {
        return (a.x * b.x + a.y * b.y);
    }

    public static float GetScalarProjection(Vector3 from, Vector3 to)
    {
        to = Normalize(to);
        return Dot(to, from);
    }

    public static Vector3 GetVectorProjection(Vector3 from, Vector3 to)
    {
        float scalar_proj = GetScalarProjection(from, to);
        return (to * scalar_proj);
    }

    public static Vector3 ReflectVector(Vector3 dir, Vector3 normal)
    {
        return dir - 2 * GetScalarProjection(dir, normal) * normal;
    }

    public static Vector3 LocalToWorld(Transform local_space_transform_in_world, Vector3 local_point_pos)
    {
        Vector3 local_space_offset_from_world = local_space_transform_in_world.position;
        Vector3 world_pos_at_origin = (local_point_pos.x * local_space_transform_in_world.right + 
                                       local_point_pos.y * local_space_transform_in_world.up);

        
        return local_space_offset_from_world + world_pos_at_origin;
    }

    public static Vector3 WorldToLocal(Transform local_space_transform, Vector3 world_point_pos)
    {
        Vector3 world_pos_at_origin = world_point_pos - local_space_transform.position;
        float mag_x = MathLibrary.GetScalarProjection(world_pos_at_origin, local_space_transform.right);
        float mag_y = MathLibrary.GetScalarProjection(world_pos_at_origin, local_space_transform.up);

        return new Vector3(mag_x, mag_y, 0.0f);
    }
}

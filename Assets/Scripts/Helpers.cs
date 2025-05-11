using UnityEngine;

public static class Helpers 
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool RayCast(this Rigidbody2D rigidbody,Vector2 direction)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float radius = 0.5f;
        float distance = 2f;

        RaycastHit2D hit =  Physics2D.CircleCast(rigidbody.position,radius,direction.normalized,distance,layerMask);

        return hit.collider != null && hit.rigidbody  != rigidbody;

    }

    public static bool Dot(this Transform transform, Transform other,Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;

        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }
}

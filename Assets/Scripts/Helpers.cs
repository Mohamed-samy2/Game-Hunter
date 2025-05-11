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

        RaycastHit2D hit =  Physics2D.CircleCast(rigidbody.position,radius,direction,distance,layerMask);

        return hit.collider != null && hit.rigidbody  != rigidbody;

    }
}

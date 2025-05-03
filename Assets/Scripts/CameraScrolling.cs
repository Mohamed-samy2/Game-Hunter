using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Transform player;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        //cameraPosition.x = player.position.x;
        cameraPosition.x = Mathf.Max(cameraPosition.x,player.position.x); // to not move to left 
        transform.position = cameraPosition;
    }

}

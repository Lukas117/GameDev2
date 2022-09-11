using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public GameObject player;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    
    //look ahead
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x , player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX + lookAhead, posY, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.transform.localScale.x), Time.deltaTime * cameraSpeed);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + lookAhead, minCameraPos.x,
                maxCameraPos.x), Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.transform.localScale.x), Time.deltaTime * cameraSpeed);
        }
    }
}

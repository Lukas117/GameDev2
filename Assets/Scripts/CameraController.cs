using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Follow player
    [SerializeField] private Transform player;

    //Look ahead
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


    private void Update()
    {
        //Follow player
        transform.position = new Vector3(player.position.x, player.position.y+3, transform.position.z);

        //Look ahead
        //transform.position = new Vector3(player.position.x + lookAhead, player.position.y+3, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}

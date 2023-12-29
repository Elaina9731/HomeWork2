using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 targetPosition;

    [SerializeField] private float cameraSpeed = 5f;

    private void Update()
    {
        if (player.gameObject != null)
        {
            targetPosition.Set(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
    }
}

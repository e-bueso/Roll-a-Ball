using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // La distancia de separación entre player y cámara la guardamos en offset
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // La cámara se sitúa donde esté el player pero a la distancia establecida
        transform.position = player.transform.position + offset;
    }
}

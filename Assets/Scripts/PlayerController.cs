using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // La variable speed es pública para que la fijemos desde el editor a 10
    public float speed = 0;

    public TextMeshProUGUI countText; 

    // Y estas dos serán de ambiente porque vamos a implementar una sync propia cámara-player
    private Rigidbody rb;
    private float movementX, movementY;

    private int count; 

    // Start is called before the first frame update
    void Start()
    {
        // Guardamos el Rigidbody
        rb = GetComponent<Rigidbody>();
        count=0;

        SetCountText();
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Guardamos el movimiento 2D en sus variables de ambiente
        movementX=movementVector.x;
        movementY=movementVector.y;
    }

    void SetCountText() {
        countText.text="Count: " + count.ToString();
    }

    void FixedUpdate() {
        // Mueve sólo X e Y, no Z
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // Aplicamos la física a la velocidad oportuna
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        // Si te toco te vas a pastar
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
            Debug.Log("Collide: " + count);

            SetCountText();
        }
    } 

}

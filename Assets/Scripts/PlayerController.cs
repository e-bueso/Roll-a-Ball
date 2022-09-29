using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private int count;
    public TextMeshProUGUI countText; 

    // Y estas dos serán de ambiente porque vamos a implementar una sync propia cámara-player
    private Rigidbody rb;
    private float movementX, movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count=0;

        SetCountText();
    }

    void OnMove(InputValue movementValue) {
        // 
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX=movementVector.x;
        movementY=movementVector.y;
    }

    void SetCountText() {
        countText.text="Count: " + count.ToString();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
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

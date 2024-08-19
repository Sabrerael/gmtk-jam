using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float movementSpeed = 6;
    [SerializeField] float fasterMovementSpeed = 8;

    private Vector2 movementValues = new Vector2();
    private Rigidbody2D playerRigidbody;
    
    private bool isMoving = false;
    private bool useFasterMovement = false;

    private void Start() {
        playerRigidbody = GetComponent<Rigidbody2D>();
        useFasterMovement = GameManager.instance.GetFasterWalkUnlock();
    }

    private void Update() {
        if (movementValues.magnitude > Mathf.Epsilon) {
            NormalMovement();
            isMoving = true;
        } else {
            isMoving = false;
        }
    }

    public bool GetIsMoving() {
        return isMoving;
    }

    public void NormalMovement() {
        if (useFasterMovement) {
            playerRigidbody.MovePosition(playerRigidbody.position + (movementValues * (fasterMovementSpeed * Time.fixedDeltaTime)));
        } else {
            playerRigidbody.MovePosition(playerRigidbody.position + (movementValues * (movementSpeed * Time.fixedDeltaTime)));
        }
    }

    public void SetMovementValues(Vector2 values) {
        movementValues = values;
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    private Movement movement;

    private void Start() {
        movement = GetComponent<Movement>();
    }

    private void OnMove(InputValue value) {      
        movement.SetMovementValues(value.Get<Vector2>());
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceDropper : MonoBehaviour {
    [SerializeField] GameObject saucePrefab;

    private Movement movement;

    private void Start() {
        movement = GetComponent<Movement>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Pizza") && movement.GetIsMoving()) {
            Instantiate(saucePrefab, transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceDropper : MonoBehaviour {
    [SerializeField] GameObject saucePrefab;

    private Movement movement;
    private Pizza currentPizza;

    private bool isDroppingSauce = true;

    private void Start() {
        movement = GetComponent<Movement>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingSauce && other.CompareTag("Pizza") && movement.GetIsMoving()) {
            Instantiate(saucePrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingSauce() {
        isDroppingSauce = !isDroppingSauce;
        Debug.Log("Toggled Sauce to " + isDroppingSauce);
    }
}

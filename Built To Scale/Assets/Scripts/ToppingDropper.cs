using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingDropper : MonoBehaviour {
    [SerializeField] GameObject toppingPrefab;

    private Movement movement;
    private Pizza currentPizza;

    private bool isDroppingToppings = false;

    private void Start() {
        movement = GetComponent<Movement>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingToppings && other.CompareTag("Pizza") && movement.GetIsMoving()) {
            Instantiate(toppingPrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingToppings() {
        isDroppingToppings = !isDroppingToppings;
        Debug.Log("Toggled Toppings to " + isDroppingToppings);
    }
}

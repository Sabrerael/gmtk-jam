using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingDropper : MonoBehaviour {
    [SerializeField] GameObject toppingPrefab;
    [SerializeField] GameObject largerToppingPrefab;

    private Movement movement;
    private Pizza currentPizza;

    private bool isDroppingToppings = false;
    private bool useLargerToppings = false;

    private void Start() {
        movement = GetComponent<Movement>();
        useLargerToppings = GameManager.instance.GetBiggerToppingsUnlock();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingToppings && other.CompareTag("Pizza") && movement.GetIsMoving()) {
            if (useLargerToppings) {
                Instantiate(largerToppingPrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
            } else {
                Instantiate(toppingPrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
            }
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

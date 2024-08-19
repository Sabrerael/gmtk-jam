using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDropper : MonoBehaviour {
    [SerializeField] GameObject cheesePrefab;
    [SerializeField] GameObject largerCheesePrefab;

    private Movement movement;
    private Pizza currentPizza;

    private bool isDroppingCheese = false;
    private bool useLargerCheese = false;

    private void Start() {
        movement = GetComponent<Movement>();
        useLargerCheese = GameManager.instance.GetBiggerCheeseUnlock();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingCheese && other.CompareTag("Pizza") && movement.GetIsMoving() ) {
            if (useLargerCheese) {
                Instantiate(largerCheesePrefab, transform.position, Quaternion.identity, currentPizza.GetCheeseLayerTransform());
            } else {
                Instantiate(cheesePrefab, transform.position, Quaternion.identity, currentPizza.GetCheeseLayerTransform());
            }
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingCheese() {
        isDroppingCheese = !isDroppingCheese;
        Debug.Log("Toggled Cheese to " + isDroppingCheese);
    }
}

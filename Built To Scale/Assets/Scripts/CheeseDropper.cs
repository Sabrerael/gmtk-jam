using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDropper : MonoBehaviour {
    [SerializeField] GameObject cheesePrefab;

    private Movement movement;
    private Pizza currentPizza;

    private bool isDroppingCheese = false;

    private void Start() {
        movement = GetComponent<Movement>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingCheese && other.CompareTag("Pizza") && movement.GetIsMoving() ) {
            Instantiate(cheesePrefab, transform.position, Quaternion.identity, currentPizza.GetCheeseLayerTransform());
            Debug.Log("Cheese");
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingCheese() {
        isDroppingCheese = !isDroppingCheese;
    }
}

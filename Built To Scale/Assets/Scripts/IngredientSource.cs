using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSource : MonoBehaviour {
    [SerializeField] PizzaMode pizzaMode;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            player.SetCurrentIngredientSource(this);
            Debug.Log("Ingredient Source of " + pizzaMode.ToString() + " has been triggered");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            Debug.Log("Ingredient Source of " + pizzaMode.ToString() + " has been untriggered");
        }
    }

    public PizzaMode GetIngredientType() {
        return pizzaMode;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPizzaButton : MonoBehaviour {
    private Pizza currentPizza;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            player.SetFinishPizzaButton(this);
            Debug.Log("Finish Pizza Button is triggered");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            player.SetFinishPizzaButton(null);
            Debug.Log("Finish Pizza Button is untriggered");
        }
    }

    public void SetCurrentPizza(Pizza pizza) {
        currentPizza = pizza;
    }
}

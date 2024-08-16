using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    private Movement movement;
    private SauceDropper sauceDropper;
    private CheeseDropper cheeseDropper;
    private PizzaMode pizzaMode;

    private void Start() {
        movement = GetComponent<Movement>();
        sauceDropper = GetComponent<SauceDropper>();
        pizzaMode = PizzaMode.Sauce;
        cheeseDropper = GetComponent<CheeseDropper>();
        cheeseDropper.enabled = false;
    }

    private void OnMove(InputValue value) {      
        movement.SetMovementValues(value.Get<Vector2>());
    }

    private void OnFire(InputValue value) {
        if (pizzaMode == PizzaMode.Sauce) {
            cheeseDropper.ToggleDroppingCheese();
            sauceDropper.ToggleDroppingSauce();
            pizzaMode = PizzaMode.Cheese;
        } else if (pizzaMode == PizzaMode.Cheese) {
            cheeseDropper.ToggleDroppingCheese();
            sauceDropper.ToggleDroppingSauce();
            pizzaMode = PizzaMode.Sauce;
        }
    }
}

public enum PizzaMode {
    Sauce,
    Cheese,
    Toppings
}
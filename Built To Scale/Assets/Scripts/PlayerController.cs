using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private Movement movement;
    private SauceDropper sauceDropper;
    private CheeseDropper cheeseDropper;
    private PizzaMode pizzaMode;

    private IngredientSource currentIngredientSource = null;
    private Pizza pizza;

    private void Start() {
        movement = GetComponent<Movement>();
        sauceDropper = GetComponent<SauceDropper>();
        pizzaMode = PizzaMode.Sauce;
        cheeseDropper = GetComponent<CheeseDropper>();
    }

    private void OnMove(InputValue value) {      
        movement.SetMovementValues(value.Get<Vector2>());
    }

    private void OnFire(InputValue value) {
        if (currentIngredientSource != null && pizza != null) {
            if (pizza.GetCheeseDone()) {
                // Toppings
            } else if (pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Cheese) {
                pizzaMode = PizzaMode.Cheese;
                sauceDropper.ToggleDroppingSauce();
                cheeseDropper.ToggleDroppingCheese();
            }
        }
    }

    public void SetCurrentIngredientSource(IngredientSource source) {
        currentIngredientSource = source;
    }

    public void SetPizza(Pizza pizza) {
        this.pizza = pizza;
    }
}

public enum PizzaMode {
    Sauce,
    Cheese,
    Toppings
}
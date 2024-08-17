using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] Pizza blankPizza;

    private Movement movement;
    private SauceDropper sauceDropper;
    private CheeseDropper cheeseDropper;
    private ToppingDropper toppingDropper;
    [SerializeField] private PizzaMode pizzaMode;

    private IngredientSource currentIngredientSource = null;
    private FinishPizzaButton finishPizzaButton = null;
    private Pizza pizza;

    private int money = 0;

    private void Start() {
        movement = GetComponent<Movement>();
        sauceDropper = GetComponent<SauceDropper>();
        cheeseDropper = GetComponent<CheeseDropper>();
        toppingDropper = GetComponent<ToppingDropper>();
        pizzaMode = PizzaMode.Sauce;
    }

    private void OnMove(InputValue value) {      
        movement.SetMovementValues(value.Get<Vector2>());
    }

    private void OnFire(InputValue value) {
        if (currentIngredientSource != null && pizza != null) {
            if (pizza.GetCheeseDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Toppings) {
                pizzaMode = PizzaMode.Toppings;
                cheeseDropper.ToggleDroppingCheese();
                toppingDropper.ToggleDroppingToppings();
            } else if (pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Cheese) {
                pizzaMode = PizzaMode.Cheese;
                sauceDropper.ToggleDroppingSauce();
                cheeseDropper.ToggleDroppingCheese();
            } else if (!pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Sauce) {
                pizzaMode = PizzaMode.Sauce;
                sauceDropper.ToggleDroppingSauce();
            }
        }

        if (finishPizzaButton != null && pizza != null && pizza.GetToppingsDone()) {
            money += 10;
            Debug.Log("You've made $" + money);
            toppingDropper.ToggleDroppingToppings();
            Destroy(pizza.gameObject);
            Instantiate(blankPizza, new Vector3(0,1,0), Quaternion.identity);
        }
    }

    public void SetCurrentIngredientSource(IngredientSource source) {
        currentIngredientSource = source;
    }

    public void SetFinishPizzaButton(FinishPizzaButton finishPizzaButton) {
        this.finishPizzaButton = finishPizzaButton;
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
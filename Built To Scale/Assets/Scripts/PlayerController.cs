using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] Pizza blankPizza;
    [SerializeField] int moneyPerPizza = 100;
    [SerializeField] GameObject brush;
    [SerializeField] GameObject cheeseBag;
    [SerializeField] GameObject pepperoniBag;

    private Movement movement;
    private SauceDropper sauceDropper;
    private CheeseDropper cheeseDropper;
    private ToppingDropper toppingDropper;
    [SerializeField] private PizzaMode pizzaMode;

    private IngredientSource currentIngredientSource = null;
    private FinishPizzaButton finishPizzaButton = null;
    private Pizza pizza;

    private void Start() {
        movement = GetComponent<Movement>();
        sauceDropper = GetComponent<SauceDropper>();
        cheeseDropper = GetComponent<CheeseDropper>();
        toppingDropper = GetComponent<ToppingDropper>();
        pizzaMode = PizzaMode.Sauce;

        GameManager.instance.ResetUI();
        GameManager.instance.SetRunTimer(true);
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
                cheeseBag.SetActive(false);
                pepperoniBag.SetActive(true);
            } else if (pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Cheese) {
                pizzaMode = PizzaMode.Cheese;
                sauceDropper.ToggleDroppingSauce();
                cheeseDropper.ToggleDroppingCheese();
                brush.SetActive(false);
                cheeseBag.SetActive(true);
            } else if (!pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Sauce) {
                pizzaMode = PizzaMode.Sauce;
                sauceDropper.ToggleDroppingSauce();
                pepperoniBag.SetActive(false);
                brush.SetActive(true);
            }
        }

        if (finishPizzaButton != null && pizza != null && pizza.GetToppingsDone()) {
            GameManager.instance.UpdateMoney(moneyPerPizza);
            toppingDropper.ToggleDroppingToppings();
            Destroy(pizza.gameObject);
            Instantiate(blankPizza, new Vector3(0,0.85f,0), Quaternion.identity);
            GameManager.instance.UpdateTutorialText(PizzaMode.Sauce, 0);
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
    Toppings,
    Done
}
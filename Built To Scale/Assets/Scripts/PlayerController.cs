using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] Pizza blankPizza;
    [SerializeField] int moneyPerPizza = 100;
    [SerializeField] GameObject brush;
    [SerializeField] GameObject cheeseBag;
    [SerializeField] GameObject pepperoniBag;
    [SerializeField] AudioClip switchingSound;
    [SerializeField] AudioClip buttonPush;

    private Movement movement;
    private SauceDropper sauceDropper;
    private CheeseDropper cheeseDropper;
    private ToppingDropper toppingDropper;
    private Animator animator;
    [SerializeField] private PizzaMode pizzaMode;

    private IngredientSource currentIngredientSource = null;
    private FinishPizzaButton finishPizzaButton = null;
    private Pizza pizza;

    private void Start() {
        movement = GetComponent<Movement>();
        sauceDropper = GetComponent<SauceDropper>();
        cheeseDropper = GetComponent<CheeseDropper>();
        toppingDropper = GetComponent<ToppingDropper>();
        animator = GetComponent<Animator>();
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
                cheeseDropper.ToggleDroppingCheese(false);
                toppingDropper.ToggleDroppingToppings(true);
                cheeseBag.SetActive(false);
                pepperoniBag.SetActive(true);
            } else if (pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Cheese) {
                pizzaMode = PizzaMode.Cheese;
                sauceDropper.ToggleDroppingSauce(false);
                cheeseDropper.ToggleDroppingCheese(true);
                brush.SetActive(false);
                cheeseBag.SetActive(true);
            } else if (!pizza.GetSauceDone() && currentIngredientSource.GetIngredientType() == PizzaMode.Sauce) {
                pizzaMode = PizzaMode.Sauce;
                sauceDropper.ToggleDroppingSauce(true);
                pepperoniBag.SetActive(false);
                brush.SetActive(true);
            }
            AudioSource.PlayClipAtPoint(switchingSound, transform.position);
            animator.SetTrigger("Switching");
        }

        if (finishPizzaButton != null && pizza != null && pizza.GetToppingsDone()) {
            GameManager.instance.UpdateMoney(moneyPerPizza);
            AudioSource.PlayClipAtPoint(buttonPush, transform.position);
            toppingDropper.ToggleDroppingToppings(false);
            pizza.GetComponent<Animator>().SetTrigger("Finish");
            Destroy(pizza.gameObject, 0.75f);
            Instantiate(blankPizza, new Vector3(0,-13,0), Quaternion.identity);
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
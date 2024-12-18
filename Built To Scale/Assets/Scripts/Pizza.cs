using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    [SerializeField] Transform sauceLayerTransform;
    [SerializeField] Transform cheeseLayerTransform;
    [SerializeField] Transform toppingsLayerTransform;

    private PlayerController player;
    private int sauceIndicatorCount = 0;
    private int cheeseIndicatorCount = 0;
    private int toppingsIndicatorCount = 0;
    private bool sauceDone = false;
    private bool cheeseDone = false;
    private bool toppingsDone = false;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        player.GetComponent<SauceDropper>().SetPizza(this);
        player.GetComponent<CheeseDropper>().SetPizza(this);
        player.GetComponent<ToppingDropper>().SetPizza(this);
        player.SetPizza(this);
    }

    public Transform GetSauceLayerTransform() {
        return sauceLayerTransform;
    }

    public Transform GetCheeseLayerTransform() {
        return cheeseLayerTransform;
    }

    public Transform GetToppingsLayerTransform() {
        return toppingsLayerTransform;
    }

    public bool GetSauceDone() {
        return sauceDone;
    }

    public bool GetCheeseDone() {
        return cheeseDone;
    }

    public bool GetToppingsDone() {
        return toppingsDone;
    }

    public void UpdateIndicatorCount(PizzaMode pizzaMode) {
        if (pizzaMode == PizzaMode.Sauce) {
            sauceIndicatorCount++;
            if (sauceIndicatorCount == 56) {
                sauceDone = true;
                GameManager.instance.UpdateTutorialText(PizzaMode.Cheese, 0);
            } else {
                GameManager.instance.UpdateTutorialText(PizzaMode.Sauce, Mathf.CeilToInt(((float) sauceIndicatorCount / 56.0f) * 100));
            }
        } else if (pizzaMode == PizzaMode.Cheese) {
            cheeseIndicatorCount++;
            Debug.Log("Cheese Indicator count: " + cheeseIndicatorCount);
            if (cheeseIndicatorCount == 56) {
                cheeseDone = true;
                GameManager.instance.UpdateTutorialText(PizzaMode.Toppings, 0);
            } else {
                GameManager.instance.UpdateTutorialText(PizzaMode.Cheese, Mathf.CeilToInt(((float) cheeseIndicatorCount / 56.0f) * 100));
            }
        } else if (pizzaMode == PizzaMode.Toppings) {
            toppingsIndicatorCount++;
            Debug.Log("Toppings Indicator count: " + toppingsIndicatorCount);
            if (toppingsIndicatorCount == 56) {
                toppingsDone = true;
                GameManager.instance.UpdateTutorialText(PizzaMode.Done, 0);
            } else {
                GameManager.instance.UpdateTutorialText(PizzaMode.Toppings, Mathf.CeilToInt(((float) toppingsIndicatorCount / 56.0f) * 100));
            }
        }
    }
}

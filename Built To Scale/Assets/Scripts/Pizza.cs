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
    private bool sauceDone = false;
    private bool cheeseDone = false;
    //private int toppingsIndicatorCount = 0;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        player.GetComponent<SauceDropper>().SetPizza(this);
        player.GetComponent<CheeseDropper>().SetPizza(this);
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

    public void UpdateIndicatorCount(PizzaMode pizzaMode) {
        if (pizzaMode == PizzaMode.Sauce) {
            sauceIndicatorCount++;
            Debug.Log("Sauce Indicator count: " + sauceIndicatorCount);
            if (sauceIndicatorCount == 32) {
                sauceDone = true;
                Debug.Log("All Sauce Indicators set");
            }
        } else if (pizzaMode == PizzaMode.Cheese) {
            cheeseIndicatorCount++;
            Debug.Log("Cheese Indicator count: " + cheeseIndicatorCount);
            if (cheeseIndicatorCount == 32) {
                cheeseDone = true;
                Debug.Log("All Cheese Indicators set");
            }
        }
    }
}

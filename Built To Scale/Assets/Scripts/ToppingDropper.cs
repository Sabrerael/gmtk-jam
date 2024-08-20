using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingDropper : MonoBehaviour {
    [SerializeField] GameObject toppingPrefab;
    [SerializeField] GameObject largerToppingPrefab;
    [SerializeField] float timeBetweenDrops = 0.1f;
    [SerializeField] AudioClip dropSound;

    private Movement movement;
    private Pizza currentPizza;
    private float timer = 0;

    private bool isDroppingToppings = false;
    private bool useLargerToppings = false;
    private bool canDropToppings = true;

    private void Start() {
        movement = GetComponent<Movement>();
        useLargerToppings = GameManager.instance.GetBiggerToppingsUnlock();
    }

    private void Update() {
        if (!canDropToppings) {
            timer += Time.deltaTime;

            if (timer >=timeBetweenDrops) {
                canDropToppings = true;
                timer = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingToppings && canDropToppings && other.CompareTag("Pizza") && movement.GetIsMoving()) {
            if (useLargerToppings) {
                Instantiate(largerToppingPrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
            } else {
                Instantiate(toppingPrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
            }
            canDropToppings = false;
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingToppings(bool value) {
        isDroppingToppings = value;
        Debug.Log("Toggled Toppings to " + isDroppingToppings);
    }
}

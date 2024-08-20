using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDropper : MonoBehaviour {
    [SerializeField] GameObject cheesePrefab;
    [SerializeField] GameObject largerCheesePrefab;
    [SerializeField] float timeBetweenDrops = 0.1f;
    [SerializeField] AudioClip dropSound;

    private Movement movement;
    private Pizza currentPizza;
    private float timer = 0;

    private bool isDroppingCheese = false;
    private bool useLargerCheese = false;
    private bool canDropCheese = true;

    private void Start() {
        movement = GetComponent<Movement>();
        useLargerCheese = GameManager.instance.GetBiggerCheeseUnlock();
    }

    private void Update() {
        if (!canDropCheese) {
            timer += Time.deltaTime;

            if (timer >=timeBetweenDrops) {
                canDropCheese = true;
                timer = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingCheese && canDropCheese && other.CompareTag("Pizza") && movement.GetIsMoving() ) {
            if (useLargerCheese) {
                Instantiate(largerCheesePrefab, transform.position, Quaternion.identity, currentPizza.GetCheeseLayerTransform());
            } else {
                Instantiate(cheesePrefab, transform.position, Quaternion.identity, currentPizza.GetCheeseLayerTransform());
            }
            canDropCheese = false;
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingCheese() {
        isDroppingCheese = !isDroppingCheese;
        Debug.Log("Toggled Cheese to " + isDroppingCheese);
    }
}

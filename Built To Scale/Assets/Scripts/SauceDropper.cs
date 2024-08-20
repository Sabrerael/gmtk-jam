using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceDropper : MonoBehaviour {
    [SerializeField] GameObject saucePrefab;
    [SerializeField] GameObject largerSaucePrefab;
    [SerializeField] float timeBetweenDrops = 0.1f;
    [SerializeField] AudioClip dropSound;

    private Movement movement;
    private Pizza currentPizza;
    private float timer = 0;

    private bool isDroppingSauce = true;
    private bool useLargerSauce = false;
        private bool canDropSauce = true;

    private void Start() {
        movement = GetComponent<Movement>();
        useLargerSauce = GameManager.instance.GetBiggerSauceUnlock();
    }

    private void Update() {
        if (!canDropSauce) {
            timer += Time.deltaTime;

            if (timer >= timeBetweenDrops) {
                canDropSauce = true;
                timer = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (isDroppingSauce && canDropSauce && other.CompareTag("Pizza") && movement.GetIsMoving()) {
            if (useLargerSauce) {
                Instantiate(largerSaucePrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
            } else {
                Instantiate(saucePrefab, transform.position, Quaternion.identity, currentPizza.GetSauceLayerTransform());
            }
            canDropSauce = false;
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
        }
    }

    public void SetPizza(Pizza pizza) {
        currentPizza = pizza;
    }

    public void ToggleDroppingSauce(bool value) {
        isDroppingSauce = value;
        Debug.Log("Toggled Sauce to " + isDroppingSauce);
    }
}

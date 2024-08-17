using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {
    [SerializeField] PizzaMode indicatorType;
    [SerializeField] Pizza pizza;

    private bool isTouched = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!isTouched && other.CompareTag(indicatorType.ToString())) {
            isTouched = true;
            pizza.UpdateIndicatorCount(indicatorType);
        }
    }
}

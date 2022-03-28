using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CheckIfPlayerWithinArea : MonoBehaviour{
    public bool IsInArea { get; set; }
    public event Action PlayerEnteredAreaEvent;
    public event Action PlayerLeftAreaEvent;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            IsInArea = true;
            PlayerEnteredAreaEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            IsInArea = false;
            PlayerLeftAreaEvent?.Invoke();
        }
    }
}

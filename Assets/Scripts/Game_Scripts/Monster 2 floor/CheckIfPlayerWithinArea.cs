using System;
using UnityEngine;

public class CheckIfPlayerWithinArea : MonoBehaviour{
    public bool IsInArea { get; set; }
    public static event Action PlayerEnteredAreaEvent;
    public static event Action PlayerLeftedAreaEvent;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            IsInArea = true;
            PlayerEnteredAreaEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            IsInArea = false;
            PlayerLeftedAreaEvent?.Invoke();
        }
    }
}

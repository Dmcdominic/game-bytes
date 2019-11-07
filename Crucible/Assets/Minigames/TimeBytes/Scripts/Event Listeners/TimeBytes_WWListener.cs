using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBytes_WWListener : TimeBytes_EventListener {
  // Harmony
  protected override void OnOption1() {
    MinigameController.Instance.FinishGame(LastMinigameFinish.TIE);
  }

  // Balance
  protected override void OnOption2() {
    if (Random.Range(0f, 1f) > 0.5f) {
      MinigameController.Instance.FinishGame(LastMinigameFinish.P1WIN);
    } else {
      MinigameController.Instance.FinishGame(LastMinigameFinish.P2WIN);
    }
  }
}

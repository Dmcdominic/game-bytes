using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class TimeBytes_EventListener : MonoBehaviour {

  // Elements to listen for
  public List<TimeBytes_StoryElement> onEntryEvents;
  public List<TimeBytes_Fork> onOption1Events;
  public List<TimeBytes_Fork> onOption2Events;
  public List<TimeBytes_Extension> onContinueEvents;


  // Init listeners
  private void Start() {
    // On Entry
    foreach (TimeBytes_StoryElement element in onEntryEvents) {
      element.entryEvent.AddListener(_OnEntry);
    }

    // On choice 1
    foreach (TimeBytes_Fork fork in onOption1Events) {
      fork.Option1.onChooseEvent.AddListener(_OnOption1);
    }

    // On choice 2
    foreach (TimeBytes_Fork fork in onOption2Events) {
      fork.Option2.onChooseEvent.AddListener(_OnOption2);
    }

    // On continue
    foreach (TimeBytes_Extension extension in onContinueEvents) {
      extension.continuation.onChooseEvent.AddListener(_OnContinue);
    }
  }

  private void _OnEntry() {
    OnAny();
    OnEntry();
  }
  private void _OnOption1() {
    OnAny();
    OnOption1();
  }
  private void _OnOption2() {
    OnAny();
    OnOption2();
  }
  private void _OnContinue() {
    OnAny();
    OnContinue();
  }

  protected virtual void OnAny() { }
  protected virtual void OnEntry() { }
  protected virtual void OnOption1() { }
  protected virtual void OnOption2() { }
  protected virtual void OnContinue() { }

}

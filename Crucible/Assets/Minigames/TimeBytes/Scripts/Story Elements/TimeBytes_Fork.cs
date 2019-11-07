using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A story node that allows you to choose between two options.
/// </summary>
[CreateAssetMenu(menuName="TimeBytes/Fork",order = 0,fileName="Fork")]
public class TimeBytes_Fork : TimeBytes_StoryElement {

  // The two options
  [Tooltip("The first option presented to the player.")]
  public TimeBytes_StoryOption Option1;
  [Tooltip("The second option presented to the player.")]
  public TimeBytes_StoryOption Option2;

}

// A single selectable option for a story node
[System.Serializable]
public class TimeBytes_StoryOption {
  [Tooltip("The text displayed on the button for this option.")]
  public string text;

  [Tooltip("The story element to go if this option is selected. You may leave this blank in order to progress nowhere.")]
  public TimeBytes_StoryElement nextElement;

  [HideInInspector]
  public UnityEvent onChooseEvent = new UnityEvent();
}

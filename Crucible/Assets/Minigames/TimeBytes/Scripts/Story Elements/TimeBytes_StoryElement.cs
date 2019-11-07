using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The base class for every node or leaf in a branching story
/// </summary>
public abstract class TimeBytes_StoryElement : ScriptableObject {

  [TextArea]
  [Tooltip("The story element description that will be presented to the player.")]
  public string description;

  [Tooltip("[Optional] If this event has already been visited, the player will be sent to Revisit Alt instead.")]
  public TimeBytes_StoryElement revisitAlt;

  //[Tooltip("[Optional] This event will be invoked as soon as the player enters this node.")]
  //public string entryEvent;

  [HideInInspector]
  public UnityEvent entryEvent = new UnityEvent();


  // Revisit tracking
  [HideInInspector]
  public bool alreadyVisited;


  // Init
  private void OnEnable() {
    alreadyVisited = false;
  }

}

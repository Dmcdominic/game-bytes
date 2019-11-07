using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base class for every node or leaf in a branching story
/// </summary>
public abstract class TimeBytes_StoryElement : ScriptableObject {

  [TextArea]
  [Tooltip("The story element description that will be presented to the player.")]
  public string description;
  
  [Tooltip("[Optional] This event will be invoked as soon as the player enters this node.")]
  public string entryEvent;

}

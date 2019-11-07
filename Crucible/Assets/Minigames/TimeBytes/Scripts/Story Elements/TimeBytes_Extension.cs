using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A story node with only a single "continue" option.
/// </summary>
[CreateAssetMenu(menuName="TimeBytes/Extension",order=1)]
public class TimeBytes_Extension : TimeBytes_StoryElement {

  [Tooltip("The only option presented to the player.\nNOTE - Leave the text field blank to use the default \"Continue...\"")]
  public TimeBytes_StoryOption continuation;

}

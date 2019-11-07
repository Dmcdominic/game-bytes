using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores configuration data, such as the root story element and option time allowed.
/// </summary>
[CreateAssetMenu(menuName="TimeBytes/Config",order=10)]
public class TimeBytes_Config : ScriptableObject {
  // ========== Static settings ==========
  // The total time a player has to choose an option before failing
  public const float max_choice_time = 6f;
  public const string default_continue_text = "Continue...";

  // The interval between each character displayed in story descriptions
  public const float auto_text_char_interval = 0.08f;
  public static string[] extra_chars =     { ".",     "," };
  public static float[] extra_char_times = { 0.35f,   0.2f };

  // The joystick input threshold necessary to skip the text animation
  public const float joystick_skip_thresh = 0.4f;



  // ========== Reference settings ==========
  public TimeBytes_StoryElement root;
}

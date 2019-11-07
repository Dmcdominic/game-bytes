using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Controls the story display and options for a single player.
/// </summary>
public class TimeBytes_DisplayController : MonoBehaviour {

  // Public Fields
  public int player;
  public TimeBytes_Config config;

  // Scene References
  public TextMeshProUGUI description_TMP;
  public TextMeshProUGUI option1_TMP;
  public TextMeshProUGUI option2_TMP;

  // Private vars
  private TimeBytes_StoryElement current_element;
  private float time_til_next_char;


  // Start is called before the first frame update
  private void Start() {
    display_element(config.root);
  }

  // Called every frame
  private void Update() {
    // Update the description, character by character
    if (!descr_fully_visible()) {
      time_til_next_char -= Time.deltaTime;
      while (time_til_next_char < 0 && !descr_fully_visible()) {
        incr_descr_length();
      }
    }

    // Check for input from this player, to select an option (as long as the animation is done)
    if (descr_fully_visible()) {
      Debug.Log("description is fully visible.");
      if (current_element is TimeBytes_Fork) {
        Debug.Log("Current element is a fork");
        if (MinigameInputHelper.IsButton1Down(player)) {
          Debug.Log("button1down: " + current_element);
          TimeBytes_Fork fork = current_element as TimeBytes_Fork;
          choose_option(fork.Option1);
        } else if (MinigameInputHelper.IsButton2Down(player)) {
          Debug.Log("button2down: " + current_element);
          TimeBytes_Fork fork = current_element as TimeBytes_Fork;
          choose_option(fork.Option1);
        }
      } else if (current_element is TimeBytes_Extension) {
        if (MinigameInputHelper.IsButton1Down(player) || MinigameInputHelper.IsButton2Down(player)) {
          TimeBytes_Extension extension = current_element as TimeBytes_Extension;
          choose_option(extension.continuation);
        }
      }
    }

    // If any joystick input was given, skip the rest of the text animation
    bool hor_skip = Mathf.Abs(MinigameInputHelper.GetHorizontalAxis(player)) > TimeBytes_Config.joystick_skip_thresh;
    bool vert_skip = Mathf.Abs(MinigameInputHelper.GetVerticalAxis(player)) > TimeBytes_Config.joystick_skip_thresh;
    if (hor_skip || vert_skip) {
      description_TMP.maxVisibleCharacters = description_TMP.text.Length;
    }
  }

  private void choose_option(TimeBytes_StoryOption option) {
    Debug.Log("choose_option called for option: " + option);
    // Invoke the option's onChooseEvent, if it's not empty
    if (option.onChooseEvent.Length > 0) {
      // TODO - invoke the option's option.onChooseEvent
    }

    if (option.nextElement != null) {
      display_element(option.nextElement);
    }
  }

  // Displays a given story element for this player
  private void display_element(TimeBytes_StoryElement element) {
    current_element = element;
    MinigameController.Instance.AddScore(player, 1);

    // Invoke the element's entryEvent, if it's not empty
    if (element.entryEvent.Length > 0) {
      // TODO - invoke the element's entryEvent
    }

    // Initialize the description text
    description_TMP.text = element.description;
    description_TMP.maxVisibleCharacters = 0;
    time_til_next_char = 0.25f;

    if (element is TimeBytes_Fork) {
      TimeBytes_Fork fork = element as TimeBytes_Fork;
      option1_TMP.text = fork.Option1.text;
      option2_TMP.text = fork.Option2.text;

    } else if (element is TimeBytes_Extension) {
      TimeBytes_Extension extension = element as TimeBytes_Extension;
      // TODO - just have a third, centered text display for "continue"?
      if (extension.continuation.text.Length == 0) {
        option1_TMP.text = TimeBytes_Config.default_continue_text;
      } else {
        option1_TMP.text = extension.continuation.text;
      }
      option2_TMP.text = "";

    } else if (element is TimeBytes_Leaf) {
      TimeBytes_Leaf leaf = element as TimeBytes_Leaf;
      option1_TMP.text = "";
      option2_TMP.text = "";
    }
  }

  // Returns true iff description_TMP is fully visible
  private bool descr_fully_visible() {
    return description_TMP.maxVisibleCharacters >= description_TMP.text.Length;
  }

  // Increases the number of characters displayed in the description by 1
  private void incr_descr_length() {
    if (description_TMP.maxVisibleCharacters >= description_TMP.text.Length) {
      return;
    }

    string thisChar = description_TMP.text.Substring(description_TMP.maxVisibleCharacters, 1);
    description_TMP.maxVisibleCharacters++;

    // Increment the time until the next character, based on the last character
    time_til_next_char += TimeBytes_Config.auto_text_char_interval;
    for (int i = 0; i < TimeBytes_Config.extra_chars.Length; i++) {
      if (thisChar.Equals(TimeBytes_Config.extra_chars[i])) {
        time_til_next_char += TimeBytes_Config.extra_char_times[i];
        break;
      }
    }
  }
}

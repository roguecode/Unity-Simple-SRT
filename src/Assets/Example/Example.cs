using UnityEngine;

public class Example : MonoBehaviour
{
  void Start()
  {
    // Typically Begin would be called from the same place that starts the video
    StartCoroutine(FindObjectOfType<SubtitleDisplayer>().Begin());
  }
}

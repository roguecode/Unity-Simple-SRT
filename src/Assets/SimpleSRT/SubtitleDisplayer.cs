using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleDisplayer : MonoBehaviour
{
  public TextAsset Subtitle;
  public Text Text;
  public Text Text2;

  [Range(0, 1)]
  public float FadeTime;

  public IEnumerator Begin()
  {
    var currentlyDisplayingText = Text;
    var fadedOutText = Text2;

    currentlyDisplayingText.text = string.Empty;
    fadedOutText.text = string.Empty;

    currentlyDisplayingText.gameObject.SetActive(true);
    fadedOutText.gameObject.SetActive(true);

    yield return FadeTextOut(currentlyDisplayingText);
    yield return FadeTextOut(fadedOutText);

    var parser = new SRTParser(Subtitle);

    var startTime = Time.time;
    SubtitleBlock currentSubtitle = null;
    while (true)
    {
      var elapsed = Time.time - startTime;
      var subtitle = parser.GetForTime(elapsed);
      if (subtitle != null)
      {
        if (!subtitle.Equals(currentSubtitle))
        {
          currentSubtitle = subtitle;

          // Swap references around
          var temp = currentlyDisplayingText;
          currentlyDisplayingText = fadedOutText;
          fadedOutText = temp;

          // Switch subtitle text
          currentlyDisplayingText.text = currentSubtitle.Text;

          // And fade out the old one. Yield on this one to wait for the fade to finish before doing anything else.
          StartCoroutine(FadeTextOut(fadedOutText));

          // Yield a bit for the fade out to get part-way
          yield return new WaitForSeconds(FadeTime / 3);

          // Fade in the new current
          yield return FadeTextIn(currentlyDisplayingText);
        }
        yield return null;
      }
      else
      {
        Debug.Log("Subtitles ended");
        StartCoroutine(FadeTextOut(currentlyDisplayingText));
        yield return FadeTextOut(fadedOutText);
        currentlyDisplayingText.gameObject.SetActive(false);
        fadedOutText.gameObject.SetActive(false);
        yield break;
      }
    }
  }

  void OnValidate()
  {
    FadeTime = ((int)(FadeTime * 10)) / 10f;
  }

  IEnumerator FadeTextOut(Text text)
  {
    var toColor = text.color;
    toColor.a = 0;
    yield return Fade(text, toColor, Ease.OutSine);
  }

  IEnumerator FadeTextIn(Text text)
  {
    var toColor = text.color;
    toColor.a = 1;
    yield return Fade(text, toColor, Ease.InSine);
  }

  IEnumerator Fade(Text text, Color toColor, Ease ease)
  {
    yield return DOTween.To(() => text.color, color => text.color = color, toColor, FadeTime).SetEase(ease).WaitForCompletion();
  }
}

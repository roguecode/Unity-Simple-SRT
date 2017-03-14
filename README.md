# Unity-Simple-SRT
A super simple SRT subtitle parser

It'll parse most sane SRT's, and will display them in a `Text` element, crossfading between lines depending on a `Fade Time` you set.

## To use it
- Add the `Subtitle Displayer` component to something in the world. 
- Create two `Text` UI elements, both the same, and drag their references to the `Subtitle Displayer` component.
- Rename your `.srt` file to `.txt`, then drag it to the `Subtitle` field on `Subtitle Displayer`.
- Call `StartCoroutine(subtitleDisplayer.Begin())` to start the subtitles.

A sub file like this:
```
1
00:00:00,000 --> 00:00:02,500
Mary had

2
00:00:02,500 --> 00:00:04,500
a little <i>lamb</i>

3
00:00:04,500 --> 00:00:06,500
little <b>lamb</b>

4
00:00:06,500 --> 00:00:08,500
little <size=40>lamb</size>

5
00:00:09,000 --> 00:00:12,000
<b><i><color=red>Until she didn't.</color></i></b>
```
Will result in this:

![Totally the best gif evar](https://github.com/roguecode/Unity-Simple-SRT/blob/master/Preview.gif?raw=true)

A good program to make subs is [SubtitleEdit](https://github.com/SubtitleEdit/subtitleedit/releases)

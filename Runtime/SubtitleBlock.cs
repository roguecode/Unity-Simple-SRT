namespace Roguecode.UnitySimpleSRT
{
    public class SubtitleBlock
    {
        static SubtitleBlock _blank;
        public static SubtitleBlock Blank
        {
            get { return _blank ?? (_blank = new SubtitleBlock(0, 0, 0, string.Empty)); }
        }
        public int Index { get; private set; }
        public double Length { get; private set; }
        public double From { get; private set; }
        public double To { get; private set; }
        public string Text { get; private set; }

        public SubtitleBlock(int index, double from, double to, string text)
        {
            this.Index = index;
            this.From = from;
            this.To = to;
            this.Length = to - from;
            this.Text = text;
        }
    }
}
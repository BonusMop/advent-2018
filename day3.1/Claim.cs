using System;
using System.Text.RegularExpressions;

namespace day3._1
{
    public class Claim
    {
        private const string ClaimPattern = @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)";

        public int LeftMargin { get; private set; }
        public int TopMargin { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int Id { get; private set; }

        public Claim(string description)
        {
            Match match = Regex.Match(description, ClaimPattern);
            if (match.Groups.Count != 6) 
                throw new ApplicationException(String.Format("Unexpected claim description format: {0}", description));
            
            this.Id = Int32.Parse(match.Groups[1].Value);
            this.LeftMargin = Int32.Parse(match.Groups[2].Value);
            this.TopMargin = Int32.Parse(match.Groups[3].Value);
            this.Width = Int32.Parse(match.Groups[4].Value);
            this.Height = Int32.Parse(match.Groups[5].Value);
        }

        public Claim(int x, int y, int width, int height)
        {
            this.LeftMargin = x;
            this.TopMargin = y;
            this.Width = width;
            this.Height = height;
        }

        public Claim OverlapsWith(Claim competingClaim)
        {
            int x1 = Math.Max(this.LeftMargin, competingClaim.LeftMargin);
            int y1 = Math.Max(this.TopMargin, competingClaim.TopMargin);
            int x2 = Math.Min(this.LeftMargin+this.Width, competingClaim.LeftMargin+competingClaim.Width);
            int y2 = Math.Min(this.TopMargin+this.Height, competingClaim.TopMargin+competingClaim.Height);
            
            int width = x2-x1;
            int height = y2-y1;

            if (height <=0 || width <=0) return null;
            return new Claim(x1, y1, width, height);
        }
    }
}

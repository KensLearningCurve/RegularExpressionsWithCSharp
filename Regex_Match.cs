using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegularExpressionExamples
{
    public class Regex_Match
    {
        [Fact]
        public void Hyperlinks()
        {
            string html = "<p>This is some text from a website. I have used <a href=\"https://www.google.com\">Google</a> to find it. I did not use <a href=\"https://www.bing.com\">Bing</a> to find it.</p>";
            string pattern = @"<a[^>]+href=""(.*?)""[^>]*>(.*?)<\/a>";
            MatchCollection regexMatches = Regex.Matches(html, pattern);

            Assert.Equal(2, regexMatches.Count);

            List<string> expected = new() { "<a href=\"https://www.google.com\">Google</a>", "<a href=\"https://www.bing.com\">Bing</a>" };

            foreach (Match match in regexMatches)
            {
                if (match.Success)
                {
                    Assert.Equal(3, match.Groups.Count);

                    if (match.Value == expected[0])
                    {
                        Assert.Equal(expected[0], match.Groups[0].Value);
                        Assert.Equal("https://www.google.com", match.Groups[1].Value);
                        Assert.Equal("Google", match.Groups[2].Value);
                    }
                }
            }
        }

        [Theory]
        [InlineData("<p>This is some text from a website. I have used <a href=\"https://www.google.com\">Google</a> to find it. I did not use <a href=\"https://www.bing.com\">Bing</a> to find it.</p>", @"<a[^>]+href=""(.*?)""[^>]*>(.*?)<\/a>", new string[] { "<a href=\"https://www.google.com\">Google</a>", "https://www.google.com", "Google" })]
        public void OneHyperlink(string input, string pattern, string[] possibleStrings)
        {
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                Assert.Equal(3, match.Groups.Count);

                Assert.Equal(possibleStrings[0], match.Groups[0].Value);
                Assert.Equal(possibleStrings[1], match.Groups[1].Value);
                Assert.Equal(possibleStrings[2], match.Groups[2].Value);
            }
        }
    }
}
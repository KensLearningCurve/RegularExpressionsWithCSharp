using System.Text.RegularExpressions;

namespace RegularExpressionExamples
{
    public class Regex_Replace
    {
        [Fact]
        public void Replace_Text_With_RegEx()
        {
            string testString = "This is a text with HTML: <b>Hello</b>, <i>world</i>. As you can see it also contains a link to <a href=\"https://www.bing.com\">Bing</a>";

            Regex regex = new("<[^>]+>");
            string result = regex.Replace(testString, "");
            Assert.Equal("This is a text with HTML: Hello, world. As you can see it also contains a link to Bing", result);
        }
    }
}

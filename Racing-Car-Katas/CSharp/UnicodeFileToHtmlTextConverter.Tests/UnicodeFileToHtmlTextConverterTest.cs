
using NUnit.Framework;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    [TestFixture]
    public class HtmlConverterTest
    {
    [Test]
    public void FileNameIsSetCorrectlyWhenHtmlConverterInitialised()
    {
      UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
      Assert.AreEqual("foobar.txt", converter.GetFilename());
    }

      [Test]
      public void X()
      {
        var fileText = "First line<br /><br />Second line<br />";
        var converter = new UnicodeFileToHtmlTextConverter("C:\\Users\\EllaJennings\\Documents\\CPD\\github-projects\\katas\\Racing-Car-Katas\\CSharp\\UnicodeFileToHtmlTextConverter.Tests\\TextFile1.txt");
        var result = converter.ConvertToHtml();
        Assert.That(result, Is.EqualTo(fileText));
      }
  }
}

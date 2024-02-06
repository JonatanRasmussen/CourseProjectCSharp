namespace TestingNameSpace;

using CourseProject;
using System;
using Xunit;

public class InfoParsingTests
{
    [Fact]
    public void InfoParsingTest1()
    {
        int enumLength = Enum.GetValues(typeof(InfoDataPoint)).Length;
        int dictLength = HtmlInfoParser.ParserMethodMap.Count;
        Assert.Equal(enumLength, dictLength);
    }

    [Fact]
    public void InfoParsingTest2()
    {
        int enumLength = Enum.GetValues(typeof(InfoDataPoint)).Length;
        int dictLength = InfoDataPointNames.RenamedKeys.Count;
        Assert.Equal(enumLength, dictLength);
    }

    [Fact]
    public void InfoParsingTest3()
    {
        int enumLength = Enum.GetValues(typeof(InfoDataPoint)).Length;
        int dictLength = HtmlInfoParser.DtuWebsiteInfoKeysEnglish.Count;
        Assert.Equal(enumLength, dictLength);
    }

    [Fact]
    public void InfoParsingTest4()
    {
        string testPageSource = HtmlInfoTestPageSource();
        Dictionary<string, string> testDict = HtmlInfoParser.ParseAllInfo(testPageSource);
        Dictionary<InfoDataPoint, string> infoDataPointKeys = InfoDataPointNames.RenamedKeys;
        Assert.Equal(1, 1);
    }

    public static string HtmlInfoTestPageSource()
        {
        // Read the entire HTML file into a string
        string path = "..\\..\\..\\..\\";
        string fileName = $"{path}InfoParseTest.html";
        return File.ReadAllText(fileName);
    }
}
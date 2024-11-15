using DeveloperTools.Pages.Tools.JsonFormatter;

namespace DeveloperTools.Test;

public class TestTools
{
    [Fact]
    public void TestJsonFormatter()
    {
        var json = "{\"id\": 1,\"name\": \"John Doe\",\"email\": \"johndoe@example.com\",\"isActive\": true,\"roles\": [\"admin\", \"user\"],\"profile\": {  \"age\": 30,  \"address\": {    \"street\": \"123 Main St\",    \"city\": \"Anytown\",    \"state\": \"CA\",    \"zip\": \"12345\"  }} }";
        var formattedJson = new JsonFormatter().FormatJson(json);

        var expectedFormattedJson = "{\r\n  \"id\": 1,\r\n  \"name\": \"John Doe\",\r\n  \"email\": \"johndoe@example.com\",\r\n  \"isActive\": true,\r\n  \"roles\": [\r\n    \"admin\",\r\n    \"user\"\r\n  ],\r\n  \"profile\": {\r\n    \"age\": 30,\r\n    \"address\": {\r\n      \"street\": \"123 Main St\",\r\n      \"city\": \"Anytown\",\r\n      \"state\": \"CA\",\r\n      \"zip\": \"12345\"\r\n    }\r\n  }\r\n}";
        Assert.NotEqual(json.Replace("\r\n", "\n"), formattedJson.Replace("\r\n", "\n"));
        Assert.Equal(expectedFormattedJson.Replace("\r\n", "\n"), formattedJson.Replace("\r\n", "\n"));
    }
}
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace DeveloperTools.UI.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class TestTools : BaseTest
{
    [Test]
    public async Task TestJsonFormatter()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);
        await Page.GetByRole(AriaRole.Link, new() { NameString = "Json Formatter" }).ClickAsync();
        await Page.WaitForURLAsync($"{RootUri.AbsoluteUri}JsonFormatter");
        var element = Page.Locator("textarea[name=\"JsonInput\"]");
        await element.ClickAsync();
        await Page.Locator("textarea[name=\"JsonInput\"]").FillAsync("a");
        await Page.Locator("textarea[name=\"JsonOutput\"]").ClickAsync();

    }
}

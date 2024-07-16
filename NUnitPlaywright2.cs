
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace PlaywrightE2E;

public class NUnitPlaywright2 : PageTest
{

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            ColorScheme = ColorScheme.Light,
            ViewportSize = new()
            {
                Width = 1920,
                Height = 1080
            },
            RecordVideoDir = "videos/",
            RecordVideoSize = new RecordVideoSize() { Width = 1920, Height = 1080 }
        };
    }

    [SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }

    [Test]
    public async Task LoginTestAsync()
    {
        await Page.ClickAsync("text=Login");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "dotnet_playwright.jpg"
        });
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");

        await Expect(Page).ToHaveTitleAsync(new Regex("Home - Execute Automation Employee App"));
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }

    [Test]
    public async Task LoginTestRecordAsync()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Page.GetByLabel("UserName").FillAsync("admin");
        await Page.GetByLabel("Password").FillAsync("password");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

        await Expect(Page).ToHaveTitleAsync(new Regex("Home - Execute Automation Employee App"));
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();

    }
}
# Test End to End with Playwright and Dotnet

## [Running Codegen](https://playwright.dev/dotnet/docs/codegen-intro)

```
PowerShell bin/Debug/net8.0/playwright.ps1 codegen <site>
```

## [Running tests](https://playwright.dev/dotnet/docs/running-tests)

### Run tests in headed mode

```
$env:HEADED="1"
dotnet test
```

### Run tests on different browsers: Browser env

```
$env:BROWSER="firefox"
dotnet test
```

## Debugging Tests

```
$env:PWDEBUG=1
dotnet test
```

## [Trace viewer](https://playwright.dev/dotnet/docs/trace-viewer)

```
 PowerShell bin/Debug/net8.0/playwright.ps1 show-trace .\bin\Debug\net8.0\playwright-traces\<projeto>.<nome_arquivo_test>.<nome_do_test>.zip
```

Ex: PowerShell bin/Debug/net8.0/playwright.ps1 show-trace .\bin\Debug\net8.0\playwright-traces\PlaywrightE2E.NUnitPlaywright2.LoginTestRecordAsync.zip

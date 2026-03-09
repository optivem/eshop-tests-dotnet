# System Test Configuration
# This file contains configuration values for Run-SystemTests.ps1

$Config = @{

    BuildCommands = @(
        @{  Name = "Clean Build";
            Command = "dotnet clean; dotnet build"
        }
    )

    Suites = @(

        # === v1: Raw ===
        @{  Id = "v1-smoke";
            Name = "v1 (raw) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V1.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v1-e2e";
            Name = "v1 (raw) - E2E (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V1.E2eTests' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # === v2: Clients ===
        @{  Id = "v2-smoke";
            Name = "v2 (clients) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V2.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v2-e2e";
            Name = "v2 (clients) - E2E (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V2.E2eTests' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # === v3: Drivers ===
        @{  Id = "v3-smoke";
            Name = "v3 (drivers) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V3.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v3-e2e";
            Name = "v3 (drivers) - E2E (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V3.E2eTests' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # === v4: Channels ===
        @{  Id = "v4-smoke";
            Name = "v4 (channels) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V4.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v4-e2e-api";
            Name = "v4 (channels) - E2E (real) - API";
            Command = "dotnet test --filter 'FullyQualifiedName~.V4.E2eTests' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v4-e2e-ui";
            Name = "v4 (channels) - E2E (real) - UI";
            Command = "dotnet test --filter 'FullyQualifiedName~.V4.E2eTests' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # === v5: App DSL ===
        @{  Id = "v5-smoke";
            Name = "v5 (app dsl) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V5.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v5-e2e-api";
            Name = "v5 (app dsl) - E2E (real) - API";
            Command = "dotnet test --filter 'FullyQualifiedName~.V5.E2eTests' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v5-e2e-ui";
            Name = "v5 (app dsl) - E2E (real) - UI";
            Command = "dotnet test --filter 'FullyQualifiedName~.V5.E2eTests' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # === v6: Scenario DSL ===
        @{  Id = "v6-smoke";
            Name = "v6 (scenario dsl) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V6.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v6-e2e-api";
            Name = "v6 (scenario dsl) - E2E (real) - API";
            Command = "dotnet test --filter 'FullyQualifiedName~.V6.E2eTests' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v6-e2e-ui";
            Name = "v6 (scenario dsl) - E2E (real) - UI";
            Command = "dotnet test --filter 'FullyQualifiedName~.V6.E2eTests' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # === v7: Scenario DSL (full) ===
        @{  Id = "v7-smoke-stub";
            Name = "v7 (scenario dsl) - Smoke (stub)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.SmokeTests' -e EXTERNAL_SYSTEM_MODE=stub --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v7-smoke-real";
            Name = "v7 (scenario dsl) - Smoke (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v7-acceptance-api";
            Name = "v7 (scenario dsl) - Acceptance (stub) - API";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.AcceptanceTests&Category!=isolated' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v7-acceptance-ui";
            Name = "v7 (scenario dsl) - Acceptance (stub) - UI";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.AcceptanceTests&Category!=isolated' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v7-acceptance-isolated-api";
            Name = "v7 (scenario dsl) - Acceptance Isolated (stub) - API";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.AcceptanceTests&Category=isolated' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v7-acceptance-isolated-ui";
            Name = "v7 (scenario dsl) - Acceptance Isolated (stub) - UI";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.AcceptanceTests&Category=isolated' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "v7-contract-stub";
            Name = "v7 (scenario dsl) - Contract (stub)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.ExternalSystemContractTests&FullyQualifiedName~Stub' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v7-contract-real";
            Name = "v7 (scenario dsl) - Contract (real)";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.ExternalSystemContractTests&FullyQualifiedName~Real' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v7-e2e-api";
            Name = "v7 (scenario dsl) - E2E (real) - API";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.E2eTests' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "v7-e2e-ui";
            Name = "v7 (scenario dsl) - E2E (real) - UI";
            Command = "dotnet test --filter 'FullyQualifiedName~.V7.E2eTests' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; }

    )
}

# Export the configuration
return $Config

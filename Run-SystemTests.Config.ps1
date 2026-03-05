# System Test Configuration
# This file contains configuration values for Run-SystemTests.ps1

$Config = @{

    BuildCommands = @(
        @{  Name = "Clean Build";
            Command = "dotnet clean; dotnet build"
        }
    )

    Tests = @(

        # Smoke Tests
        @{  Id = "smoke-stub";
            Name = "Smoke Tests - Stubbed External Systems";
            Command = "dotnet test --filter 'FullyQualifiedName~SmokeTests' -e EXTERNAL_SYSTEM_MODE=stub --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html"
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "smoke-real";
            Name = "Smoke Tests - Real External Systems";
            Command = "dotnet test --filter 'FullyQualifiedName~SmokeTests' -e EXTERNAL_SYSTEM_MODE=real --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html"
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # Acceptance Tests
        @{  Id = "acceptance-api";
            Name = "Acceptance Tests - Channel: API";
            Command = "dotnet test --filter 'FullyQualifiedName~AcceptanceTests&Category!=isolated' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "acceptance-ui";
            Name = "Acceptance Tests - Channel: UI";
            Command = "dotnet test --filter 'FullyQualifiedName~AcceptanceTests&Category!=isolated' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # Acceptance Tests (Isolated)
        @{  Id = "acceptance-isolated-api";
            Name = "Acceptance Tests (Isolated) - Channel: API";
            Command = "dotnet test --filter 'FullyQualifiedName~AcceptanceTests&Category=isolated' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html" },
        @{  Id = "acceptance-isolated-ui";
            Name = "Acceptance Tests (Isolated) - Channel: UI";
            Command = "dotnet test --filter 'FullyQualifiedName~AcceptanceTests&Category=isolated' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # External System Contract Tests
        @{  Id = "contract-stub";
            Name = "Contract Tests - Stubbed External Systems";
            Command = "dotnet test --filter 'FullyQualifiedName~ExternalSystemContractTests&FullyQualifiedName~Stub' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "contract-real";
            Name = "Contract Tests - Real External Systems";
            Command = "dotnet test --filter 'FullyQualifiedName~ExternalSystemContractTests&FullyQualifiedName~Real' --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },

        # E2E Tests
        @{  Id = "e2e-no-channel";
            Name = "E2E Tests - No Channel (v1, v2, v3)";
            Command = 'dotnet test --filter "FullyQualifiedName~E2eTests&(FullyQualifiedName~.V1.|FullyQualifiedName~.V2.|FullyQualifiedName~.V3.)" --logger ''trx;LogFileName=testResults-noChannel.trx'' --logger ''html;LogFileName=testResults-noChannel.html'' --logger ''console;verbosity=detailed'' -e ENVIRONMENT=local';
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults-noChannel.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "e2e-api";
            Name = "E2E Tests - Channel: API";
            Command = "dotnet test --filter 'FullyQualifiedName~E2eTests' -e CHANNEL=API --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; },
        @{  Id = "e2e-ui";
            Name = "E2E Tests - Channel: UI";
            Command = "dotnet test --filter 'FullyQualifiedName~E2eTests' -e CHANNEL=UI --logger 'trx;LogFileName=testResults.trx' --logger 'html;LogFileName=testResults.html' --logger 'console;verbosity=detailed' -e ENVIRONMENT=local";
            Path = "SystemTests";
            TestReportPath = "SystemTests\TestResults\testResults.html";
            TestInstallCommands = "pwsh bin/Debug/net8.0/playwright.ps1 install"; }

    )
}

# Export the configuration
return $Config

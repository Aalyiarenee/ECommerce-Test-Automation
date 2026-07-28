# E-Commerce Test Automation Framework

[![Playwright Tests](https://github.com/Aalyiarenee/ECommerce-Test-Automation/actions/workflows/playwright-tests.yml/badge.svg)](https://github.com/Aalyiarenee/ECommerce-Test-Automation/actions/workflows/playwright-tests.yml)

An automated end-to-end testing framework for an e-commerce web application built with **C#, .NET, Microsoft Playwright, and NUnit**. The project demonstrates automated functional testing, negative testing, Page Object Model design, and continuous integration through GitHub Actions.

## 🛠️ Technologies Used

- C#
- .NET
- Microsoft Playwright
- NUnit
- Git
- GitHub
- GitHub Actions
- Visual Studio Code

## 🧪 Automated Test Coverage

The current automated test suite contains **6 end-to-end tests** covering core e-commerce functionality, including:

- Successful user login
- Invalid login/error handling
- Product inventory interactions
- Adding products to the shopping cart
- Shopping cart validation
- Checkout workflow

All tests currently pass locally and are automatically executed through GitHub Actions.

## 🏗️ Project Structure

The framework uses the **Page Object Model (POM)** design pattern to separate page interactions from test logic.

```text
ECommerce-Test-Automation/
│
├── .github/
│   └── workflows/
│       └── playwright-tests.yml
│
├── EcommerceTests/
│   ├── Pages/
│   │   ├── CartPage.cs
│   │   ├── CheckoutPage.cs
│   │   ├── InventoryPage.cs
│   │   └── LoginPage.cs
│   │
│   ├── Tests/
│   │   ├── CartTests.cs
│   │   ├── CheckoutTests.cs
│   │   └── LoginTests.cs
│   │
│   └── EcommerceTests.csproj
│
├── .gitignore
├── LICENSE
└── README.md
```

## 🚀 Continuous Integration

GitHub Actions is configured to automatically run the automated test suite whenever code is pushed to the `main` branch or a pull request is opened against `main`.

The CI workflow:

1. Checks out the repository
2. Configures the .NET environment
3. Restores project dependencies
4. Builds the test project
5. Installs Playwright browser dependencies
6. Executes the automated test suite

This helps verify that changes continue to build successfully and pass the regression suite.

## ▶️ Running the Tests Locally

### Prerequisites

- .NET SDK
- Git
- PowerShell
- Playwright browser dependencies

Clone the repository:

```bash
git clone https://github.com/Aalyiarenee/ECommerce-Test-Automation.git
cd ECommerce-Test-Automation/EcommerceTests
```

Restore dependencies:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Install Playwright browsers:

```bash
pwsh bin/Debug/net10.0/playwright.ps1 install
```

Run the automated test suite:

```bash
dotnet test
```

## 🎯 Project Goals

This project was created to strengthen practical software engineering and test automation skills by applying concepts including:

- Object-oriented programming with C#
- Automated browser testing
- Test design and validation
- Page Object Model architecture
- Source control with Git and GitHub
- Continuous integration with GitHub Actions
- Building maintainable automated test suites

## 📈 Future Improvements

Planned enhancements include:

- Additional regression test scenarios
- Cross-browser testing
- Test reporting
- Screenshots and diagnostic artifacts for failed tests
- Expanded checkout and validation scenarios

## 👩🏽‍💻 Author

**Aalyia Castle**

Computer Science – Software Engineering student focused on building practical experience in software development, automated testing, and modern development workflows.
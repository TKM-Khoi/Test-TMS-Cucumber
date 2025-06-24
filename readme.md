# 📘 Reqnroll BDD Automation Project (C#)

This project demonstrates a **Behavior-Driven Development (BDD)** test automation framework using **Reqnroll** (SpecFlow-compatible), **Selenium WebDriver**, and **ExtentReports**. It’s structured cleanly with separation of concerns, applying Page Object Model (POM) and layered architecture.

---

## 📁 Folder & File Structure Explanation

```
.
├── Core
│   ├── Drivers
│   │   └── BrowserFactory.cs             # Manages browser instances
│   ├── Element
│   │   ├── WebObject.cs                  # Wrapper for IWebElement abstraction
│   │   └── WebObjectExtension.cs         # Extension methods for interacting with WebObject
│   ├── Reports
│   │   └── ExtentReportHelper.cs         # Sets up and manages ExtentReports
│   ├── Utils
│   │   ├── ConfigurationUtils.cs         # Handles appsettings.json reading
│   │   ├── DriverUtils.cs                # General-purpose driver utilities
│   │   ├── FilePathExtension.cs          # Path utilities for test files
│   │   └── JsonFileUtils.cs              # Utilities for JSON operations
│   └── Core.csproj                        # Project definition for Core utilities
│
├── Service
│   ├── Const
│   │   └── FileConst.cs                  # File-related constants
│   ├── DTOs
│   │   ├── CreateProjectDto.cs           # Data model for project creation inputs
│   │   └── LoginDto.cs                   # Data model for login inputs
│   └── Service.csproj                    # Project definition for Service layer
│
├── Test
│   ├── Configurations
│   │   ├── appsettings.json              # General configuration
│   │   └── ExtentReportConfig.xml        # Extent report XML (customizable)
│   ├── Const
│   │   ├── MessageConst.cs               # Message-related constants
│   │   └── PathConst.cs                  # Reusable test path constants
│   ├── Extensions
│   │   ├── ReportContextExtension.cs     # Extent report helper extension
│   │   └── WebComponentExtensions.cs     # Custom WebComponent helpers
│   ├── Features
│   │   ├── CreateProject.feature         # BDD scenario for creating a project
│   │   ├── Login.feature                 # BDD scenario for login flow
│   │   └── SearchProject.feature         # BDD scenario for project search
│   ├── PageObjects
│   │   ├── SearchPages
│   │   │   ├── BaseSearchPage.cs         # Base class for search-related pages
│   │   │   └── SearchProjectPage.cs      # Page for project search UI
│   │   ├── BaseLoginedPage.cs            # Common elements after login
│   │   ├── CreateProjectPopup.cs         # Popup page for creating projects
│   │   ├── LoginPage.cs                  # Login form interactions
│   │   └── ProjectDetailPage.cs          # Project detail UI interactions
│   ├── StepDefinitions
│   │   ├── CreateProjectStepDefinitions.cs
│   │   ├── LoginStepDefinitions.cs
│   │   ├── SearchProjectStepDefinitions.cs
│   │   └── Hooks.cs                      # Reqnroll hooks: before/after test
│   ├── WebComponents
│   │   └── CalendarWebObject.cs          # Custom calendar control component
│   ├── Test.csproj                        # Project file for test suite
│
└── TranKhaiMinhKhoi-PracticeCucumber.sln # Visual Studio solution file
```

---

## ✅ Work Completed

### 🔧 Implemented Features:
- Automated scenarios for login, search, and project creation
- Page Object Model (POM) pattern applied
- DTO binding from Gherkin DataTables
- Centralized reusable components
- Parallel Execution on Feature level

---

## ⚠️ Known Issues & Workarounds

### 1.Error: Extent Report XML config deserialization failed
  
`<extentreports xmlns=''> was not expected.`  
**Cause**: Mismatched XML schema or version.

**Resolution**:  
Used the [official sample XML config from ExtentReports GitHub repo](https://github.com/extent-framework/extentreports-csharp/blob/master/config/spark-config.xml) to resolve schema mismatch and enable config loading.

---

### 2.Issue:  DataTable newline (`\n`) not rendering properly
 
DataTable cells containing `\n` do not display new lines in the report/table view.

**Workaround**:  
Split multi-line values manually in code when iterating rows

---

### 3.Issue: Incorrect Display of Step Text in Report
Step text sometimes displays with unexpected casing or formatting.

**Status**:  
Still unresolved. Possibly caused by report rendering logic or test runner quirks.

---

## 🚀 How to Run

### 1. Clone the repository (if you are authorized)
```bash
git clone https://gitlab.com/anhtien1306/rookies-batch8.git
git checkout TranKhaiMinhKhoi-practice-ui-cucumber
cd <your-folder>
```

### 2. Install dependencies & build
```bash
dotnet restore
dotnet build
```

### 3. Execute Tests
```bash
dotnet test
```

---

## 🔖 Tag Filtering

Run only tests with specific tag:
```bash
dotnet test --filter "Category=login"
dotnet test --filter "Category=search"
dotnet test --filter "Category=createProject"
```

---

## 🧵 Parallel Execution

Enable **feature-level parallelization** in `Hooks.cs`:
```csharp
[assembly: Parallelizable(ParallelScope.Fixtures)]
```

---

## 🔗 Useful References

- 🔹 [Reqnroll Docs](https://reqnroll.net/)
- 🔹 [ExtentReports GitHub](https://github.com/extent-framework/extentreports-csharp)
- 🔹 [Selenium WebDriver C# Guide](https://www.selenium.dev/documentation/webdriver/)
- 🔹 [FluentAssertions](https://fluentassertions.com/)
- 🔹 [Run tests by tag](https://reqnroll.net/docs/v3/gherkin/filtering/)
- 🔹 [Parallel test execution](https://reqnroll.net/docs/v3/gherkin/parallel-execution/)

---

## 🙋 Author

**Tran Khai Minh Khoi**  
This repo is a practice BDD web automation project combining ReqnRoll, Selenium and ExtentReporter.

---

Thank you for your time, effort and feedback!

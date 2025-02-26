## About The Project

<b>Xping TestLogger</b> is a custom test logger designed to integrate with the Visual Studio Test Platform (VSTest) and other compatible test frameworks.
<br />
Its primary purpose is to log test events and upload test results to the xping.io server for archiving and storage purposes. This allows for comprehensive analysis, historical data maintenance, and comparison of test results over time.

<!-- FEATURES -->
## Features
- Test Event Logging: Captures and logs various test events such as test discovery, test execution, and test results.
- Integration with VSTest: Seamlessly integrates with the Visual Studio Test Platform and other compatible test frameworks.
- Uploads test results to the xping.io server for archiving and storage, enabling detailed analysis and historical comparison.
- Easily configurable via runsettings file or environment variables.

<!-- GETTING STARTED -->
## Getting Started
<b>Prerequisites</b>
- .NET 9 SDK
- Visual Studio 2022 or later

### Installation
1. Clone the repository:
```
   git clone https://github.com/xping-dev/test-logger.git
   cd test-logger
```
2. Build the solution:
```
  dotnet build 
```
<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONFIGURATION -->
## Configuration
1. Create a `.runsettings` file to configure the custom logger:
```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <TargetPlatform>x64</TargetPlatform>
  <LoggerRunSettings>
    <Loggers>
      <Logger friendlyName="xping" uri="logger://xping/v1" enabled="True">
        <Configuration>
          <UploadToken>{D4E5F6A7-B8C9-4D0E-8F1A-2B3C4D5E6F7A}</UploadToken>
        </Configuration>
      </Logger>
    </Loggers>
  </LoggerRunSettings>
</RunSettings>
```
2. Specify the runsettings file when running tests:
```
   dotnet test --settings path/to/your/test.runsettings
```
<p align="right">(<a href="#top">back to top</a>)</p>

<!-- USAGE -->
## Usage
1. Add the Xping.TestLogger project as a reference to your test project.
2. Configure the logger using the runsettings file as shown above.
3. Run your tests using the dotnet test command with the --settings option.
<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` file for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

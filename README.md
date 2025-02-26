<div id="top"></div>

[![NuGet](https://img.shields.io/nuget/v/Xping.Sdk)](https://www.nuget.org/profiles/Xping)
![Build Status](https://github.com/xping-dev/sdk-dotnet/actions/workflows/ci.yml/badge.svg)
[![codecov](https://codecov.io/gh/xping-dev/sdk-dotnet/graph/badge.svg?token=VUOVI3YUTO)](https://codecov.io/gh/xping-dev/sdk-dotnet)

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <img src="docs/docs/media/logo.svg" />
  <h2 align="center">Xping TestLogger</h3>
  <p align="center">
    <b>Xping TestLogger</b> is a free and open-source .NET library written in C#. It is a custom test logger designed to integrate with the Visual Studio Test Platform (VSTest) and other compatible test frameworks
    <br />
    <br />
    <a href="https://github.com/xping-dev/test-logger/issues">Report Bug</a>
    ·
    <a href="https://github.com/xping-dev/test-logger/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-project">About The Project</a></li>
    <li><a href="#features">Features</a>
    <li><a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#configuration">Configuration</a></li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details> 


<!-- ABOUT THE PROJECT -->
## About The Project

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

<!-- ROADMAP -->
## Roadmap

We use [Milestones](https://github.com/xping-dev/sdk-dotnet/milestones) to communicate upcoming changes in <b>Xping</b> SDK:

- [Working Set](https://github.com/xping-dev/sdk-dotnet/milestone/1) refers to the features that are currently being actively worked on. While not all of these features will be committed in the next release, they do reflect the top priorities of the maintainers for the upcoming period.

- [Backlog](https://github.com/xping-dev/sdk-dotnet/milestone/2) is a set of feature candidates for some future releases, but are not being actively worked on.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` file for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

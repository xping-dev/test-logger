/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Xping.TestLogger.Converters;
using Xping.TestLogger.Core;
using Xping.TestLogger.Core.Models;

using ObjectModelTestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;

namespace Xping.TestLogger.Services.Internals;

internal sealed class TestSessionBuilder(TestResultConverter converter) : ITestSessionBuilder
{
    private readonly List<TestResult> _testResults = [];
    private DateTime _startDate;
    private Guid _uploadToken;
    private int _version = 1;

    ITestSessionBuilder ITestSessionBuilder.WithStartDate(DateTime startDate)
    {
        _startDate = startDate;
        return this;
    }

    ITestSessionBuilder ITestSessionBuilder.WithUploadToken(Guid uploadToken)
    {
        _uploadToken = uploadToken;
        return this;
    }

    ITestSessionBuilder ITestSessionBuilder.WithVersion(int version)
    {
        _version = version;
        return this;
    }

    ITestSessionBuilder ITestSessionBuilder.WithTestResult(ObjectModelTestResult testResult)
    {
        _testResults.Add(converter.ConvertTestResult(testResult));
        return this;
    }

    void ITestSessionBuilder.Reset()
    {
        _testResults.Clear();
        _startDate = DateTime.MinValue;
        _uploadToken = Guid.Empty;
        _version = 1;
    }

    TestSession ITestSessionBuilder.Build()
    {
        return new TestSession
        {
            SessionCreateDate = _startDate,
            UploadToken = _uploadToken,
            Version = _version,
            TestResults = _testResults,
        };
    }
}

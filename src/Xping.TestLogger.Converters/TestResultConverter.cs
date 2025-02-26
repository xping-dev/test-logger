/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using AutoMapper;
using Xping.TestLogger.Core.Models;

using ObjectModelTestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;

namespace Xping.TestLogger.Converters;

/// <summary>
/// Converts test results from the Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult format
/// to the Xping.TestLogger.Core.Models.TestResult format using AutoMapper.
/// </summary>
public class TestResultConverter
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResultConverter"/> class.
    /// </summary>
    /// <param name="mapper">The AutoMapper instance used for mapping.</param>
    public TestResultConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Converts a test result from the ObjectModelTestResult format to the TestResult format.
    /// </summary>
    /// <param name="testResult">The test result to convert.</param>
    /// <returns>The converted test result.</returns>
    public TestResult ConvertTestResult(ObjectModelTestResult testResult)
    {
        return _mapper.Map<TestResult>(testResult);
    }
}

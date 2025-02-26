/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using AutoMapper;
using Xping.TestLogger.Core.Models;

using ObjectModelTestCase = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestCase;
using ObjectModelTestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;

namespace Xping.TestLogger.Converters;

/// <summary>
/// Provides mapping configurations for AutoMapper to map between
/// <see cref="Microsoft.VisualStudio.TestPlatform.ObjectModel.TestCase"/> and <see cref="TestCase"/>,
/// and between <see cref="Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult"/> and <see cref="TestResult"/>.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// Configures the mappings between ObjectModelTestCase and TestCase,
    /// and between ObjectModelTestResult and TestResult.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<ObjectModelTestCase, TestCase>()
            .ForMember(dest => dest.FullyQualifiedName, opt => opt.MapFrom(src => src.FullyQualifiedName))
            .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source))
            .ForMember(dest => dest.CodeFilePath, opt => opt.MapFrom(src => src.CodeFilePath))
            .ForMember(dest => dest.ExecutorUri, opt => opt.MapFrom(src => src.ExecutorUri))
            .ForMember(dest => dest.LineNumber, opt => opt.MapFrom(src => src.LineNumber));

        CreateMap<ObjectModelTestResult, TestResult>()
            .ForMember(dest => dest.TestCase, opt => opt.MapFrom(src => src.TestCase))
            .ForMember(dest => dest.Outcome, opt => opt.MapFrom(src => src.Outcome))
            .ForMember(dest => dest.ErrorMessage, opt => opt.MapFrom(src => src.ErrorMessage))
            .ForMember(dest => dest.ErrorStackTrace, opt => opt.MapFrom(src => src.ErrorStackTrace))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));
    }
}

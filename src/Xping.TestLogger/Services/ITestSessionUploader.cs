/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Net;
using Xping.TestLogger.Core;

namespace Xping.TestLogger.Services;

/// <summary>
/// Interface for uploading test sessions to the xping.io server.
/// </summary>
/// <remarks>
/// The uploaded test session data is utilized to create a comprehensive dashboard, enabling further analysis and 
/// maintaining historical data and comparison.
/// </remarks>
public interface ITestSessionUploader
{
    /// <summary>
    /// Asynchronously uploads a test session to the xping.io server.
    /// </summary>
    /// <param name="testSession">The test session to upload.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous upload operation, containing the HTTP status code of the response.
    /// </returns>
    Task<HttpStatusCode> UploadAsync(TestSession testSession, CancellationToken cancellationToken = default);

    /// <summary>
    /// Synchronously uploads a test session to the xping.io server.
    /// </summary>
    /// <param name="testSession">The test session to upload.</param>
    /// <returns>
    /// The HTTP status code of the response.
    /// </returns>
    HttpStatusCode Upload(TestSession testSession);
}

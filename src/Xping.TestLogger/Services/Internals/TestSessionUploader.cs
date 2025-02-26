/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.Extensions.Options;
using Xping.TestLogger.Configurations;
using Xping.TestLogger.Core;
using Xping.TestLogger.Core.Services;

namespace Xping.TestLogger.Services.Internals;

internal sealed class TestSessionUploader(
    IHttpClientFactory httpClientFactory,
    ITestSessionSerializer serializer,
    IOptions<TestLoggerOptions> options) : ITestSessionUploader
{
    public const string HttpClientName = nameof(TestSessionUploader);

    public HttpStatusCode Upload(TestSession testSession)
    {
        try
        {
            return UploadAsync(testSession).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Xping.io] An error occurred while uploading the test session: {ex.Message}");
            return HttpStatusCode.InternalServerError;
        }
    }

    public async Task<HttpStatusCode> UploadAsync(
        TestSession testSession,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var httpClient = httpClientFactory.CreateClient(name: HttpClientName);
            using var memoryStream = SerializeTestSession(testSession);
            using var form = CreateMultipartFormDataContent(memoryStream);

            var response = await httpClient
                .PostAsync(options.Value.UploadServer, form, cancellationToken)
                .ConfigureAwait(false);

            Console.WriteLine($"[Xping.io] Test session uploaded with status code: {response.StatusCode}");
            return response.StatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Xping.io] An error occurred while uploading the test session: {ex.Message}");
            return HttpStatusCode.InternalServerError;
        }
    }

    private MemoryStream SerializeTestSession(TestSession testSession)
    {
        var memoryStream = new MemoryStream();
        serializer.Serialize(testSession, memoryStream);
        memoryStream.Position = 0; // Reset stream position to the beginning
        
        return memoryStream;
    }

    private static MultipartFormDataContent CreateMultipartFormDataContent(Stream memoryStream)
    {
        var fileContent = new StreamContent(memoryStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

        var form = new MultipartFormDataContent();
        form.Add(fileContent, name: "file", fileName: "test-session.xml");

        return form;
    }
}

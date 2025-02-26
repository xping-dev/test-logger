/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;

namespace Xping.TestLogger.Core.Models
{
    /// <summary>
    /// Represents a test case with details about its source, location, and execution.
    /// </summary>
    [DataContract]
    public sealed class TestCase
    {
        /// <summary>
        /// Gets or sets the file path of the code file containing the test case.
        /// </summary>
        [DataMember]
        public string? CodeFilePath { get; set; }

        /// <summary>
        /// Gets or sets the display name of the test case.
        /// </summary>
        [DataMember]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the URI of the test executor.
        /// </summary>
        [DataMember]
        public Uri? ExecutorUri { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified name of the test case.
        /// </summary>
        [DataMember]
        public string? FullyQualifiedName { get; set; }

        /// <summary>
        /// Gets or sets the line number in the code file where the test case is defined.
        /// </summary>
        [DataMember]
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets or sets the source of the test case.
        /// </summary>
        [DataMember]
        public string? Source { get; set; }
    }
}

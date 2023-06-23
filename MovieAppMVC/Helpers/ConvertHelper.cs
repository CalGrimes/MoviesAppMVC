using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MovieAppMVC.Helpers
{
    public class ConvertHelper
    {
        public static IFormFile ConvertToIFormFile(byte[] fileBytes, string fileName)
        {
            // Create a memory stream from the byte array
            using (var stream = new MemoryStream(fileBytes))
            {
                // Create a custom implementation of IFormFile
                var formFile = new FormFile(stream, 0, fileBytes.Length, null, fileName)
                {
                    ContentType = "application/octet-stream" // Set the content type accordingly
                };

                return formFile;
            }
        }

        private class FormFile : IFormFile
        {
            private readonly Stream _stream;

            public FormFile(Stream stream, long length, long? offset, string name, string fileName)
            {
                _stream = stream ?? throw new ArgumentNullException(nameof(stream));
                Length = length;
                Name = name;
                FileName = fileName;
                ContentDisposition = $"form-data; name={name ?? "\"\""}; filename={fileName ?? "\"\""}";
            }

            public Stream OpenReadStream()
            {
                return _stream;
            }

            public void CopyTo(Stream target)
            {
                _stream.CopyTo(target);
            }

            public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
            {
                return _stream.CopyToAsync(target, 81920, cancellationToken);
            }

            public Task<byte[]> ReadAllBytesAsync(CancellationToken cancellationToken = default)
            {
                using (var ms = new MemoryStream())
                {
                    _stream.CopyTo(ms);
                    return Task.FromResult(ms.ToArray());
                }
            }

            // Implement other required members of IFormFile interface

            public string ContentType { get; set; }
            public string ContentDisposition { get; }
            public IHeaderDictionary Headers { get; } = new HeaderDictionary();
            public long Length { get; }
            public string Name { get; }
            public string FileName { get; }
        }
    }
}

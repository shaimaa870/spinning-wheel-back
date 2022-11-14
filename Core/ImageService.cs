using Microsoft.AspNetCore.Hosting;
namespace spinning_wheel.Core
{
    public class ImageService : IImage
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
      

        public ImageService( Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
   
        }

        public async Task<string> SaveImageAsync(string name, string dtoFile)
        {
            try
            {
                if (IsBase64String(dtoFile, out var file))
                {
                    var bytes = Convert.FromBase64String(file);
                    if (string.IsNullOrWhiteSpace(_env.WebRootPath))
                    {
                        _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }
                    string path = Path.Combine(_env.WebRootPath, "image");
                    CreateFolders(path);
                    var imageUrl = Path.Combine(path, name);
                    if (File.Exists(imageUrl))
                    {
                            File.Delete(imageUrl);
                      
                      }
                    await File.WriteAllBytesAsync(imageUrl, bytes);

                    return name;
                }
                throw new Exception();
            }

            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool IsBase64String(string base64, out string imageString)
        {
            if (base64.Contains(','))
            {
                base64 = base64.Split(',')[1];
            }
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            imageString = base64;
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);

        }
        private void CreateFolders(string foldersPath)
        {
            var exists = Directory.Exists(foldersPath);
            if (!exists)
                Directory.CreateDirectory(foldersPath);
        }
    }
}

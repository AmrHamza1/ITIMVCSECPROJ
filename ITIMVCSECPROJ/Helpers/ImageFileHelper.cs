namespace ITIMVCSECPROJ.Helpers
{
    public static class ImageFileHelper
    {
        public static string imageUpload(IFormFile image,string folderName)
        {
            if(image == null)
            {
                return $"/{folderName}/default.png";
            }
            else
            {
                string WWWRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                if(!Directory.Exists(WWWRootPath))
                {
                    Directory.CreateDirectory(WWWRootPath);
                }
                string imageName = $"{Guid.NewGuid().ToString()}-{image.FileName}";
                string imagePath = Path.Combine(WWWRootPath, imageName);
                using(var filestream = new FileStream(imagePath,FileMode.Create))
                {
                    image.CopyTo(filestream);
                }
                return $"/{folderName}/{imageName}";
            }
        }
    }
}

namespace BookWormProject.Utils.Helper
{
    public static class FileHelper
    {
        public static bool IsImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            string extension = Path.GetExtension(fileName).ToLower();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                    return true;
                default:
                    return false;
            }
        }

        public static void SaveImage(Stream stream, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                stream.CopyTo(fileStream);
            }
        }
    }

}

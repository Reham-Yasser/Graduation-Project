namespace Edu_Chatbot.Helper
{
    public class DocumentSeeting
    {






           
        public static string UploadeFile(IFormFile file, string FolderName)
        {



            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);
            //var imagePath = Path.Combine("wwwroot", "files", "images", "filename.jpg");
            var FileName = $"{Guid.NewGuid()}{file.FileName}";

            var filePath = Path.Combine(FolderPath, FileName);
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return $"https://localhost:7127/files/{FolderName}{FileName}";


       

        }
    }
}

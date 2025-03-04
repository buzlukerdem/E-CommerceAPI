//using E_Commerce.Infrastructure.Operations;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;

//namespace E_Commerce.Infrastructure.Services
//{
//    public class FileService
//    {
//        readonly IWebHostEnvironment _webHostEnvironment;
//        public FileService(IWebHostEnvironment webHostEnvironment)
//        {
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public async Task<bool> CopyFileAsync(string path, IFormFile file)
//        {
//            try
//            {
//                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
//                await file.CopyToAsync(fileStream);
//                await fileStream.FlushAsync();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw ex;

//            }
//        }
//        public async Task<string> FileRenameAsync(string path, string fileName)
//        {
//            return await Task.Run<string>(() =>
//            {
//                string oldName = Path.GetFileNameWithoutExtension(fileName);
//                string extension = Path.GetExtension(fileName);
//                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
//                bool fileIsExists = false;
//                int fileIndex = 1;


//                if (File.Exists($"{path}\\{newFileName}"))
//                {
//                    fileIsExists = true;
//                    newFileName = $"{oldName}" + "-" + $"{++fileIndex}" + $"{extension} ";
//                }
//                else
//                {
//                    fileIsExists = false;
//                }


//                return newFileName;
//            });

//        }

//        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
//        {
//            // upload edilecek path
//            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

//            // check path if there is no path then create.
//            if (!Directory.Exists(uploadPath))
//                Directory.CreateDirectory(uploadPath);

//            List<(string fileName, string path)> datas = new();
//            List<bool> results = new();

//            foreach (IFormFile file in files)
//            {
//                string newFileName = await FileRenameAsync(uploadPath, file.FileName);
//                //await CopyFileAsync(Path.Combine(uploadPath, newFileName), file);
//                bool fileResult = await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
//                datas.Add((newFileName, $"{path}\\{newFileName}"));
//                results.Add(fileResult);
//            }

//            if (results.TrueForAll(r => r.Equals(true)))
//                return datas;

//            return datas;
//        }
//    }
//}

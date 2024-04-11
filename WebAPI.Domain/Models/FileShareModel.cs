using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Models
{
    public class FileShareModel
    {
        public bool IsSuccess { get; set; } = false;
        public string FileName { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
        public string DataBase64 { get; set; } = string.Empty;

        public FileShareModel()
        {

        }

        public FileShareModel(string fileName, string fileExtension, Stream streamFile)
        {
            if (GuardClauses.ObjectIsNotNull(streamFile))
            {
                IsSuccess = true;
                FileName = fileName;
                FileExtension = fileExtension;
                DataBase64 = GetBase64FromStream(streamFile);
            }
        }

        private string GetBase64FromStream(Stream streamFile)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                streamFile.CopyTo(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}

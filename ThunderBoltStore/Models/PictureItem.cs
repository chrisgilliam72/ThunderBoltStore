using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ThunderBoltStore.Models
{
    public class PictureItem
    {
        public byte[] Picture { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        public String ImageType { get; set; } = "jpeg";


        public async Task UpdatePictureArray()
        {
            if (ImageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memoryStream);
                    Picture = memoryStream.ToArray();
                    ImageType = ImageFile.ContentType;
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThunderBoltStore.ViewModels
{
    public class ImageUpload
    {
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
    }
}

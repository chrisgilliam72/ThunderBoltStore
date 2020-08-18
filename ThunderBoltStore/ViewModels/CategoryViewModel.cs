using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThunderBoltStore.Models;

namespace ThunderBoltStore.ViewModels
{
    //this is a test for github
    /// <summary>
    /// dsdksdjks
    /// </summary>
    public class CategoryViewModel
    {
        public Category CategoryItem { get; set; }
        
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        public CategoryViewModel()
        {
        }
    }
}

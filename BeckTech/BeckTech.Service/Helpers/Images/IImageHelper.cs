﻿using BechTech.Entity.DTO.Images;
using BechTech.Entity.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);

    }
}
using Microsoft.AspNetCore.Http;
using EbtakrAlmanalntro.Models.ImageViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro.Helper
{
    public interface IUploadImage
    {
        string Upload(IFormFile Photo, int FileName);
        Tuple<List<string>, string> ListResizeImage(List<IFormFile> Photos, int FileName);
        List<string> UploadListImages(List<IFormFile> Photos, int FileName);
        List<ResizeImagesViewModel> NewUploadBaseAndResizeImages(List<IFormFile> Photos, int FileName);

        Task<List<ResizeImagesViewModel>> NewUploadBaseAndResizeImages_WithWaterMark(List<IFormFile> Photos, int FileName, string BranchName = "");

    }
}

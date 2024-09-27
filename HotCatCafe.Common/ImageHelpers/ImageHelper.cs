using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotCatCafe.Common.ImageHelpers
{
    public static class ImageHelper
    {

        public static string Upload(string imageName)
        {
            string newImageName = "";

            string uniqueName = Guid.NewGuid().ToString();

            var fileArray = imageName.Split('.');

            var extension = fileArray[fileArray.Length - 1]; 

            if (extension == "png" || extension == "jpg" || extension == "bmp" || extension == "gif" || extension == "jpeg"|| extension == "jfif" || extension == "webp")
            {
                newImageName = uniqueName + "." + extension;
                return newImageName;
            }
            else
            {
                return "0";
            }
        }
    }
}

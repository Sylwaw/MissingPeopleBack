using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace MissingPeople.Core.Extensions
{
    public static class ImageExtension
    {
     
        /// <summary>
        /// Convert image to base64
        /// </summary>
        /// <param name="image">Object image</param>
        /// <returns></returns>
        public static string ImageToBase64(this System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            string base64String = $"data:image/jpeg;base64,{Convert.ToBase64String(ms.ToArray())}";
            return base64String;
        }

        /// <summary>
        /// Convert image to byte array
        /// </summary>
        /// <param name="image">Image object</param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(this System.Drawing.Image image)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }   
    }
}
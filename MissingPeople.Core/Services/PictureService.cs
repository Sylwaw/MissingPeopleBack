using System.Drawing;
using System.Threading.Tasks;
using MissingPeople.Core.Extensions;
using MissingPeople.Core.Interfaces;

namespace MissingPeople.Core.Services
{

    public class PictureService : IPictureService
    {
        public string GetPictureBase64ByName(string name)
        {
            var picture = Image.FromFile($"c:\\{name}.jpg");
            return picture.ImageToBase64();
        }

    }
}
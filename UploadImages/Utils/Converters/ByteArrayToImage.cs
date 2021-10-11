using System.Drawing;
using System.IO;

namespace UploadImages.Utils.Converters
{
    public class ByteArrayToImage 
    {
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}

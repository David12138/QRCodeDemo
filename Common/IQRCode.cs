using System.Drawing;

namespace QRcodeAPP.Common
{
    public interface IQRCode
    {
        Bitmap GetQRCode(string url, int pixel);
    }
}
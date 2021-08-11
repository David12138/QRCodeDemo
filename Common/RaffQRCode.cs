using Microsoft.AspNetCore.Hosting;
using QRCoder;
using System.Drawing;
using System.IO;

namespace QRcodeAPP.Common
{
    public class RaffQRCode : IQRCode
    {
        #region 依赖注入
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public RaffQRCode(IWebHostEnvironment iWebHostEnvironment)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
        } 
        #endregion

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="url">连接内容</param>
        /// <param name="pixel">像素大小</param>
        /// <returns></returns>
        public Bitmap GetQRCode(string url, int pixel)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(url, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);

            #region 无图标
            //Bitmap qrImage = qrcode.GetGraphic(pixel, Color.Black, Color.White, true);
            #endregion

            #region 有图标
            string webRootPath = _iWebHostEnvironment.WebRootPath;//访问到wwwroot静态文件层
            //string contentRootPath = _iWebHostEnvironment.ContentRootPath;//访问到根目录层

            Bitmap icon = new Bitmap(Path.Combine(webRootPath, "img/icon.png"));//获取图标
            Bitmap qrImage = qrcode.GetGraphic(pixel, Color.Black, Color.White, icon, 15, 6, true);
            #endregion

            return qrImage;
        }
    }
}
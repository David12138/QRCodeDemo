using Microsoft.AspNetCore.Mvc;
using QRcodeAPP.Common;
using System;
using System.Drawing.Imaging;
using System.IO;

namespace QRcodeAPP.Controllers
{
    public class MainController : Controller
    {
        #region 依赖注入
        private IQRCode _iQRCode;

        public MainController(IQRCode iQRCode)
        {
            _iQRCode = iQRCode;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="url">url链接内容</param>
        /// <param name="pixel">像素</param>
        [HttpGet("/api/qrcode")]
        public void GetQRCode(string url, int pixel)
        {

            Response.ContentType = "image/jpeg";

            var bitmap = _iQRCode.GetQRCode(url, pixel);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);

            Response.Body.WriteAsync(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            Response.Body.Close();
        }
        #endregion
    }
}
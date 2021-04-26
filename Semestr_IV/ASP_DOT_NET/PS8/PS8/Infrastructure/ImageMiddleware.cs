using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace PS8.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ImageMiddleware
    {
        private readonly RequestDelegate _next;

        public ImageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string url = httpContext.Request.Path;
            if (url.ToLower().Contains(".jpg"))
            {
                Image img;
                MemoryStream stream;
                try
                {
                    img = Image.FromFile("./img" + url);
                    
                }
                catch
                {
                    img = Image.FromFile("./img/error.png");
                    stream = new MemoryStream();
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    httpContext.Response.ContentType = "image/jpeg";
                    return httpContext.Response.Body.WriteAsync(stream.ToArray(), 0, (int)stream.Length);
                }
                Image watermark = Image.FromFile("./img/watermark.png");
                Graphics imageGraphics = Graphics.FromImage(img);
                stream = new MemoryStream();
                using (TextureBrush watermarkBrush = new TextureBrush(watermark))
                {
                    int x = (img.Width / 2 - watermark.Width / 2);
                    int y = (img.Height / 2 - watermark.Height / 2);
                    watermarkBrush.TranslateTransform(x, y);
                    imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermark.Width + 1, watermark.Height)));
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }
                httpContext.Response.ContentType = "image/jpeg";
                return httpContext.Response.Body.WriteAsync(stream.ToArray(), 0, (int)stream.Length);
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ImageMiddlewareExtensions
    {
        public static IApplicationBuilder UseImageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImageMiddleware>();
        }
    }
}

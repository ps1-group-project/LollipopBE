using System;
using System.Drawing;
using System.IO;


namespace Lollipop.Application.Helpers
{
    public static class Base64StringHelper
    {
        public static string ToBase64String(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);

                    return base64String;
                }
            }
        }
    }
}

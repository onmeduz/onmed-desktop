using System.IO;
using System;

namespace OnMed.Desktop.Halpers;

public class ImageNameMarker
{
    public static string GetImageName(string filepath)
    {
        FileInfo fileInfo = new FileInfo(filepath);
        return "IMG_" + Guid.NewGuid().ToString() + fileInfo.Extension;
    }
}

﻿#nullable enable
using System;
using System.Drawing;
using System.IO;

namespace MAME_Shrink.Extensions;
internal class ImageHelper
{
    public static Image ConvertStreamToImage(Stream stream)
    {
        if (stream is null)
            throw new ArgumentNullException(nameof(stream));

        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        memoryStream.Position = 0;
        return Image.FromStream(memoryStream);
    }
}

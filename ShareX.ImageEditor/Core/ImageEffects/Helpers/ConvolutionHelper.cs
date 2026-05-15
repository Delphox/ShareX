#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2026 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using SkiaSharp;

namespace ShareX.ImageEditor.Core.ImageEffects.Helpers;

internal static class ConvolutionHelper
{
    public static SKBitmap Apply3x3(
        SKBitmap source,
        float[] kernel,
        float gain = 1f,
        float bias = 0f,
        bool convolveAlpha = false,
        SKShaderTileMode tileMode = SKShaderTileMode.Clamp)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (kernel is null) throw new ArgumentNullException(nameof(kernel));
        if (kernel.Length != 9) throw new ArgumentException("Kernel must contain 9 values for a 3x3 convolution.", nameof(kernel));

        using SKImageFilter filter = SKImageFilter.CreateMatrixConvolution(
            new SKSizeI(3, 3),
            kernel,
            gain,
            bias,
            new SKPointI(1, 1),
            tileMode,
            convolveAlpha);

        using SKPaint paint = new SKPaint { ImageFilter = filter };

        SKBitmap result = new SKBitmap(source.Width, source.Height, source.ColorType, source.AlphaType);
        using SKCanvas canvas = new SKCanvas(result);
        canvas.DrawBitmap(source, 0, 0, paint);

        return result;
    }
}
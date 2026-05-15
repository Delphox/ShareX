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

namespace ShareX.ImageEditor.Core.Annotations;

/// <summary>
/// Groups annotation types by functional category, mirroring <see cref="ImageEffects.ImageEffectCategory"/>.
/// Each concrete <see cref="Annotation"/> subclass returns its category via the <see cref="Annotation.Category"/> property.
/// </summary>
public enum AnnotationCategory
{
    /// <summary>Geometric shapes: Arrow, Ellipse, Freehand, Image, Line, Rectangle, Crop, CutOut, SmartEraser.</summary>
    Shapes,

    /// <summary>Pixel-level effects applied to a region: Blur, Highlight, Magnify, Pixelate, Spotlight.</summary>
    Effects,

    /// <summary>Text-based overlays: Number, SpeechBalloon, Text.</summary>
    Text
}
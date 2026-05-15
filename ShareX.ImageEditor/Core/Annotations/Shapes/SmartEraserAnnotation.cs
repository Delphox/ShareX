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
/// Smart Eraser annotation - samples pixel color from the rendered canvas (including other annotations)
/// at click point and uses it for drawing to hide sensitive information by covering it with the
/// sampled color from the visual output
/// </summary>
public class SmartEraserAnnotation : RectangleAnnotation
{
    public SmartEraserAnnotation()
    {
        ToolType = EditorTool.SmartEraser;
        // Default to a visible preview color until the canvas sample is available.
        StrokeColor = "#80FF0000";
        FillColor = "#80FF0000";
        StrokeWidth = 0;
        CornerRadius = 0;
        ShadowEnabled = false;
    }

    // StrokeColor/FillColor will be set to the sampled pixel color from the RENDERED canvas
    // (including all annotations) when the user first clicks with the Smart Eraser tool.
    // This allows users to cover sensitive information with colors that match
    // existing annotations or the background, effectively hiding it seamlessly.
}
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

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ShareX.ImageEditor.Core.Annotations;

namespace ShareX.ImageEditor.Presentation.Controls
{
    /// <summary>
    /// Selection shell for spotlight annotations.
    /// The actual darkening overlay is rendered once by SpotlightOverlayControl.
    /// </summary>
    public class SpotlightControl : Control
    {

        public static readonly StyledProperty<SpotlightAnnotation?> AnnotationProperty =
            AvaloniaProperty.Register<SpotlightControl, SpotlightAnnotation?>(nameof(Annotation));

        public SpotlightAnnotation? Annotation
        {
            get => GetValue(AnnotationProperty);
            set => SetValue(AnnotationProperty, value);
        }

        static SpotlightControl()
        {
            AffectsRender<SpotlightControl>(AnnotationProperty);
        }

        public SpotlightControl()
        {
            // Make this control take up the full canvas space
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);
        }
    }
}
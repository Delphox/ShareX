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
using Avalonia.Markup.Xaml;

namespace ShareX.ImageEditor.Presentation.Controls
{
    public partial class StrengthSlider : UserControl
    {
        public static readonly StyledProperty<float> SelectedStrengthProperty =
            AvaloniaProperty.Register<StrengthSlider, float>(
                nameof(SelectedStrength),
                defaultValue: 10);

        public static readonly StyledProperty<float> MinimumProperty =
            AvaloniaProperty.Register<StrengthSlider, float>(
                nameof(Minimum),
                defaultValue: 1);

        public static readonly StyledProperty<float> MaximumProperty =
            AvaloniaProperty.Register<StrengthSlider, float>(
                nameof(Maximum),
                defaultValue: 30);

        public float SelectedStrength
        {
            get => GetValue(SelectedStrengthProperty);
            set => SetValue(SelectedStrengthProperty, value);
        }

        public float Minimum
        {
            get => GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public float Maximum
        {
            get => GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public event EventHandler<float>? StrengthChanged;

        static StrengthSlider()
        {
            SelectedStrengthProperty.Changed.AddClassHandler<StrengthSlider>((s, e) =>
            {
                float roundedStrength = MathF.Round(s.SelectedStrength);

                if (Math.Abs(s.SelectedStrength - roundedStrength) > float.Epsilon)
                {
                    s.SelectedStrength = roundedStrength;
                    return;
                }

                s.StrengthChanged?.Invoke(s, roundedStrength);
            });
        }

        public StrengthSlider()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
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
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ShareX.ImageEditor.Presentation.Controls
{
    public partial class CornerRadiusPickerDropdown : UserControl
    {
        public static readonly StyledProperty<int> SelectedCornerRadiusProperty =
            AvaloniaProperty.Register<CornerRadiusPickerDropdown, int>(
                nameof(SelectedCornerRadius),
                defaultValue: 4);

        public static readonly StyledProperty<IEnumerable<int>> CornerRadiusOptionsProperty =
            AvaloniaProperty.Register<CornerRadiusPickerDropdown, IEnumerable<int>>(
                nameof(CornerRadiusOptions),
                defaultValue: GetDefaultCornerRadiusOptions());

        public int SelectedCornerRadius
        {
            get => GetValue(SelectedCornerRadiusProperty);
            set => SetValue(SelectedCornerRadiusProperty, value);
        }

        public IEnumerable<int> CornerRadiusOptions
        {
            get => GetValue(CornerRadiusOptionsProperty);
            set => SetValue(CornerRadiusOptionsProperty, value);
        }

        public event EventHandler<int>? CornerRadiusChanged;

        public CornerRadiusPickerDropdown()
        {
            AvaloniaXamlLoader.Load(this);

            var popup = this.FindControl<Popup>("CornerRadiusPopup");
            if (popup != null)
            {
                popup.Opened += OnPopupOpened;
            }
        }

        private void OnPopupOpened(object? sender, EventArgs e)
        {
            UpdateActiveStates();
        }

        private void UpdateActiveStates()
        {
            var popup = this.FindControl<Popup>("CornerRadiusPopup");
            if (popup?.Child is Border border && border.Child is ItemsControl itemsControl)
            {
                foreach (var item in itemsControl.GetRealizedContainers())
                {
                    if (item is ContentPresenter presenter && presenter.Child is Button button)
                    {
                        if (button.CommandParameter is int radius && radius == SelectedCornerRadius)
                        {
                            button.Classes.Add("active");
                        }
                        else
                        {
                            button.Classes.Remove("active");
                        }
                    }
                }
            }
        }

        private void OnDropdownButtonClick(object? sender, RoutedEventArgs e)
        {
            var popup = this.FindControl<Popup>("CornerRadiusPopup");
            if (popup != null)
            {
                popup.IsOpen = !popup.IsOpen;
            }
        }

        private void OnCornerRadiusSelected(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int selectedRadius)
            {
                SelectedCornerRadius = selectedRadius;
                CornerRadiusChanged?.Invoke(this, selectedRadius);
                UpdateActiveStates();

                var popup = this.FindControl<Popup>("CornerRadiusPopup");
                if (popup != null)
                {
                    popup.IsOpen = false;
                }
            }
        }

        private static IEnumerable<int> GetDefaultCornerRadiusOptions()
        {
            return new List<int> { 0, 2, 4, 6, 8, 10, 15, 20, 25, 30 };
        }
    }
}
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
    public partial class WidthPickerDropdown : UserControl
    {
        public static readonly StyledProperty<int> SelectedWidthProperty =
            AvaloniaProperty.Register<WidthPickerDropdown, int>(
                nameof(SelectedWidth),
                defaultValue: 4);

        public static readonly StyledProperty<IEnumerable<int>> WidthOptionsProperty =
            AvaloniaProperty.Register<WidthPickerDropdown, IEnumerable<int>>(
                nameof(WidthOptions),
                defaultValue: GetDefaultWidthOptions());

        public int SelectedWidth
        {
            get => GetValue(SelectedWidthProperty);
            set => SetValue(SelectedWidthProperty, value);
        }

        public IEnumerable<int> WidthOptions
        {
            get => GetValue(WidthOptionsProperty);
            set => SetValue(WidthOptionsProperty, value);
        }

        public event EventHandler<int>? WidthChanged;

        public WidthPickerDropdown()
        {
            AvaloniaXamlLoader.Load(this);

            var popup = this.FindControl<Popup>("WidthPopup");
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
            var popup = this.FindControl<Popup>("WidthPopup");
            if (popup?.Child is Border border && border.Child is ItemsControl itemsControl)
            {
                foreach (var item in itemsControl.GetRealizedContainers())
                {
                    if (item is ContentPresenter presenter && presenter.Child is Button button)
                    {
                        if (button.CommandParameter is int width && width == SelectedWidth)
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
            var popup = this.FindControl<Popup>("WidthPopup");
            if (popup != null)
            {
                popup.IsOpen = !popup.IsOpen;
            }
        }

        private void OnWidthSelected(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int selectedWidth)
            {
                SelectedWidth = selectedWidth;
                WidthChanged?.Invoke(this, selectedWidth);

                // Update active states before closing
                UpdateActiveStates();

                // Close the popup
                var popup = this.FindControl<Popup>("WidthPopup");
                if (popup != null)
                {
                    popup.IsOpen = false;
                }
            }
        }

        private static IEnumerable<int> GetDefaultWidthOptions()
        {
            return new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        }
    }
}
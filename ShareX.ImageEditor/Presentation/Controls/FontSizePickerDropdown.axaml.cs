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
    public partial class FontSizePickerDropdown : UserControl
    {
        public static readonly StyledProperty<float> SelectedFontSizeProperty =
            AvaloniaProperty.Register<FontSizePickerDropdown, float>(
                nameof(SelectedFontSize),
                defaultValue: 30);

        public static readonly StyledProperty<IEnumerable<float>> FontSizeOptionsProperty =
            AvaloniaProperty.Register<FontSizePickerDropdown, IEnumerable<float>>(
                nameof(FontSizeOptions),
                defaultValue: GetDefaultFontSizes());

        public float SelectedFontSize
        {
            get => GetValue(SelectedFontSizeProperty);
            set => SetValue(SelectedFontSizeProperty, value);
        }

        public IEnumerable<float> FontSizeOptions
        {
            get => GetValue(FontSizeOptionsProperty);
            set => SetValue(FontSizeOptionsProperty, value);
        }

        public event EventHandler<float>? FontSizeChanged;

        public FontSizePickerDropdown()
        {
            AvaloniaXamlLoader.Load(this);

            var popup = this.FindControl<Popup>("FontSizePopup");
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
            var popup = this.FindControl<Popup>("FontSizePopup");
            if (popup?.Child is Border border && border.Child is ItemsControl itemsControl)
            {
                foreach (var item in itemsControl.GetRealizedContainers())
                {
                    if (item is ContentPresenter presenter && presenter.Child is Button button)
                    {
                        if (button.CommandParameter is float size && size == SelectedFontSize)
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
            var popup = this.FindControl<Popup>("FontSizePopup");
            if (popup != null)
            {
                popup.IsOpen = !popup.IsOpen;
            }
        }

        private void OnFontSizeSelected(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is float selectedSize)
            {
                SelectedFontSize = selectedSize;

                // Defer popup close and event firing to after the current input cycle.
                // Closing the popup synchronously during a Click handler disposes the
                // PopupRoot's native window while PointerReleased is still being dispatched
                // through it, causing "PlatformImpl is null" warnings.
                Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                {
                    var popup = this.FindControl<Popup>("FontSizePopup");
                    if (popup != null)
                    {
                        popup.IsOpen = false;
                    }

                    FontSizeChanged?.Invoke(this, selectedSize);
                }, Avalonia.Threading.DispatcherPriority.Input);
            }
        }

        private static IEnumerable<float> GetDefaultFontSizes()
        {
            return new List<float> { 10, 13, 16, 20, 24, 30, 48, 72, 96, 144, 216, 288 };
        }
    }
}
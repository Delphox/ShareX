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

using ShareX.HelpersLib;
using System.Windows.Forms;

namespace ShareX
{
    public partial class ImageEditorSelectorForm : Form
    {
        public bool UseLegacyImageEditor { get; private set; }

        public ImageEditorSelectorForm()
        {
            InitializeComponent();
            ShareXResources.ApplyTheme(this);
        }

        private void btnModernImageEditor_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            UseLegacyImageEditor = false;
            Close();
        }

        private void btnLegacyImageEditor_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            UseLegacyImageEditor = true;
            Close();
        }
    }
}
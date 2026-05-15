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

using ShareX.ImageEditor.Core.ImageEffects;

namespace ShareX.ImageEditor.Presentation.Effects;

internal static class DiscoveredEffectRegistry
{
    private static readonly Lazy<IReadOnlyList<EffectDefinition>> _definitions = new(BuildDefinitions);

    public static IReadOnlyList<EffectDefinition> Definitions => _definitions.Value;

    private static IReadOnlyList<EffectDefinition> BuildDefinitions()
    {
        List<EffectDefinition> definitions = [];

        foreach (Type type in typeof(ImageEffectBase).Assembly.GetTypes()
                     .Where(type => type is { IsAbstract: false, IsClass: true } && typeof(ImageEffectBase).IsAssignableFrom(type)))
        {
            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                continue;
            }

            if (Activator.CreateInstance(type) is not ImageEffectBase effect)
            {
                continue;
            }

            definitions.Add(DiscoveredEffectPresentationAdapter.CreateDefinition(effect));
        }

        return definitions
            .OrderBy(definition => definition.Category)
            .ThenBy(definition => definition.Name, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }
}
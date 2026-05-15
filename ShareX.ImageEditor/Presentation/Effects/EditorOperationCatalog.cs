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

internal static class EditorOperationCatalog
{
    /// <summary>
    /// Maps effect IDs to their <see cref="EditorOperationKind"/> routing.
    /// Each entry corresponds to an <see cref="ImageEffectBase"/> subclass that is auto-discovered.
    /// </summary>
    private static readonly (string Id, EditorOperationKind Kind)[] _operationMappings =
    [
        ("auto_crop_image", EditorOperationKind.AutoCropImage),
        ("crop_image", EditorOperationKind.CropImage),
        ("resize_image", EditorOperationKind.ResizeImage),
        ("resize_canvas", EditorOperationKind.ResizeCanvas),
        ("rotate_90_clockwise", EditorOperationKind.Rotate90Clockwise),
        ("rotate_90_counter_clockwise", EditorOperationKind.Rotate90CounterClockwise),
        ("rotate_180", EditorOperationKind.Rotate180),
        ("rotate_custom_angle", EditorOperationKind.RotateCustomAngle),
        ("flip_horizontal", EditorOperationKind.FlipHorizontal),
        ("flip_vertical", EditorOperationKind.FlipVertical)
    ];

    private static readonly IReadOnlyList<EditorOperationDefinition> _definitions = BuildDefinitions();

    private static readonly IReadOnlyDictionary<string, EditorOperationDefinition> _definitionsById =
        _definitions.ToDictionary(definition => definition.Id, StringComparer.OrdinalIgnoreCase);

    private static readonly IReadOnlyDictionary<ImageEffectCategory, IReadOnlyList<EditorOperationDefinition>> _definitionsByCategory =
        _definitions
            .GroupBy(definition => definition.Category)
            .ToDictionary(
                group => group.Key,
                group => (IReadOnlyList<EditorOperationDefinition>)group.ToArray());

    public static bool TryGetDefinition(string id, out EditorOperationDefinition? definition)
    {
        return _definitionsById.TryGetValue(id, out definition);
    }

    public static IReadOnlyList<EditorOperationDefinition> GetByCategory(ImageEffectCategory category)
    {
        return _definitionsByCategory.TryGetValue(category, out IReadOnlyList<EditorOperationDefinition>? definitions)
            ? definitions
            : [];
    }

    private static IReadOnlyList<EditorOperationDefinition> BuildDefinitions()
    {
        // Index discovered effects by ID so we can look up metadata.
        var discoveredById = DiscoveredEffectRegistry.Definitions
            .ToDictionary(d => d.Id, StringComparer.OrdinalIgnoreCase);

        var definitions = new List<EditorOperationDefinition>();

        foreach ((string id, EditorOperationKind kind) in _operationMappings)
        {
            if (!discoveredById.TryGetValue(id, out EffectDefinition? effect))
            {
                continue;
            }

            EffectDefinition? schemaDefinition = effect.CoreParameters.Count > 0 ? effect : null;

            definitions.Add(new EditorOperationDefinition(
                effect.Id,
                effect.BrowserLabel,
                effect.Icon,
                effect.Description,
                effect.Category,
                kind,
                schemaDefinition));
        }

        return definitions;
    }
}
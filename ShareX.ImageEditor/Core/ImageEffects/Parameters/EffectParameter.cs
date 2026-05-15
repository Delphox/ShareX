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

using SkiaSharp;

namespace ShareX.ImageEditor.Core.ImageEffects.Parameters;

public abstract class EffectParameter
{
    protected EffectParameter(string key, string label, string? description = null)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Label = label ?? throw new ArgumentNullException(nameof(label));
        Description = description;
    }

    public string Key { get; }

    public string Label { get; }

    public string? Description { get; }

    internal abstract void Apply(ImageEffect effect, object? value);
}

public sealed class SliderEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, double> _applyValue;

    public SliderEffectParameter(
        string key,
        string label,
        double minimum,
        double maximum,
        double defaultValue,
        double tickFrequency,
        bool isSnapToTickEnabled,
        string valueStringFormat,
        Action<ImageEffect, double> applyValue,
        string? description = null)
        : base(key, label, description)
    {
        Minimum = minimum;
        Maximum = maximum;
        DefaultValue = defaultValue;
        TickFrequency = tickFrequency;
        IsSnapToTickEnabled = isSnapToTickEnabled;
        ValueStringFormat = valueStringFormat ?? throw new ArgumentNullException(nameof(valueStringFormat));
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public double Minimum { get; }

    public double Maximum { get; }

    public double DefaultValue { get; }

    public double TickFrequency { get; }

    public bool IsSnapToTickEnabled { get; }

    public string ValueStringFormat { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        _applyValue(effect, value is double numericValue ? numericValue : DefaultValue);
    }
}

public sealed class CheckboxEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, bool> _applyValue;

    public CheckboxEffectParameter(
        string key,
        string label,
        bool defaultValue,
        Action<ImageEffect, bool> applyValue,
        string? description = null)
        : base(key, label, description)
    {
        DefaultValue = defaultValue;
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public bool DefaultValue { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        _applyValue(effect, value is bool booleanValue ? booleanValue : DefaultValue);
    }
}

public sealed class EnumEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, object> _applyValue;

    public EnumEffectParameter(
        string key,
        string label,
        IReadOnlyList<EffectOption> options,
        int defaultIndex,
        Action<ImageEffect, object> applyValue,
        string? description = null)
        : base(key, label, description)
    {
        if (options is null || options.Count == 0)
        {
            throw new ArgumentException("Enum options must not be empty.", nameof(options));
        }

        if (defaultIndex < 0 || defaultIndex >= options.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(defaultIndex));
        }

        Options = options;
        DefaultIndex = defaultIndex;
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public IReadOnlyList<EffectOption> Options { get; }

    public int DefaultIndex { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        _applyValue(effect, value ?? Options[DefaultIndex].Value);
    }
}

public sealed class ColorEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, SKColor> _applyValue;

    public ColorEffectParameter(
        string key,
        string label,
        SKColor defaultValue,
        Action<ImageEffect, SKColor> applyValue,
        string? description = null)
        : base(key, label, description)
    {
        DefaultValue = defaultValue;
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public SKColor DefaultValue { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        _applyValue(effect, value is SKColor colorValue ? colorValue : DefaultValue);
    }
}

public sealed class NumericEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, decimal> _applyValue;

    public NumericEffectParameter(
        string key,
        string label,
        decimal minimum,
        decimal maximum,
        decimal defaultValue,
        decimal increment,
        string formatString,
        Action<ImageEffect, decimal> applyValue,
        string? description = null)
        : base(key, label, description)
    {
        Minimum = minimum;
        Maximum = maximum;
        DefaultValue = defaultValue;
        Increment = increment;
        FormatString = formatString ?? throw new ArgumentNullException(nameof(formatString));
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public decimal Minimum { get; }

    public decimal Maximum { get; }

    public decimal DefaultValue { get; }

    public decimal Increment { get; }

    public string FormatString { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        decimal resolvedValue = value switch
        {
            decimal decimalValue => decimalValue,
            double doubleValue => (decimal)doubleValue,
            int intValue => intValue,
            null => DefaultValue,
            _ => DefaultValue
        };

        _applyValue(effect, resolvedValue);
    }
}

public sealed class TextEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, string> _applyValue;

    public TextEffectParameter(
        string key,
        string label,
        string defaultValue,
        Action<ImageEffect, string> applyValue,
        string? description = null)
        : base(key, label, description)
    {
        DefaultValue = defaultValue ?? throw new ArgumentNullException(nameof(defaultValue));
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public string DefaultValue { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        _applyValue(effect, value as string ?? DefaultValue);
    }
}

public sealed class FilePathEffectParameter : EffectParameter
{
    private readonly Action<ImageEffect, string> _applyValue;

    public FilePathEffectParameter(
        string key,
        string label,
        string defaultValue,
        Action<ImageEffect, string> applyValue,
        string? fileFilter = null,
        string? description = null)
        : base(key, label, description)
    {
        DefaultValue = defaultValue ?? string.Empty;
        FileFilter = fileFilter;
        _applyValue = applyValue ?? throw new ArgumentNullException(nameof(applyValue));
    }

    public string DefaultValue { get; }

    public string? FileFilter { get; }

    internal override void Apply(ImageEffect effect, object? value)
    {
        _applyValue(effect, value as string ?? DefaultValue);
    }
}

public sealed class EffectOption
{
    public EffectOption(string label, object value)
    {
        Label = label ?? throw new ArgumentNullException(nameof(label));
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Label { get; }

    public object Value { get; }
}
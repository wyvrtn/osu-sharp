using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert strings to an enum and vice versa, using the <see cref="DescriptionAttribute"/> to specify the string value.
/// </summary>
internal class StringEnumConverter : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    // Only allow enums to be converted.
    return objectType.IsEnum || (objectType.GetElementType()?.IsEnum ?? false);
  }

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is an array, read each value and convert it to an enum using this converter itself.
    if (reader.TokenType == JsonToken.StartArray)
    {
      List<object?> list = new List<object?>();
      while (reader.Read() && reader.TokenType != JsonToken.EndArray)
        list.Add(ReadJson(reader, objectType.GetElementType()!, existingValue, serializer));

      // Create an array of type objectType, add all the values to it and return it.
      Array array = Array.CreateInstance(objectType.GetElementType()!, list.Count);
      for (int i = 0; i < list.Count; i++)
        array.SetValue(list[i], i);

      return array;
    }
    // If the value is not a string or null, throw an exception.
    else if (reader.TokenType is not JsonToken.String || reader.Value is null)
      throw new JsonSerializationException($"Unable to convert '{reader.Value}' ({reader.TokenType}) into an enum.");

    // Go through all the values of the enum, get the description attribute and check if it matches the value read from the reader.
    foreach (FieldInfo field in objectType.GetFields().Where(x => x.Name != "value__"))
    {
      // Try to find the description attribute. If not found, throw an exception.
      DescriptionAttribute? descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
      if (descriptionAttribute is null)
        throw new JsonSerializationException($"Unable to find a description attribute for the field '{field.Name}'.");

      // Get the value of the description attribute and compare it to the value read from the reader. If it matches, return the enum value.
      if (descriptionAttribute.Description.Equals(reader.Value))
        return field.GetValue(null);
    }

    // Throw an exception if no matching enum value was found.
    throw new JsonSerializationException($"Unable to find a matching enum value for the string '{reader.Value}'.");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    // Get the description attribute. If not found, throw an exception.
    DescriptionAttribute? descriptionAttribute = value?.GetType().GetField(value?.ToString() ?? "")?.GetCustomAttribute<DescriptionAttribute>();
    if (descriptionAttribute is null)
      throw new JsonSerializationException($"Unable to find a description attribute for the enum value '{value}'.");

    // Write the description attribute value to the writer.
    writer.WriteValue(descriptionAttribute.Description);
  }
}
using System.Text.Json.Serialization;

namespace Funcio.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TurnoEnum
{
    Manhã,Tarde,Noite
}
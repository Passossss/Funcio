using System.Text.Json.Serialization;

namespace Funcio.Enums;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartamentoEnum
{
    RH,
    Financeiro,
    Compras,
    TI,
    Atendimento,
    Zeladoria
}
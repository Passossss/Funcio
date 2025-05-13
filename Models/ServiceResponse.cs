using System.Reflection.Metadata.Ecma335;

namespace Funcio.Models;

public class ServiceResponse<T>
{
    public T? Dados { get; set;}
    public string Mensagem { get; set; }
    public bool Sucesso { get; set; }
}
using Funcio.Models;
using NuGet.Protocol;

namespace Funcio.Service.FuncionarioService;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
    Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
    Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
    Task<ServiceResponse<List<FuncionarioModel>>>UpdateFuncionario(FuncionarioModel editadoFuncionario);
    Task<ServiceResponse<List<FuncionarioModel>>>DeleteFuncionario(int id);
    Task<ServiceResponse<List<FuncionarioModel>>>InativarFuncionario(int id);
}
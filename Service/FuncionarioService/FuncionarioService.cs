using Funcio.DataContext;
using Funcio.Models;

namespace Funcio.Service.FuncionarioService;

public class FuncionarioService : IFuncionarioInterface
{
    private readonly ApplicationDbContext _context;
    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            serviceResponse.Dados = _context.Funcionarios.ToList();

            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            if (novoFuncionario == null)
            {
                serviceResponse.Mensagem = "Informar dados!";
                serviceResponse.Sucesso = false;
                serviceResponse.Dados = null;
                return serviceResponse;
            }
            _context.Add(novoFuncionario);
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Funcionarios.ToList();
            serviceResponse.Mensagem = "Funcionário criado com sucesso!";
            serviceResponse.Sucesso = true;
            
        }
        catch (Exception ex)
        {
            
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionario(int id)
    {
        throw new NotImplementedException();
    }
}
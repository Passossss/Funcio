using Funcio.DataContext;
using Funcio.Models;
using Microsoft.EntityFrameworkCore;

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
        }
        catch (Exception ex)
        {

            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário não encontrado!";
                serviceResponse.Sucesso = false;
            }

            serviceResponse.Dados = funcionario;
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
{
    ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
    try
    {
        FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);
        
        if (funcionario == null)
        {  
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = "Usuário não encontrado!";
            serviceResponse.Sucesso = false;
        }

        funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
        
        serviceResponse.Dados = _context.Funcionarios.ToList();
    }
    catch (Exception ex)
    {
        serviceResponse.Mensagem = ex.Message;
        serviceResponse.Sucesso = false;
    }
    return serviceResponse;
}

    public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            
            if (funcionario == null)
            {  
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário não encontrado!";
                serviceResponse.Sucesso = false;
                
                return serviceResponse;
            }
            
            _context.Funcionarios.Remove(funcionario); //delete
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

    public async Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "";
                serviceResponse.Sucesso = false;
            }
            funcionario.Ativo = false;
            funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

            _context.Funcionarios.Update(funcionario); //com data ja atualizada
            await _context.SaveChangesAsync();
            
            serviceResponse.Dados = _context.Funcionarios.ToList();

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
        
    }
}
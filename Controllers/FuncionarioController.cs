using Funcio.Models;
using Funcio.Service.FuncionarioService;
using Microsoft.AspNetCore.Mvc;

namespace Funcio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface; //service
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>>UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);;
            return Ok(serviceResponse);
        }
        
        [HttpDelete]
        
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>>Delete(int id)
        {
            ServiceResponse<List<FuncionarioModel>> ServiceResponse = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(ServiceResponse);

        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>>GetFuncionarios()
        {
            return Ok( await _funcionarioInterface.GetFuncionarios() );
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>>GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse =  await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(serviceResponse);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>>CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }
        [HttpPut("InativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativarFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativarFuncionario(id);
            return Ok(serviceResponse);
        }
        /*[HttpDelete]
        public ActionResult Dell()
        {
            return Ok("Delete Ok");
        }*/
    }
}

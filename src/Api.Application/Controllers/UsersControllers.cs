using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Interfaces.Services.User;
using System;
using System.Net;
using Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Controllers
{
    // http://localhost:5000/api/users
    [Produces("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly IUserInterface _user;

        public UsersController(IUserInterface user)
        {
            _user = user;
        }

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/users
        ///
        /// </remarks>
        /// <returns>Retorna todos os registros quando há sucesso</returns>
        /// <response code="200">Retorna todos os registros quando há sucesso</response>
        /// <response code="400">Erro no parâmetro</response>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _user.GetAll());
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna um usuário específico pelo id
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/users/3fa85f64-5717-4562-b3fc-2c963f66afa6
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna o registro selecionado quando há sucesso</returns>
        /// <response code="200">Retorna o registro selecionado quando há sucesso</response>
        /// <response code="400">Erro no parâmetro</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _user.Get(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Insere um usuário específico
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/users
        ///     {
        ///         "name": "Fulano de Tal",
        ///         "email": "fulano@gmail.com"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns>Retorna o registro inserido quando há sucesso</returns>
        /// <response code="200">Retorna o registro inserido quando há sucesso</response>
        /// <response code="400">Erro no parâmetro</response>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _user.Post(user));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um usuário específico pelo id
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/users
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "name": "Fulano de Tal",
        ///         "email": "fulano@gmail.com"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns>Retorna o registro alterado quando há sucesso</returns>
        /// <response code="200">Retorna o registro alterado quando há sucesso</response>
        /// <response code="400">Erro no parâmetro</response>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _user.Put(user));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Apaga um usuário específico pelo id
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/users
        ///     {
        ///        "id": "cd8d0c76-565e-4d83-8a9a-43020ca2616d"
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna true para remoção com sucesso</returns>
        /// <response code="200">Retorna true para remoção com sucesso</response>
        /// <response code="400">Erro no parâmetro</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([Required] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _user.Delete(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
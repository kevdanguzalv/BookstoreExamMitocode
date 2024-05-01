﻿using Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace ApisEvaluacionIFinalFullStack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController :  ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClientesService service;
        public ClientesController(ILogger<ClientesController> logger,IClientesService service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await service.GetAsync();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        
        public async Task<IActionResult> Post(ClientesRequestDto genreRequestDto)
        {
            var response = await service.AddAsync(genreRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        
        public async Task<IActionResult> Put(int id, ClientesRequestDto genreRequestDto)
        {
            var response = await service.UpdateAsync(id, genreRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}

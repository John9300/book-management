﻿using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Entitis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService) 
        { 
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var result = _bookService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            var result = _bookService.GetById(id);
            
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookAddModel model)
        {
            _bookService.Add(model);

            return Ok();
        }
        
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);
            if (_response != null)
                return Ok(_response);
            else
                return NotFound();
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-data-by-id/{id}")]
        public IActionResult DeletePublisherData(int id)
        {
            try
            {
                _publishersService.DeletePublisherData(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

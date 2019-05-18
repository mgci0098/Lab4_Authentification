using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Services;
using Lab3.ViewModels;
using Laborator2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }


        /// <summary>
        /// Gets comments filtered.
        /// </summary>
        /// <param name="filter"> string to filter</param>
        /// <returns>A list of Comment comments.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GET: api/?filter = 5
        [HttpGet("{filter}", Name = "Get")]
        [HttpGet]
        public IEnumerable<CommentGetModel> GetFiltered([FromQuery]string filter)
        {
            return commentService.GetAllFiltered(filter);
        }



    }
}
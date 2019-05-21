using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Services;
using Lab3.ViewModels;
using Laborator2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laborator2.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ObiectiveController : ControllerBase
    {

        //private ObiectiveDbContext context;
        private IObiectivService obiectivService;

        public ObiectiveController(IObiectivService obiectivService)
        {
            this.obiectivService = obiectivService;
        }

        /// <summary>
        /// Gets all the obiectives.
        /// </summary>
        /// <param name="from">Optional, filter by minimum Deadline</param>
        /// <param name="to">Optional, filter by maximum Deadline</param>
        /// <returns>A list of Obiectiv objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public PaginatedList<ObiectivGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to, [FromQuery]int page = 1)
        {
            // TODO: make pagination work with /api/flowers/page/<page number>
            page = Math.Max(page, 1);
            return obiectivService.GetAll(from, to, page);
        }

        /// <summary>
        /// Add a obiectiv
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /obiective
        ///     {
        ///         "title": "Lab2WithComments",
        ///         "description": "Lab2",
        ///         "added": "0001-01-01T00:00:00",
        ///         "deadline": "0001-01-01T00:00:00",
        ///         "importanta": 1,
        ///         "starea": 1,
        ///         "closedAt": "0001-01-01T00:00:00",
        ///         "comments": [
        ///              {
        ///                    "text": "Comenteriu 1",
        ///                    "important": false
        ///              },
        ///              {
        ///                    "text": "Comentariu 2",
        ///                    "important": true
        ///              }
        ///         ]
        ///     }
        /// </remarks>
        /// <param name="obiectiv">The obiectiv to add.</param>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        [HttpPost]
        public void Post([FromBody] ObiectivPostModel obiectiv)
        {
            //if (!ModelState.IsValid)
            //{
            //}
            obiectivService.Create(obiectiv);
        }

        /// <summary>
        /// Update an obiectiv if exists, or add if not.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /obiective/id
        ///     {
        ///         "title": "Update",
        ///         "description": "Lab2",
        ///         "added": "0001-01-01T00:00:00",
        ///         "deadline": "0001-01-01T00:00:00",
        ///         "importanta": 1,
        ///         "starea": 1,
        ///         "closedAt": "0001-01-01T00:00:00",
        ///         "comments": [
        ///              {
        ///                    "text": "Comenteriu 1",
        ///                    "important": false
        ///              }              
        ///         ]
        ///     }
        /// </remarks>
        /// <param name="id">The id of the obiectiv to update</param>
        /// <param name="obiectiv">The new value of the obiectiv</param>
        /// <returns>The updated obiectiv</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT: api/Obiective/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ObiectivPostModel obiectiv)
        {
            var result = obiectivService.Upsert(id, obiectiv);
            return Ok(result);
        }


        /// <summary>
        /// Dalete an obiectiv by the id.
        /// </summary>
        /// <param name="id">The id to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // DELETE: api/Obiective/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = obiectivService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}
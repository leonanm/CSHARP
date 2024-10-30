using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Repositories;
using System.Collections.Generic;

namespace ProjetoFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: api/publishers
        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> GetPublishers()
        {
            return Ok(_publisherRepository.GetAllPublishers());
        }

        // GET: api/publishers/{id}
        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        // POST: api/publishers
        [HttpPost]
        public ActionResult<Publisher> AddPublisher(Publisher publisher)
        {
            _publisherRepository.AddPublisher(publisher);
            return CreatedAtAction(nameof(GetPublisher), new { id = publisher.Id }, publisher);
        }

        // PUT: api/publishers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePublisher(int id, Publisher publisher)
        {
            if (id != publisher.Id)
                return BadRequest();

            _publisherRepository.UpdatePublisher(publisher);
            return NoContent();
        }

        // DELETE: api/publishers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePublisher(int id)
        {
            _publisherRepository.DeletePublisher(id);
            return NoContent();
        }
    }
}

using Cards.Domain.Models;
using Cards.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public CardController(IUnitOfWork db)
        {
            _db = db;
        }

        /// <summary>
        /// Get All Card Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Card))]
        public IActionResult GetAllCardsDetails()
        {
            IEnumerable<Card> objCardList = _db.Card.GetAll();
            return Ok(objCardList);
        }


        /// <summary>
        /// Get Individual Card Details
        /// </summary>
        /// <param name="id">Card Id[Guid]</param>
        /// <returns></returns>
        [HttpGet("{id:Guid}", Name = "GetCardDetail")]
        [ProducesResponseType(200, Type = typeof(Card))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetCardDetail(Guid id)
        {
            var obj = _db.Card.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        /// <summary>
        /// Create New Card 
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Card))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCard([FromBody] Card card)
        {
            if (card == null)
            {
                return BadRequest(ModelState);
            }
            if (_db.Card.CardExists(card.CardHolderName))
            {
                ModelState.AddModelError("", "Card Holder Name Already Exists");
                return StatusCode(404, ModelState);
            }
            if (ModelState.IsValid)
            {
                _db.Card.Add(card);
                _db.Save();
            }
            else
            {
                ModelState.AddModelError("", "Something went worng while creating data");
                return StatusCode(500, ModelState);
            }
            return Ok(card);
        }


        /// <summary>
        /// Update Card Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPut("{id:Guid}", Name = "UpdateCard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCard(Guid id, [FromBody] Card card)
        {
            if (card == null || id != card.Id)
            {
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                _db.Card.Update(card);
                _db.Save();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete Card 
        /// </summary>
        /// <param name="id">Card Id[Guid]</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}", Name = "DeleteCard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCard(Guid id)
        {
            if (!_db.Card.CardExists(id))
            {
                return NotFound();
            }
            var obj = _db.Card.GetFirstOrDefault(x => x.Id == id);
            _db.Card.Remove(obj);
            _db.Save();
            return NoContent();
        }
    }
}

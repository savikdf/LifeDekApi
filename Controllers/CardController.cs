using LifeDekApi.Services.Interfaces;
using LifeDekApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using LifeDekApi.Services;

namespace LifeDekApi.Controllers;

[ApiController]
[Route("cards")] //[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService cardService;

    public CardController()
    {
        cardService = new CardService();   
    }

    //public CardController() : this(new CardService()) { }

    //public CardController(ICardService cardService)
    //{
    //    this.cardService = cardService;
    //}

    //GET /cards/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CardDto>> GetCard(Guid id)
    {
        try
        {
            CardDto card = cardService.GetCard(id);
            if (card is null)
            {
                return NotFound();
            }
            return Ok(card);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"GetCard() of CardController thew an error: {ex.Message}");
        }
    }

    //GET /cards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CardDto>>> GetCards()
    {
        try
        {
            IEnumerable<CardDto> cards = cardService.GetCards();
            if (cards is null)
            {
                return NotFound();
            }
            return Ok(cards);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"GetCards() of CardController thew an error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CardDto>> CreateCard(CardDto request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("A Card must have a name.");
            }

            CardDto createdCard = cardService.CreateCard(request);
            return Ok(createdCard);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"CreateCard() of CardController thew an error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult<CardDto>> UpdateCard(CardDto request)
    {
        try
        {
            CardDto updatedCard = cardService.UpdateCard(request);
            if (updatedCard == null)
            {
                return BadRequest("Updates were unable to be made for this request.");
            }
            return Ok(updatedCard);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"UpdateCard() of CardController thew an error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CardDto>> DeleteCard(Guid id)
    {
        try
        {
            CardDto deletedCard = cardService.DeleteCard(id);
            if (deletedCard == null)
            {
                return BadRequest("No Card found to delete with that Id.");
            }
            return Ok(deletedCard);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"DeleteCard() of CardController thew an error: {ex.Message}");
        }
    }

}

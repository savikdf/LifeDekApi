using LifeDekApi.Services.Interfaces;
using LifeDekApi.Models;
using Microsoft.AspNetCore.Mvc;
using LifeDekApi.Services;

namespace LifeDekApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService cardService;

    public CardController() : this(new CardService()){}
    public CardController(ICardService cardService)
    {
        this.cardService = cardService;
    }

    [HttpGet("{id}")]
    public ActionResult<Card> GetCard(Guid id){
        try{
            Card card = cardService.GetCard(id);
            if(card is null){
                return NotFound();
            }
            return Ok(card);

        }catch(Exception ex){
            throw new ApplicationException($"GetCard() of CardController thew an error: {ex.Message}");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Card>> GetCards(){
        try{
            IEnumerable<Card> cards = cardService.GetCards();
            if(cards is null){
                return NotFound();
            }
            return Ok(cards);

        }catch(Exception ex){ 
            throw new ApplicationException($"GetCards() of CardController thew an error: {ex.Message}");
        }
    }


}

using Microsoft.AspNetCore.Mvc;
using WarAndPeace.Application.Interface;

namespace WarAndPeace.API.Controllers
{
    [ApiController]
    //TODO Controller level routing pattern 
    public class WordsController : ControllerBase
    {
        private readonly IBookReaderService _bookReaderService;

        public WordsController(IBookReaderService bookReaderService)
        {
            _bookReaderService = bookReaderService;
        }

        [HttpGet("api/words")]
        public IActionResult GetWords()
        {
            return Ok(_bookReaderService.GetWords());
        }

        [HttpGet("api/words/top/{numberOfWords}")]
        public IActionResult GetTopXWords(int numberOfWords)
        {
            return Ok(_bookReaderService.GetTopXUsedWords(numberOfWords));
        }

        [HttpGet("api/words/top/{numberOfWords}/longerThan/{minLengthOfWords}")]
        public IActionResult GetTopXWordsLongerThanYLength(int numberOfWords, int minLengthOfWords)
        {
            return Ok(_bookReaderService.GetTopXUsedWordsLongerThanYChars(numberOfWords, minLengthOfWords));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WarAndPeace.Application.Interface;

namespace WarAndPeace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        private readonly IBookReaderService _bookReaderService;

        public WordsController(IBookReaderService bookReaderService)
        {
            _bookReaderService = bookReaderService;
        }

        [HttpGet("/all")]
        public IActionResult GetWords()
        {
            return Ok(_bookReaderService.GetWords());
        }

        [HttpGet("/top/{numberOfWords}")]
        public IActionResult GetTopXWords(int numberOfWords)
        {
            return Ok(_bookReaderService.GetTopXUsedWords(numberOfWords));
        }

        [HttpGet("/top/{numberOfWords}/longerThan/{minLengthOfWords}")]
        public IActionResult GetTopXWordsLongerThanYLength(int numberOfWords, int minLengthOfWords)
        {
            return Ok(_bookReaderService.GetTopXUsedWordsLongerThanYChars(numberOfWords, minLengthOfWords));
        }
    }
}

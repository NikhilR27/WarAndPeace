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

        //TODO
        // This method is not part of the requirement - pagination will need to be implemented for this method to work because the dataset is too large for the browser
        //[HttpGet("/all")]
        //public IActionResult GetWords()
        //{
        //    return Ok(_bookReaderService.GetWords());
        //}

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

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class QuotesController : ControllerBase
{
    // any quotes :)
    private List<Quote> _quotes = new List<Quote>
    {
        new Quote { QuoteID = 1, QuoteText = "Life is what happens when you're busy making other plans.", Category = "Life", Author = "John Lennon", BookName = "Unknown" },
        new Quote { QuoteID = 2, QuoteText = "The greatest glory in living lies not in never falling, but in rising every time we fall.", Category = "Motivation", Author = "Nelson Mandela", BookName = "Long Walk to Freedom" },
        new Quote { QuoteID = 3, QuoteText = "The purpose of our lives is to be happy.", Category = "Life", Author = "Dalai Lama", BookName = "The Art of Happiness" },
        new Quote { QuoteID = 4, QuoteText = "The purpose of our lives .", Category = "Life", Author = "Dalai Lama", BookName = "The Art" },
        new Quote { QuoteID = 5, QuoteText = "from the river to the sea Palestine will be free.", Category = "Gaza", Author = "SOMAYA MOHAMED", BookName = "EL-SENWAR" },
        new Quote { QuoteID = 6, QuoteText = "The purpose of our lives is to be happy.", Category = "Life", Author = "Dalai Lama", BookName = " Happiness" },
        new Quote { QuoteID = 7, QuoteText = "you're busy making other plans.", Category = "busy", Author = "John Lennon", BookName = "Unknown" },
        new Quote { QuoteID = 8, QuoteText = "Life is what happens.", Category = "Happy", Author = "John Lennon", BookName = "Unknown" },
        new Quote { QuoteID = 9, QuoteText = "The purpose of our lives is to be happy.", Category = "Life", Author = "Dalai Lama", BookName = " Happiness" },
        new Quote { QuoteID = 10, QuoteText = "from the river to the sea Palestine will be free.", Category = "Gaza", Author = "SOMAYA MOHAMED", BookName = "Palestine" },
    };

    [HttpGet("GetQuotes")]
    public IActionResult GetQuotes(string? category = null, string? author = null, string? bookname = null, string? search = null, int pageNumber = 1, int pageSize = 10)
    {
        //  Filtering :)
        var quotes = _quotes.AsQueryable();

        if (!string.IsNullOrEmpty(category))
            quotes = quotes.Where(q => q.Category == category);

        if (!string.IsNullOrEmpty(author))
            quotes = quotes.Where(q => q.Author == author);

        if (!string.IsNullOrEmpty(bookname))
            quotes = quotes.Where(q => q.BookName == bookname);

        //  Searching :)
        if (!string.IsNullOrEmpty(search))
            quotes = quotes.Where(q => q.QuoteText.Contains(search) || q.BookName.Contains(search) || q.Author.Contains(search) || q.Category.Contains(search));

        //  Pagination :)
        var paginatedQuotes = quotes
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        //return Ok(paginatedQuotes); 
        return new JsonResult(paginatedQuotes);

    }
}

public class Quote
{
    public int QuoteID { get; set; }
    public string? QuoteText { get; set; }
    public string? Category { get; set; }
    public string? Author { get; set; }
    public string? BookName { get; set; }
}





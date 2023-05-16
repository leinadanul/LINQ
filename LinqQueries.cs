public class LinqQueries
{
    private List<Book> bookCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        
        {
            string json = reader.ReadToEnd();
            this.bookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});

        }

    }
    public IEnumerable<Book> allCollection()
    {
        return bookCollection;
    }

    public IEnumerable<Book> BookAfter2000()
    {   // extension method 
        //return bookCollection.Where(p=> p.publishedDate.Year > 2000);

        return from l in bookCollection where l.publishedDate.Year > 2007 select l;
    }

    public IEnumerable<Book> bookMore250PagesAndWordsWithActtion()
    {
        // extension method 
        //return bookCollection.Where(p => p.PageCount > 250 && p.Title.Contains ("in Action"));


        //Query expression
        return from l in bookCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool allBooksWithStatus()
    {
        return bookCollection.All(p => p.Status != string.Empty);
    }

    public bool anyBookWasPublishedIn2005()
    {
        return bookCollection.Any( p => p.publishedDate.Year == 2005);
    }

    public IEnumerable<Book> bookThatsConteinTheWordPython()
    {
        return bookCollection
        .Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> bookThatsConteinTheWordJavaWithAscName()
    {
        return bookCollection
        .Where(p => p.Categories.
        Contains("Java")).OrderBy( p => p.Title);
    }

    public IEnumerable<Book> bookMore450PagesOrderByDesc()
    {
        // extension method 
        return bookCollection
        .Where(p => p.PageCount > 450)
        .OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> most3RecentBookInJavaCategory()
    {
        return bookCollection
        .Where(p => p.Categories
        .Contains("Java"))
        .OrderByDescending(p => p.publishedDate)
        .Take(3);
    }

        public IEnumerable<Book> thirAndFourthBookHaveMore400Pages()
    {
        return bookCollection
        .Where(p => p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> threeFirstBookOfCollection()
    {
        return bookCollection.Take(3)
        .Select(p=> new Book() {Title = p.Title, PageCount = p.PageCount});
    }

/*  public int BookCountBetween200And500Pages()
    {
        return bookCollection
        .Where(p => p.PageCount >= 200 && p.PageCount <= 500)
        .Count();
    }
    */

        public long BookCountBetween200And500Pages()
    {
        return bookCollection
        .LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime MostOldestBook()
    {
        return bookCollection.Min(p => p.publishedDate);
    }

    public int MostPagesBook()
    {
        return bookCollection.Max(p => p.PageCount);
    }

    public Book? bookWithFewerPages()
        {
            return bookCollection.Where(p => p.PageCount > 0).MinBy(p=> p.PageCount);
        }
    
    public Book? bookWithMostRecentPublishedDate()
    {
        return bookCollection.MaxBy(p => p.publishedDate);
    }

    public int SumAllPageBetween0And500()
    {
        return bookCollection.Where(p => p.PageCount >=0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

//Aggregate( valorInicialDelAcumulador, (Acumulador, Elemento), Funcion ); 
    public string booksTitleAfert2015()
    {
        return bookCollection
            .Where(p => p.publishedDate.Year >=2015)
            .Aggregate("", (BooksTitle, next)=>
        {
                if(BooksTitle != String.Empty)
                {
                    BooksTitle += " - " +  next.Title;
                }
                else
                {
                    BooksTitle += next.Title;
                }
                return BooksTitle;
        });
    }

    public double CharAverageTitle()
    {
        return bookCollection.Average( p=> p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> BookAfter2000GroupByForYear()
    {
        return bookCollection
        .Where(p=> p.publishedDate.Year >= 2000)
        .GroupBy(p=> p.publishedDate.Year);
    }

    public ILookup<char, Book> DictionaryBooksByChar()
    {
        return bookCollection.ToLookup(p => p.Title[0], p=> p);
    }

    public IEnumerable<Book> BooksAfter2005WithMore500pages()
    {
        var booksAfter2005 = bookCollection.Where(p=> p.publishedDate.Year >2005 );

        var bookWihtMore500Pages = bookCollection.Where(p=> p.PageCount >= 500);

        return booksAfter2005.Join(bookWihtMore500Pages, p => p.Title, x=> x.Title, (p,x)=> p);
    }

}
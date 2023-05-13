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
        return bookCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> bookThatsConteinTheWordJavaWithAscName()
    {
        return bookCollection.Where(p => p.Categories.Contains("Java")).OrderBy( p => p.Title);
    }

    public IEnumerable<Book> bookMore450PagesOrderByDesc()
    {
        // extension method 
        return bookCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);

    }






}
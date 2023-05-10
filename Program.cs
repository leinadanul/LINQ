LinqQueries queries = new LinqQueries();



PrintValues(queries.allCollection());



void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60 } {1,15} {2,15}\n", "Title", "Pages", "Plublished date");
    foreach(var item in bookList)
    {
        Console.WriteLine("{0, -60 } {1,15} {2,15}", item.Title, item.PageCount, item.publishedDate.ToShortDateString());
    }
}
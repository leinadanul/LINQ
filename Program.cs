LinqQueries queries = new LinqQueries();




// print all collection 
//PrintValues(queries.allCollection());

// print book's after 2000s
//PrintValues(queries.BookAfter2000());


// All books have status
//Console.WriteLine($" All books have status? - {queries.allBooksWithStatus()}");


// some book was published in 2005
//Console.WriteLine($" Any book was published in 2005? - {queries.anyBookWasPublishedIn2005()}");

//Python books
//PrintValues(queries.bookThatsConteinTheWordPython());

// print books with more 250 pages and the word "in action "
//PrintValues(queries.bookMore250PagesAndWordsWithActtion());

//Java books order by name 
//PrintValues(queries.bookThatsConteinTheWordJavaWithAscName());

//Books with more 450 pages oreden by descendent 
PrintValues(queries.bookMore450PagesOrderByDesc());

void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60 } {1,15} {2,15}\n", "Title", "Pages", "Plublished date");
    foreach(var item in bookList)
    {
        Console.WriteLine("{0, -60 } {1,15} {2,15}", item.Title, item.PageCount, item.publishedDate.ToShortDateString());
    }
}
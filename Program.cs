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
//PrintValues(queries.bookMore450PagesOrderByDesc());

//print 3 most recent java book
//PrintValues(queries.most3RecentBookInJavaCategory());

// print third and fourth books where have more 400 pages
//PrintValues(queries.thirAndFourthBookHaveMore400Pages());


//three first books filter by select
//PrintValues(queries.threeFirstBookOfCollection());

//Console.WriteLine($"The following books have between 200 and 500 pages {queries.BookCountBetween200And500Pages()}");

// print oldest book in the collection  
//Console.WriteLine($"the followingt book is the most oldest {queries.MostOldestBook()}");


// print the book with most pages of the collection 
//Console.WriteLine($"the following book with most pages  {queries.MostPagesBook()}");


//var bookWithFewerPag = queries.bookWithFewerPages();
//Console.WriteLine($"{bookWithFewerPag.Title} - {bookWithFewerPag.PageCount}");


//var mostRecent = queries.bookWithMostRecentPublishedDate();
//Console.WriteLine($"{mostRecent.Title} - {mostRecent.PageCount} - {mostRecent.publishedDate.ToShortDateString()}");


//Suma total de las paginas 
//Console.WriteLine($"Sum total of pages :{queries.SumAllPageBetween0And500()} ");

// Libros publicados despues del 2015

//Console.WriteLine(queries.booksTitleAfert2015());

// average character in the title of the book 

//Console.WriteLine($"The average title of the book is :{queries.CharAverageTitle()}");

// books published after 2000 group by date
//PrintGroup(queries.BookAfter2000GroupByForYear());

// Dictyonary of books by first letter of title 
//var dictionary = queries.DictionaryBooksByChar();

//printDictionary(dictionary, 's');


//Libros filtrados por join 

PrintValues(queries.BooksAfter2005WithMore500pages());

void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0, -60 } {1,15} {2,15}\n", "Title", "Pages", "Plublished date");
    foreach(var item in bookList)
    {
        Console.WriteLine("{0, -60 } {1,15} {2,15}", item.Title, item.PageCount, item.publishedDate.ToShortDateString());
    }
}

void PrintGroup(IEnumerable<IGrouping<int, Book>> bookList)
{
    foreach(var group in bookList)
    {
        Console.WriteLine("");
        Console.WriteLine($"Group: {group.Key}");
        Console.WriteLine("{0, -60 } {1,15} {2,15}\n", "Title", "Pages", "Plublished date");
        foreach(var item in group)
        {
            Console.WriteLine("{0, -60 } {1,15} {2,15}", item.Title, item.PageCount, item.publishedDate.ToShortDateString());
        }
    }
}

void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    } 
    else 
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.publishedDate.ToShortDateString());
        }
    }
}

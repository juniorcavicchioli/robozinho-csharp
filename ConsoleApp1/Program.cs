// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using HtmlAgilityPack;

Console.WriteLine("Iniciando robozinho!");
var Urls = new string[]
{
    "https://www.rottentomatoes.com/m/the_super_mario_bros_movie",
    "https://www.rottentomatoes.com/m/war_for_the_planet_of_the_apes"
};

foreach (var url in Urls)
    RodarRobozinho(url);


void RodarRobozinho(string url)
{
    var PageResult = new HttpClient().GetAsync(url).Result;



    var Html = PageResult.Content.ReadAsStringAsync().Result;
    var doc = new HtmlDocument();
    doc.LoadHtml(Html);

    Console.WriteLine(doc);


    var NovoFilme = new Filme()
    {
        Nome = doc.DocumentNode.SelectSingleNode("//*[@id=\"topSection\"]/div[1]/score-board/h1").InnerText
    };

    Console.WriteLine(NovoFilme.Nome);
}
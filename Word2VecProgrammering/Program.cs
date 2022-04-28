using System.Net;
start:
Console.Clear();

string[] ord = new string[3];

// Skriv koden her, som giver brugeren mulighed for at indtaste 3 ord,
// som efterfølgende bliver gemt i array'et ord
Console.WriteLine("Indtast 3 ord:");
for (int indeks = 0; indeks < ord.Length; indeks++)
{
    ord[indeks] = Console.ReadLine();
}
Console.WriteLine("");
Console.WriteLine("Please wait. Calling on service");
Console.WriteLine("");
// Det er er min kode, som du ikke behøver at rette i
string url = $"https://smartword2vec.azurewebsites.net/api/Top3Similar?positive1={ord[1]}&positive2={ord[2]}&negative={ord[0]}".ToLower();
HttpClient client = new ();   
HttpResponseMessage response = await client.GetAsync(url);
if (!response.IsSuccessStatusCode)
{
    Console.WriteLine("Servicen kom ikke med noget svar for de ord du skrev. Husk, at servicen kun kender engelske ord");
    return;
}
string responseBody = await response.Content.ReadAsStringAsync();
string[] resultater = responseBody.Split(';');
// Min kode slutter her

// Svaret ligger nu i array'et resultater. 
// Lav to udskrifter:
// 1) En udskrift af det mest sandsynlige svar på formen
//    a is to b, as c is to d
//    (det mest sandsynlige ord er først i array'et)
Console.WriteLine($"{ord[0]} is to {ord[1]}, as {ord[2]} is to {resultater[0]}");

// 2) En udskrift af alle de ord, der kom med tilbage som resultater
foreach (string resultaterVærdi in resultater)
{
    Console.WriteLine(resultaterVærdi);
}
Console.WriteLine("");
Console.WriteLine("Tryk på ENTER for at prøve igen.");
Console.ReadLine();
goto start;

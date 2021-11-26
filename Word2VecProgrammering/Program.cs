using System.Net;

string[] ord = new string[3];

// Skriv koden her, som giver brugeren mulighed for at indtaste 3 ord,
// som efterfølgende bliver gemt i array'et ord

// Det er er min kode, som du ikke behøver at rette i
string url = $"https://smartword2vec.azurewebsites.net/api/Top3Similar?positive1={ord[1]}&positive2={ord[3]}&negative={ord[2]}".ToLower();
HttpClient client = new ();   
HttpResponseMessage response = await client.GetAsync(url);
string responseBody = await response.Content.ReadAsStringAsync();
string[] resultater = responseBody.Split(';');
// Min kode slutter her

// Svaret ligger nu i array'et resultater. 
// Lav to udskrifter:
// 1) En udskrift af det mest sandsynlige svar på formen
//    a is to b, as c is to d
//    (det mest sandsynlige ord er først i array'et)

// 2) En udskrift af alle de ord, der kom med tilbage som resultater




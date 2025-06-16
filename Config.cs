using Exiled.API.Interfaces;

namespace AquelPlugin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public string[] characterNames { get; set; } = { "Bogusław", "Bogumił", "Bogdan", "Borzymir", "Bożydar", "Chwalibóg", "Ciechosław", "Czesław", "Dobromir", "Dobrosław", "Dobromysł", "Gniewomir", "Gościwój", "Iwosław", "Jarosław", "Jaromir", "Kazimierz", "Krzesimir", "Ludosław", "Ludomir", "Lech", "Lechosław", "Lesław", "Mirosław", "Miłorad", "Miłosz", "Mieszko", "Mieczysław", "Przemysław", "Radzimir", "Radomir", "Racibor", "Radosław", "Sławomir", "Stanisław", "Sławobor", "Siemisław", "Sobiesław", "Tadeusz", "Władysław", "Włodzimierz", "Witomysł", "Wojciech", "Wacław", "Wiesław", "Zbigniew", "Zbyszko", "Ziemowit", "Ździsław" };
    }
}

using System.Text.Json;

namespace JSONSerializer
{
    class Guy
    {
        public string Name { get; set; }
        public Hairstyle Hair { get; set; }
        public Outfit Clothes { get; set; }
        public override string ToString() => $"{Name} with {Hair} wearing {Clothes}";
    }

    class Outfit
    {
        public string Top { get; set; }
        public string Bottom { get; set; }
        public override string ToString() => $"{Top} and {Bottom}";
    }

    enum HairColor
    {
        Auburn,
        Black,
        Blonde,
        Blue,
        Brown,
        Gray,
        Platinum,
        Purple,
        Red,
        White,
    }

    class Hairstyle
    {
        public HairColor Color { get; set; }
        public float Length { get; set; }
        public override string ToString() => $"{Length:0.0} inch {Color} hair";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Guy> guys = new List<Guy>()
            {
                new Guy(){Name="Pedro",Clothes=new Outfit(){Top="t-shirt",Bottom="jeans"},Hair=new Hairstyle(){Color=HairColor.Red,Length=3.5f} },
                new Guy(){Name="Jose",Clothes=new Outfit(){Top="polo",Bottom="slacks"},Hair=new Hairstyle(){Color=HairColor.Gray,Length=2.7f} },
            };
            var jsonString = JsonSerializer.Serialize(guys);
            Console.WriteLine(jsonString);

            var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);
            foreach (var guy in guys)
            {
                Console.WriteLine("I deserialized this guy: {0}",guy);
            }
        }
        
    }
}
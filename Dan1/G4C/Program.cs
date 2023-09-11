
//zadatak 1
void Calculator()
{
    
   while(true)
    {
        var input = Console.ReadLine();
        if (input.Equals("x")) {
            return;
          }

        try
        {
            int inputNumber = int.Parse(input);
            Console.WriteLine(inputNumber * inputNumber);
        }
        catch
        {
            
        }
    }
}

//zadatak 2
void Fibonaci(int n)
{
    int first = 0;
    int second = 1;
    int result = 0;

    for(int i = 0; i < n; i++)
    {
        result = first + second;
        first = second;
        second = result;
        Console.WriteLine(result);
    }
}

//zadatak 3
void Deljivost()
{
    var input = int.Parse(Console.ReadLine());
    List<int> numbers = Enumerable.Range(1, 100).ToList();
    List<int> divided = numbers.Where(x=> x % input == 0).ToList();

    foreach(int item in divided) {
        Console.WriteLine(item);
    }
}

//zadatak 4
Calculator();
//Fibonaci(5);
//Deljivost();

Osoba osoba1 = new Osoba();
//osoba1.Zadatak6();

public enum Pol
    {
        MUSKO,
        ZENSKO
    }

    public class Osoba
    {
        string ime;
        int starost;
        Pol pol;


        public string Ime { get => ime; set => ime = value; }
        public int Starost { get => starost; set => starost = value; }
        public Pol Pol { get => pol; set => pol = value; }

    //zadatak 5
    public void Zadatak5()
        {
            List<Osoba> osobe = new List<Osoba>
            {
                new Osoba { Ime = "Marko", Starost = 30, Pol = Pol.MUSKO },
                new Osoba { Ime = "Ana", Starost = 20, Pol = Pol.ZENSKO }
            };

            var sorted = osobe.OrderByDescending(x => x.starost).ToList();

            foreach(var item in sorted)
            {
                Console.WriteLine(item.Ime + " " +  item.Starost);
            }
        }

    //zadatak 6
    public void Zadatak6()
    {
        List<Osoba> osobe = new List<Osoba>
            {
                new Osoba { Ime = "Marko", Starost = 30, Pol = Pol.MUSKO },
                new Osoba { Ime = "Ana", Starost = 20, Pol = Pol.ZENSKO }
            };

        var grupisaneOsobe = from osoba in osobe
                             group osoba by osoba.Pol into grupeOsoba
                             select new
                             {
                                 Pol = grupeOsoba.Key,
                                 Osobe = grupeOsoba.Select(o => new { Ime = o.Ime, Godina = o.Starost })
                             };
        foreach (var grupa in grupisaneOsobe)
        {
            Console.WriteLine($"Pol: {grupa.Pol}");
            foreach (var osoba in grupa.Osobe)
            {
                Console.WriteLine($"Ime: {osoba.Ime}, Godina: {osoba.Godina}");
            }
        }




        }

}



using System.Linq.Expressions;
using sorterins_uppgift;

string[] namn = {"Adam", "Agnes", "Albin", "Alice", "Amanda", "Anders", "Anna", "Anton", "Arvid", "Axel",
    "Bella", "Benjamin", "Carl", "Caroline", "Cecilia", "Charlotte", "Clara", "Daniel", "David", "Ebba",
    "Elias", "Ella", "Emil", "Emilia", "Emma", "Erik", "Ester", "Eva", "Felix", "Filip",
    "Freja", "Gabriel", "Gustav", "Hanna", "Hans", "Hedda", "Helena", "Hilda", "Hugo", "Ida",
    "Ingrid", "Isak", "Isabella", "Jakob", "Jan", "Jennifer", "Johan", "Johanna", "Jonathan", "Josefin",
    "Julia", "Kajsa", "Karin", "Karl", "Kasper", "Klara", "Kristina", "Lars", "Lea", "Lennart",
    "Liam", "Linnea", "Lotta", "Lucas", "Ludvig", "Magdalena", "Malin", "Marcus", "Maria", "Mats",
    "Mikael", "Moa", "Niklas", "Nina", "Noah", "Nora", "Oliver", "Oscar", "Patrik", "Peter",
    "Petra", "Rebecca", "Robert", "Robin", "Sara", "Sebastian", "Simon", "Sofie", "Stefan", "Stina",
    "Susanne", "Tobias", "Vera", "Viktor", "Wilma", "William", "Ylva", "Åsa", "Örjan", "Ah", "åå"};
List<personer> PersonLista = new List<personer>();

int HurMånga = 10;
Random r = new Random();
for(int i = 0; i < HurMånga+1; i+=1){
    int a = r.Next(1,10);
    PersonLista.Add(new personer(a,namn[i]));
}

/* Nu har vi några namn o person nummer i listan */
/*  bara på den första sen behöver man bara 
    en sån method för att sortera in en person */

Skriv(PersonLista);
for(int i = 3; i > 0; i--){
    Console.WriteLine("Om " + i);
    Thread.Sleep(1000);
}
Console.WriteLine("Kör");
for(int i = 0; i != PersonLista.Count; i++){
    Sortera_Stor_Små(ref PersonLista);
}
Skriv(PersonLista);
Console.WriteLine("done");


/*
Console.WriteLine("Vad heter du");
string Namn = Console.ReadLine();
Console.WriteLine("Vilket person nummer har du");
int Nummer = int.Parse(Console.ReadLine());
SorteraIn(ref PersonLista, Nummer, Namn);





Console.WriteLine("Skriv ett nummer ");
int lala = int.Parse(Console.ReadLine());

if(VemDuLetar(PersonLista, lala) != null){
    Console.Write(VemDuLetar(PersonLista, lala));
}
else{
    Console.WriteLine("Är det någon av de personer du säker?");
}
*/


static string VemDuLetar(List<personer> PL, int PNummer){
    int Plats = 0;
    

    for(int i = 0; i < PL.Count; i++){
        if(PL[i].nummer == PNummer){
            Plats = i;
            break;
        }
    }

    if(PL[Plats].nummer == PL[Plats + 1].nummer){
        FlerMedSamma(PL, Plats);
        return null;
    }



    return PL[Plats].person;
}

static void FlerMedSamma(List<personer> PL, int Plats){
    List<int> Namn = new List<int>();

    
    
    for(int i = Plats; i < PL.Count; i++){
        if(PL[Plats].nummer == PL[i].nummer){
            Namn.Add(i);
        }else{break;}
    }

    Console.WriteLine("Här är alla de personer med det nummer");
    foreach(int Person in Namn){
        Console.WriteLine(PL[Person].person + " " + PL[Person].nummer);
    }
    
}


static void Skriv(List<personer> PL){
    for(int i = 0; i < PL.Count; i++){
        Console.Write(PL[i].person + " ");
        Console.WriteLine(PL[i].nummer);
    }
}


// Det funkar men jag hade HurMånga som 1000000 och då tog det en jävla tid.
static void Sortera_Stor_Små(ref List<personer> PL){
    for(int i = 0; i < PL.Count; i++){
        if(i+1 < PL.Count){
            if(PL[i].nummer > PL[i+1].nummer){
                int T = PL[i].nummer;
                string TT = PL[i].person;
                PL[i].nummer = PL[i+1].nummer;
                PL[i+1].nummer = T;
                PL[i].person = PL[i+1].person;
                PL[i+1].person = TT;
            }
        }
    }
}

static void SorteraIn(ref List<personer> PL, int Nummer, string Namn){
    PL.Add(new personer(Nummer,Namn));
    int T = PL[0].nummer;
    string TT = PL[0].person;
    PL[0].nummer = PL[PL.Count-1].nummer;
    PL[PL.Count-1].nummer = T;
    PL[0].person = PL[PL.Count-1].person;
    PL[PL.Count-1].person = TT;
    Sortera_Stor_Små(ref PL);
}


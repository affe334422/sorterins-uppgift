﻿using System.Linq.Expressions;
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

// hur många personer du vill a i personlista.
int HurMånga = 1000;

Random r = new Random();
for(int i = 0; i < HurMånga+1; i+=1){
    int a = r.Next(1000,10000);
    PersonLista.Add(new personer(a,namn[r.Next(1,namn.Count())]));
}

/* Nu har vi några namn o person nummer i listan */


Skriv(PersonLista);
Console.WriteLine("Om ");
for(int i = 3; i > 0; i--){
    Console.Write(i + " ");
    Thread.Sleep(1000);
}
Console.WriteLine("Kör");

//uppgift 1
if(false){
    // det är bara i första sorteringen som man behöver for loopen
    for(int i = 0; i != PersonLista.Count; i++){
        Sortera_Stor_Små(ref PersonLista);
    }
}
// uppgift 2
if(true){
   PersonLista = MergeSort(PersonLista);
}

Skriv(PersonLista);
Console.WriteLine("done");



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



static List<personer> MergeSort(List<personer> PL){
    // del 1
    if (PL.Count <= 1)
        return PL;

    int Mitten = PL.Count / 2;

    // del 2
    // Dela listan i två halvor
    List<personer> AllaPåVSida = MergeSort(PL.GetRange(0, Mitten));
    List<personer> AllaPåHSida = MergeSort(PL.GetRange(Mitten, PL.Count - Mitten));
    /*
    varje / är en ny Mergsort method. allapå v och h sida
        1 list = 1,5,7,3,9,8,4,2 skip del 1
        2 list 1,5,7,3 / 9,8,4,2 skip del 1
        3 list 1,5 / 7,3 / 9,8 / 4,2 skip del 1
        4 list 1 / 5 / 7 / 3 / 9 / 8 / 4 / 2 Kör del 1 
            Nu är det 1st i list PL så den ger tillbaka PL i del 1
            Och då får del 2 i nummer 3 de singulära talen. och 
            skickar ner den till Merge.
    */
    // del 3
    // Slå ihop de sorterade halvorna
    return Merge(AllaPåVSida, AllaPåHSida);
}


// Merge-metoden
static List<personer> Merge(List<personer> AllaPåVSida, List<personer> AllaPåHSida){
    List<personer> result = new List<personer>();
    int i = 0;
    int j = 0;
    /*
        Nu är det 4
        4 list 1 / 5 / 7 / 3 / 9 / 8 / 4 / 2
        Nu if 1 < 5 / 7 < 3 / 9 < 8 / 4 < 2
        return 1,5 / 3,7 / 8,9 / 2,4
        3. list 1,5 / 3,7 / 8,9 / 2,4
            nu if 1 < 3
            resultat = 1,
            if 5 < 3
            resultat = 1,3
            if 5 < 7
            reultat = 1,3,5
            lägget till det som är över (7) i resultat
            resultat = 1,3,5,7
        sen samma sak med 8,9 / 2,4
        resultat = 2,4,8,9
        2 list 1,3,5,7 / 2,4,8,9
        if 1 < 2 o så vidare
        tillsist resultat = 1,2,3,4,5,7,8,9
        tillbaka till mergesort som ger return 1,2,3,4,5,7,8,9
    */


    // Jämför och slå ihop

    while (i < AllaPåVSida.Count && j < AllaPåHSida.Count){// medans i = 0 är mindre än allavsida längd och j = 0 mindre än allahsida längd
        if (AllaPåVSida[i].nummer <= AllaPåHSida[j].nummer){ // om nummret på plats 0 i allaVsida är mindre än nummret på plats 0 i allaHsida
            result.Add(AllaPåVSida[i]); // då lägger den till nummret på plats 0 i allaVsida till resultatet
            i++; 
        }
        else{
            result.Add(AllaPåHSida[j]); // annars lägger den till talet på plats 0 i allaHsida till resultatet.
            j++;
        }
    }

    
    while (i < AllaPåVSida.Count){ // om det är olika många nummer i listorna så en tar slut tidigare
        result.Add(AllaPåVSida[i]);// så skickas den ner till dessa koderna för att lägga till det nummer
        i++;                       // som är över i resultat, det ända kortet som kan vara över är det som är högst.
    }

    
    while (j < AllaPåHSida.Count){
        result.Add(AllaPåHSida[j]);
        j++;
    }

    return result;
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


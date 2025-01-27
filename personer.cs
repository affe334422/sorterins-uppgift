using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sorterins_uppgift
{
    public class personer
    {
        private string Person;

        private int Nummer;

        public personer(int b, string a){
            Person = a;
            Nummer = b;
        }

        public string person{
            set {Person = value;}
            get {return Person;}
        }

        public int nummer{
            set {Nummer = value;}
            get {return Nummer;}
        }

    }
}
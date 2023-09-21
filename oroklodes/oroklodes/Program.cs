using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace oroklodes
{

    class Allat
    {

        protected string hely;
        protected string beszed;

        public Allat(string hely)
        {
            this.hely = hely;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public virtual void Beszel()
        {
            beszed = "";
        }

    }
    class Kutya : Allat
    {
        protected string gazdi;

       class Kutya(string hely, string gazdi) :base(hely)
            {
            this.gazdi = gazdi;
            }
    }
}
internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

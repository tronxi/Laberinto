using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaberintoIA
{
    class Program
    {
        private Controlador control;
        public Program()
        {
            control = new ControladorIA();
            //control = new ControladorUsuario();
            control.Jugar();
            Console.WriteLine("fin");
            Console.Read();
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}

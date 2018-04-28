using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaberintoIA
{
    class ControladorUsuario : Controlador
    {
        private Jugador jugador;
        private Tablero tablero;

        public ControladorUsuario()
        {
            jugador = new Jugador();
            tablero = Tablero.GetTablero();
        }
        public void Jugar()
        {
            Mover();
        }

        private void Mover()
        {
            do
            {
                char tecla = Console.ReadKey().KeyChar;
                tecla = Char.ToLower(tecla);

                if (tecla == 'w')
                {
                    jugador.Avanzar();
                }
                else if(tecla == 's')
                {
                    jugador.GirarDerecha();
                    jugador.GirarDerecha();
                    jugador.Avanzar();
                }
                else if(tecla == 'a')
                {
                    jugador.GirarIzquierda();
                    jugador.Avanzar();
                }
                else if(tecla == 'd')
                {
                    jugador.GirarDerecha();
                    jugador.Avanzar();
                }
                tablero.Imprimir();
            } while (!jugador.IsFinal());
        }

    }
}

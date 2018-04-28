using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaberintoIA
{
    class ControladorIA : Controlador
    {
        private Jugador jugador;
        private Tablero tablero;
        public ControladorIA()
        {
            jugador = new Jugador();
            tablero = Tablero.GetTablero();
        }

        public void Jugar()
        {
            Algoritmo2();
        }
        
        private void Algoritmo2()
        {
            do
            {
                if (jugador.MirarIzquierda())
                {
                    jugador.GirarIzquierda();
                }
                else if (jugador.MirarDelante())
                {
                    
                }
                else if (jugador.MirarDerecha())
                {
                    jugador.GirarDerecha();
                }
                else if (!jugador.MirarDelante() &&
                    !jugador.MirarDerecha() && !jugador.MirarIzquierda())
                {
                    jugador.GirarIzquierda();
                    jugador.GirarIzquierda();
                }
                jugador.Avanzar();
                tablero.Imprimir();
            } while (!jugador.IsFinal());
        }
        private void Algoritmo1()
        {
            do
            {
                if (jugador.MirarDerecha())
                {
                    jugador.GirarDerecha();
                }
                else if (jugador.MirarDelante())
                {
                    
                }
                else if (jugador.MirarIzquierda())
                {
                    jugador.GirarIzquierda();
                }
                else if (!jugador.MirarDelante() &&
                    !jugador.MirarDerecha() && !jugador.MirarIzquierda())
                {
                    jugador.GirarIzquierda();
                    jugador.GirarIzquierda();
                }
                jugador.Avanzar();
                tablero.Imprimir();
            } while (!jugador.IsFinal());
        }
    }
}

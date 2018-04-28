using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaberintoIA
{
    class Jugador
    {
        private const int VACIO = 0;
        private const int PARED = 1;
        private const int JUGADOR = 2;

        private string[] posiciones = { "NORTE", "ESTE", "SUR", "OESTE" };
        private int posActual;

        private int nuevaX, nuevaY;

        private Tablero tablero;

        public Jugador()
        {
            tablero = Tablero.GetTablero();
            tablero.SetPos(tablero.GetPosX(), tablero.GetPosY(), JUGADOR);
            posActual = 2;

            nuevaX = tablero.GetPosX();
            nuevaY = tablero.GetPosY();
        }

        public void GirarDerecha()
        {
            posActual++;
            if(posActual == posiciones.Length)
            {
                posActual = 0;
            }
        }
        public void GirarIzquierda()
        {
            posActual--;
            if(posActual < 0)
            {
                posActual = posiciones.Length - 1;
            }
        }

        public bool MirarDelante()
        {
            int nX = nuevaX;
            int nY = nuevaY;
            if (posiciones[posActual] == "NORTE")
            {
                nuevaX--;
            }
            else if (posiciones[posActual] == "SUR")
            {
                nuevaX++;
            }
            else if (posiciones[posActual] == "ESTE")
            {
                nuevaY--;
            }
            else if (posiciones[posActual] == "OESTE")
            {
                nuevaY++;
            }
            try
            {
                return ComporbarPosicion(nuevaX, nuevaY);
            }
            finally
            {
                nuevaX = nX;
                nuevaY = nY;
            }
        }
        public bool MirarDerecha()
        {
            GirarDerecha();
            try
            {
                return MirarDelante();
            }
            finally
            {
                GirarIzquierda();
            }
        }
        public bool MirarIzquierda()
        {
            GirarIzquierda();
            try
            {
                return MirarDelante();
            }
            finally
            {
                GirarDerecha();
            }
        }
        public void Avanzar()
        {
            int nX = nuevaX;
            int nY = nuevaY;
            if(posiciones[posActual] == "NORTE")
            {
                nuevaX--;
            }
            else if (posiciones[posActual] == "SUR")
            {
                nuevaX++;
            }
            else if (posiciones[posActual] == "ESTE")
            {
                nuevaY--;
            }
            else if (posiciones[posActual] == "OESTE")
            {
                nuevaY++;
            }

            if(ComporbarPosicion(nuevaX, nuevaY))
            {
                tablero.SetPos(nX, nY, VACIO);
                tablero.SetPos(nuevaX, nuevaY, JUGADOR);
            }
            else
            {
                nuevaX = nX;
                nuevaY = nY;
            }
        }
        public bool IsFinal()
        {
            return tablero.IsFinal(nuevaX, nuevaY);
        }
        private bool ComporbarPosicion(int x, int y)
        {
            return tablero.IsLibre(x, y);
        }
    }
}

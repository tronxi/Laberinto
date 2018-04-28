using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaberintoIA
{
    class LaberintoG
    {
        private const int VACIO = 0;
        private const int PARED = 1;
        private const int JUGADOR = 2;
        private const int FINAL = 4;
        private int tamX;
        private int tamY;
        private int finalX;
        private int finalY;
        private int[,] laberinto =
        {
            {
                2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            },
            {
                0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 4, 1,
            },
            {
                1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1,
            },
            {
                1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1,
            },
            {
                1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1,
            },
            {
                1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1,
            },
            {
                1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1,
            },
            {
                1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1,
            },
            {
                1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1,
            },
            {
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            }
        };
        public LaberintoG()
        {
            SetTamX(laberinto.GetLength(0));
            SetTamY(laberinto.GetLength(1));

            SetFinalAutomatico();
        }
        public void SetFinalAutomatico()
        {
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    if (laberinto[i, j] == FINAL)
                    {
                        finalX = i;
                        finalY = j;
                    }
                }
            }
        }
        public void SetFinalX(int x)
        {
            finalX = x;
        }

        public void SetFinalY(int y)
        {
            finalY = y;
        }
        public void SetTamX(int tamX)
        {
            this.tamX = tamX;
        }
        public void SetTamY(int tamY)
        {
            this.tamY = tamY;
        }
        public int GetTamX()
        {
            return this.tamX;
        }

        public int GetTamY()
        {
            return this.tamY;
        }

        public int GetFinalX()
        {
            return finalX;
        }

        public int GetFinalY()
        {
            return finalY;
        }

        public int[,] GetLaberinto()
        {
            return laberinto;
        }

        private void InicializarLaberinto()
        {
            Random rdn = new Random();
            laberinto = new int[GetTamX(), GetTamY()];
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    if (i != 0 && j != 0)
                    {

                        int opcion = rdn.Next(0, 2);
                        int valor;
                        if (opcion == 0)
                        {
                            valor = 0;
                        }
                        else
                        {
                            valor = -2;
                        }
                        laberinto[i, j] = valor;
                    }
                }
            }
            laberinto[GetFinalX(), GetFinalY()] = 4;
        }
    }
}

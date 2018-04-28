using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LaberintoIA
{

    class Tablero
    {
        private const int VACIO = 0;
        private const int PARED = 1;
        private const int JUGADOR = 2;
        private const int FINAL = 4;
        private int posX;
        private int posY;
        private int posXFinal;
        private int posYFinal;
        private int[,] laberinto;
        private int tamX;
        private int tamY;
        private int totalBuscando;
        private static Tablero tab;
        private Tablero()
        {
            LaberintoG lab = new LaberintoG();
            tamX = lab.GetTamX();
            tamY = lab.GetTamY();
            posXFinal = lab.GetFinalX();
            posYFinal = lab.GetFinalY();
            laberinto = new int[tamX, tamY];
            this.SetLaberinto(lab.GetLaberinto());
            totalBuscando = 0;
            this.SetPosAutomatica();
        }
        public static Tablero GetTablero()
        {
            if(tab == null)
            {
                tab = new Tablero();
            }
            return tab;
        }

        private void SetPosAutomatica()
        {
            for (int i = 0; i < this.laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < this.laberinto.GetLength(1); j++)
                {
                    if(laberinto[i,j] == JUGADOR)
                    {
                        posX = i;
                        posY = j;
                    }
                    else if(laberinto[i, j] == FINAL)
                    {
                        totalBuscando++;
                    }
                }
            }
        }

        public bool IsLibre(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < tamX && y < tamY)
            {
                return laberinto[x, y] != PARED;
            }
            else
            {
                return false;
            }
        }

        public bool IsFinal(int x, int y)
        {
            return x == GetPosXFinal() && y == GetPosYFinal();
        }
        public int GetPos(int x, int y)
        {
            return laberinto[x, y];
        }
        public void SetPos(int x, int y, int v)
        {
            laberinto[x, y] = v;
        }
        public int[,] GetLaberinto()
        {
            return laberinto;
        }
        public void SetLaberinto(int[,] laberinto)
        {
            for (int i = 0; i < this.laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < this.laberinto.GetLength(1); j++)
                {
                    this.laberinto[i, j] = laberinto[i, j];
                }
            }
        }
        public void Imprimir()
        {
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < this.laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < this.laberinto.GetLength(1); j++)
                {
                    if(laberinto[i,j] == VACIO)
                    {
                        Console.Write("   ");
                    }
                    else if(laberinto[i, j] == PARED)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" * ");
                    }
                    else if (laberinto[i, j] == JUGADOR)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" # ");
                    }
                    if (laberinto[i, j] == FINAL)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" & ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
            }
        }
        public int GetPosX()
        {
            return posX;
        }
        public int GetPosY()
        {
            return posY;
        }
        public int GetPosXFinal()
        {
            return posXFinal;
        }
        public int GetPosYFinal()
        {
            return posYFinal;
        }
        public void SetPosX(int posX)
        {
            this.posX = posX;
        }
        public void SetPosY(int posY)
        {
            this.posY = posY;
        }
        public void SetPosXFinal(int posXFinal)
        {
            this.posXFinal = posXFinal;
        }
        public void SetPosYFinal(int posYFinal)
        {
            this.posYFinal = posYFinal;
        }
    }
}

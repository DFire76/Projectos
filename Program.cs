using System;

namespace Chess
{
    public class badPieceException : Exception
    {
        public badPieceException() { }
    }
    public class wrongLocationException : Exception
    {
        public wrongLocationException() { }
    }
    public class Piece
    {
        private char symbol;
        private int x, y;
        private bool color, moved; // true for whites, false for blacks

        public Piece(char symbol, int x, int y, bool color)
        {
            if (symbol != 'p' && symbol != 'P' && symbol != 'r' && symbol != 'R' && symbol != 'b' &&
                symbol != 'B' && symbol != 'n' && symbol != 'N' && symbol != 'q' && symbol != 'Q' &&
                symbol != 'k' && symbol != 'K' && symbol != 'e' && symbol != 'E' && symbol != 'g' &&
                symbol != 'G')
                throw new badPieceException();

            if (x < 0 && x >= 8 && y < 0 && y >= 8)
                throw new wrongLocationException();

            this.symbol = symbol;
            this.x = x;
            this.y = y;
            this.color = color;
            moved = false;
        }
        public Piece(Piece p)
        {
            symbol = p.symbol;
            x = p.x;
            y = p.y;
            color = p.color;
            moved = p.moved;
        }
        public char getSymbol()
        {
            return symbol;
        }
        public bool getColor()
        {
            return color;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void move()
        {
            moved = false;
        }
        public Piece[,] checkMoves(Piece[,] board)
        {
            Piece[,] movements = new Piece[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    movements[i, j] = null;

            switch (symbol)
            {
                case 'p':
                case 'P':
                    movePawn(movements, board);
                    break;
                case 'r':
                case 'R':
                    moveRook(movements, board);
                    break;
                case 'b':
                case 'B':
                    moveBishop(movements, board);
                    break;
                case 'n':
                case 'N':
                    moveKnight(movements, board);
                    break;
                case 'q':
                case 'Q':
                    moveQueen(movements, board);
                    break;
                case 'k':
                case 'K':
                    moveKing(movements, board);
                    break;
                case 'e':
                case 'E':
                    moveElephant(movements, board);
                    break;
                case 'g':
                case 'G':
                    moveGeneral(movements, board);
                    break;
            }
            return movements;
        }
        private void movePawn(Piece[,] movements, Piece[,] board)
        {
            if (symbol == 'p')
            {
                if (x - 1 > 0 && board[x - 1, y] == null)
                {
                    movements[x - 1, y] = new Piece('p', x - 1, y, false);
                    if (x == 6 && board[x - 2, y] == null)
                        movements[x - 2, y] = new Piece('p', x - 2, y, false);
                }

                if (x - 1 > 0 && y - 1 >= 0 && board[x - 1, y - 1] != null && board[x - 1, y - 1].color)
                    movements[x - 1, y - 1] = new Piece('P', x - 1, y - 1, true);
                if (x - 1 > 0 && y + 1 < 8 && board[x - 1, y + 1] != null && board[x - 1, y + 1].color)
                    movements[x - 1, y + 1] = new Piece('P', x - 1, y + 1, true);
            }
            if (symbol == 'P')
            {
                if (x + 1 < 8 && board[x + 1, y] == null)
                {
                    movements[x + 1, y] = new Piece('P', x + 1, y, true);
                    if (x == 1 && board[x + 2, y] == null)
                        movements[x + 2, y] = new Piece('P', x + 2, y, true); ;
                }

                if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1] != null && !board[x + 1, y - 1].color)
                    movements[x + 1, y - 1] = new Piece('p', x + 1, y - 1, false);
                if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1] != null && !board[x + 1, y + 1].color)
                    movements[x + 1, y + 1] = new Piece('p', x + 1, y + 1, false);
            }
        }
        private void moveRook(Piece[,] movements, Piece[,] board)
        {
            for (int i = 1; i < 8; i++)
                if (x - i >= 0 && board[x - i, y] == null)
                    movements[x - i, y] = new Piece('r', x - i, y, false);
                else if (x - i >= 0 && board[x - i, y] != null && color != board[x - i, y].color)
                {
                    movements[x - i, y] = new Piece('R', x - i, y, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1; i < 8; i++)
                if (y - i >= 0 && board[x, y - i] == null)
                    movements[x, y - i] = new Piece('r', x, y - i, false);
                else if (y - i >= 0 && board[x, y - i] != null && color != board[x, y - i].color)
                {
                    movements[x, y - 1] = new Piece('R', x, y - 1, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1; i < 8; i++)
                if (x + i < 8 && board[x + i, y] == null)
                    movements[x + i, y] = new Piece('r', x + i, y, false);
                else if (x + i < 8 && board[x + i, y] != null && color != board[x + i, y].color)
                {
                    movements[x + i, y] = new Piece('R', x + i, y, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1; i < 8; i++)
                if (y + i < 8 && board[x, y + i] == null)
                    movements[x, y + i] = new Piece('r', x, y + i, false);
                else if (y + i < 8 && board[x, y + i] != null && color != board[x, y + i].color)
                {
                    movements[x, y + 1] = new Piece('R', x, y + 1, true);
                    i = 8;
                }
                else
                    i = 8;
        }
        private void moveKnight(Piece[,] movements, Piece[,] board)
        {
            for (int i = 1; i <= 2; i++)
                for (int j = 1; j <= 2; j++)
                    if (i + j == 3)
                    {
                        if (x + i < 8 && y + j < 8 && board[x + i, y + j] == null)
                            movements[x + i, y + j] = new Piece('n', x + i, y + j, false);
                        else if (x + i < 8 && y + j < 8 && board[x + i, y + j] != null && color != board[x + i, y + j].color)
                            movements[x + i, y + j] = new Piece('N', x + i, y + j, true);

                        if (x - i >= 0 && y - j >= 0 && board[x - i, y - j] == null)
                            movements[x - i, y - j] = new Piece('n', x - i, y - j, false);
                        else if (x - i >= 0 && y - j >= 0 && board[x - i, y - j] != null && color != board[x - i, y - j].color)
                            movements[x - i, y - j] = new Piece('N', x - i, y - j, true);

                        if (x - i > 0 && y + j < 8 && board[x - i, y + j] == null)
                            movements[x - i, y + j] = new Piece('n', x - i, y + j, false);
                        else if (x - i > 0 && y + j < 8 && board[x - i, y + j] != null && color != board[x - i, y + j].color)
                            movements[x - i, y + j] = new Piece('N', x - i, y + j, true);

                        if (x + i < 8 && y - j >= 0 && board[x + i, y - j] == null)
                            movements[x + i, y - j] = new Piece('n', x + i, y - j, false);
                        else if (x + i < 8 && y - j >= 0 && board[x + i, y - j] != null && color != board[x + i, y - j].color)
                            movements[x + i, y - j] = new Piece('N', x + i, y - j, true);
                    }
        }
        private void moveBishop(Piece[,] movements, Piece[,] board)
        {
            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x + i < 8 && y + i < 8 && board[x + i, y + j] == null)
                    movements[x + i, y + j] = new Piece('b', x + i, y + j, false);
                else if (x + i < 8 && y + i < 8 && board[x + i, y + j] != null && color != board[x + i, y + j].color)
                {
                    movements[x + i, y + j] = new Piece('B', x + i, y + j, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x + i < 8 && y - i >= 0 && board[x + i, y - j] == null)
                    movements[x + i, y - j] = new Piece('b', x + i, y - j, false);
                else if (x + i < 8 && y - i >= 0 && board[x + i, y - j] != null && color != board[x + i, y - j].color)
                {
                    movements[x + i, y - j] = new Piece('B', x + i, y - j, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x - i >= 0 && y - i >= 0 && board[x - i, y - j] == null)
                    movements[x - i, y - j] = new Piece('b', x - i, y - j, false);
                else if (x - i >= 0 && y - i >= 0 && board[x - i, y - j] != null && color != board[x - i, y - j].color)
                {
                    movements[x - i, y - j] = new Piece('B', x - i, y - j, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x - i >= 0 && y + i < 8 && board[x - i, y + j] == null)
                    movements[x - i, y + j] = new Piece('b', x - i, y + j, false);
                else if (x - i >= 0 && y + i < 8 && board[x - i, y + j] != null && color != board[x - i, y + j].color)
                {
                    movements[x - i, y + j] = new Piece('B', x - i, y + j, true);
                    i = 8;
                }
                else
                    i = 8;
        }
        private void moveQueen(Piece[,] movements, Piece[,] board)
        {
            for (int i = 1; i < 8; i++)
                if (x - i >= 0 && board[x - i, y] == null)
                    movements[x - i, y] = new Piece('q', x - i, y, false);
                else if (x - i >= 0 && board[x - i, y] != null && color != board[x - i, y].color)
                {
                    movements[x - i, y] = new Piece('Q', x - i, y, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1; i < 8; i++)
                if (y - i >= 0 && board[x, y - i] == null)
                    movements[x, y - i] = new Piece('q', x, y - i, false);
                else if (y - i >= 0 && board[x, y - i] != null && color != board[x, y - i].color)
                {
                    movements[x, y - 1] = new Piece('Q', x, y - 1, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1; i < 8; i++)
                if (x + i < 8 && board[x + i, y] == null)
                    movements[x + i, y] = new Piece('q', x + i, y, false);
                else if (x + i < 8 && board[x + i, y] != null && color != board[x + i, y].color)
                {
                    movements[x + i, y] = new Piece('Q', x + i, y, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1; i < 8; i++)
                if (y + i < 8 && board[x, y + i] == null)
                    movements[x, y + i] = new Piece('q', x, y + i, false);
                else if (y + i < 8 && board[x, y + i] != null && color != board[x, y + i].color)
                {
                    movements[x, y + 1] = new Piece('Q', x, y + 1, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x + i < 8 && y + i < 8 && board[x + i, y + j] == null)
                    movements[x + i, y + j] = new Piece('q', x + i, y + j, false);
                else if (x + i < 8 && y + i < 8 && board[x + i, y + j] != null && color != board[x + i, y + j].color)
                {
                    movements[x + i, y + j] = new Piece('Q', x + i, y + j, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x + i < 8 && y - i >= 0 && board[x + i, y - j] == null)
                    movements[x + i, y - j] = new Piece('q', x + i, y - j, false);
                else if (x + i < 8 && y - i >= 0 && board[x + i, y - j] != null && color != board[x + i, y - j].color)
                {
                    movements[x + i, y - j] = new Piece('Q', x + i, y - j, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x - i >= 0 && y - i >= 0 && board[x - i, y - j] == null)
                    movements[x - i, y - j] = new Piece('q', x - i, y - j, false);
                else if (x - i >= 0 && y - i >= 0 && board[x - i, y - j] != null && color != board[x - i, y - j].color)
                {
                    movements[x - i, y - j] = new Piece('Q', x - i, y - j, true);
                    i = 8;
                }
                else
                    i = 8;

            for (int i = 1, j = 1; i < 8; i++, j++)
                if (x - i >= 0 && y + i < 8 && board[x - i, y + j] == null)
                    movements[x - i, y + j] = new Piece('q', x - i, y + j, false);
                else if (x - i >= 0 && y + i < 8 && board[x - i, y + j] != null && color != board[x - i, y + j].color)
                {
                    movements[x - i, y + j] = new Piece('Q', x - i, y + j, true);
                    i = 8;
                }
                else
                    i = 8;
        }
        private void moveKing(Piece[,] movements, Piece[,] board)
        {
            if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1] == null)
                movements[x + 1, y - 1] = new Piece('k', x + 1, y - 1, false);
            else if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1] != null && color != board[x + 1, y - 1].color)
                movements[x + 1, y - 1] = new Piece('K', x + 1, y - 1, true);

            if (x + 1 < 8 && board[x + 1, y] == null)
                movements[x + 1, y] = new Piece('k', x + 1, y, false);
            else if (x + 1 < 8 && board[x + 1, y] != null && color != board[x + 1, y].color)
                movements[x + 1, y] = new Piece('K', x + 1, y, true);

            if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1] == null)
                movements[x + 1, y + 1] = new Piece('k', x + 1, y + 1, false);
            else if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1] != null && color != board[x + 1, y + 1].color)
                movements[x + 1, y + 1] = new Piece('K', x + 1, y + 1, true);

            if (y - 1 >= 0 && board[x, y - 1] == null)
                movements[x, y - 1] = new Piece('k', x, y - 1, false);
            else if (y - 1 >= 0 && board[x, y - 1] != null && color != board[x, y - 1].color)
                movements[x, y - 1] = new Piece('K', x, y - 1, true);

            if (y + 1 < 8 && board[x, y + 1] == null)
                movements[x, y + 1] = new Piece('k', x, y + 1, false);
            else if (y + 1 < 8 && board[x, y + 1] != null && color != board[x, y + 1].color)
                movements[x, y + 1] = new Piece('K', x, y + 1, true);

            if (x - 1 >= 0 && y - 1 >= 0 && board[x - 1, y - 1] == null)
                movements[x - 1, y - 1] = new Piece('k', x - 1, y - 1, false);
            else if (x - 1 >= 0 && y - 1 >= 0 && board[x - 1, y - 1] != null && color != board[x - 1, y - 1].color)
                movements[x - 1, y - 1] = new Piece('K', x - 1, y - 1, true);

            if (x - 1 >= 0 && board[x - 1, y] == null)
                movements[x - 1, y] = new Piece('k', x - 1, y, false);
            else if (x - 1 >= 0 && board[x - 1, y] != null && color != board[x - 1, y].color)
                movements[x - 1, y] = new Piece('K', x - 1, y, true);

            if (x - 1 >= 0 && y + 1 < 8 && board[x - 1, y + 1] == null)
                movements[x - 1, y + 1] = new Piece('k', x - 1, y + 1, false);
            else if (x - 1 >= 0 && y + 1 < 8 && board[x - 1, y + 1] != null && color != board[x - 1, y + 1].color)
                movements[x + -1, y + 1] = new Piece('K', x - 1, y + 1, true);

            if (!moved)
            {
                for (int i = 1; i < 8; i++)
                    if (y + i < 8 && board[x, y + i] != null && !(board[x, y + i].symbol == 'r' || board[x, y + i].symbol == 'R'))
                        i = 8;
                    else if (y + i < 8 && board[x, y + i] != null && (board[x, y + i].symbol == 'r' || board[x, y + i].symbol == 'R') && color == board[x, y + i].color && !board[x, y + i].moved)
                    {
                        movements[x, y + 2] = new Piece('k', x, y + 2, false);
                    }

                for (int i = 1; i < 8; i++)
                    if (y - i >= 0 && board[x, y - i] != null && !(board[x, y - i].symbol == 'r' || board[x, y - i].symbol == 'R'))
                        i = 8;
                    else if (y - i >= 0 && board[x, y - i] != null && (board[x, y - i].symbol == 'r' || board[x, y - i].symbol == 'R') && color == board[x, y - i].color && !board[x, y - i].moved)
                        movements[x, y - 2] = new Piece('k', x, y - 2, false);
            }
        }
        private void moveElephant(Piece[,] movements, Piece[,] board)
        {

            if (x + 2 < 8 && y + 2 < 8 && board[x + 2, y + 2] == null)
                movements[x + 2, y + 2] = new Piece('e', x + 2, y + 2, false);
            else if (x + 2 < 8 && y + 2 < 8 && board[x + 2, y + 2] != null && color != board[x + 2, y + 2].color)
                movements[x + 2, y + 2] = new Piece('E', x + 2, y + 2, true);

            if (x - 2 >= 0 && y - 2 >= 0 && board[x - 2, y - 2] == null)
                movements[x - 2, y - 2] = new Piece('e', x - 2, y - 2, false);
            else if (x - 2 >= 0 && y - 2 >= 0 && board[x - 2, y - 2] != null && color != board[x - 2, y - 2].color)
                movements[x - 2, y - 2] = new Piece('E', x - 2, y - 2, true);

            if (x - 2 >= 0 && y + 2 < 8 && board[x - 2, y + 2] == null)
                movements[x - 2, y + 2] = new Piece('e', x - 2, y + 2, false);
            else if (x - 2 >= 0 && y + 2 < 8 && board[x - 2, y + 2] != null && color != board[x - 2, y + 2].color)
                movements[x - 2, y + 2] = new Piece('E', x - 2, y + 2, true);

            if (x + 2 < 8 && y - 2 >= 0 && board[x + 2, y - 2] == null)
                movements[x + 2, y - 2] = new Piece('e', x + 2, y - 2, false);
            else if (x + 2 < 8 && y - 2 >= 0 && board[x + 2, y - 2] != null && color != board[x + 2, y - 2].color)
                movements[x + 2, y - 2] = new Piece('E', x + 2, y - 2, true);
        }
        private void moveGeneral(Piece[,] movements, Piece[,] board)
        {

            if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1] == null)
                movements[x + 1, y + 1] = new Piece('g', x + 1, y + 1, false);
            else if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1] != null && color != board[x + 1, y + 1].color)
                movements[x + 2, y + 2] = new Piece('G', x + 2, y + 2, true);

            if (x - 1 >= 0 && y - 1 >= 0 && board[x - 1, y - 1] == null)
                movements[x - 1, y - 1] = new Piece('g', x - 1, y - 1, false);
            else if (x - 1 >= 0 && y - 1 >= 0 && board[x - 1, y - 1] != null && color != board[x - 1, y - 1].color)
                movements[x - 1, y - 1] = new Piece('G', x - 1, y - 1, true);

            if (x - 1 >= 0 && y + 1 < 8 && board[x - 1, y + 1] == null)
                movements[x - 1, y + 1] = new Piece('g', x - 1, y + 1, false);
            else if (x - 1 >= 0 && y + 1 < 8 && board[x - 1, y + 1] != null && color != board[x - 1, y + 1].color)
                movements[x - 1, y + 1] = new Piece('G', x - 1, y + 1, true);

            if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1] == null)
                movements[x + 1, y - 1] = new Piece('g', x + 1, y - 1, false);
            else if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1] != null && color != board[x + 1, y - 1].color)
                movements[x + 1, y - 1] = new Piece('G', x + 1, y - 1, true);
        }
        public void ascent()
        {
            bool wrongInput = true;
            char input = symbol;

            do
            {
                try
                {
                    if (color)
                    {
                        Console.WriteLine("Introduce la pieza a ascender(Q, N, B, R): ");
                        input = char.Parse(Console.ReadLine());

                        if (input == 'Q' || input == 'N' || input == 'B' || input == 'R')
                            wrongInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Introduce la pieza a ascender(q, n, b, r): ");
                        input = char.Parse(Console.ReadLine());

                        if (input == 'q' || input == 'n' || input == 'b' || input == 'r')
                            wrongInput = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Carácter incorrecto");
                }
            } while (wrongInput);

            symbol = input;
        }
    }
    public class Chess
    {
        public Piece[,] board;
        private bool inCheck, inCheckMate, turn, mode;

        public Chess()
        {
            Console.Title = "Game";
            inCheck = false;
            inCheckMate = false;
            turn = true;
            board = new Piece[8, 8];

            Console.WriteLine("Elige el juego: ");
            Console.WriteLine(" 0.- Shatranj");
            Console.WriteLine(" 1.- Ajedrez");

            if (Console.ReadLine() == "0")
            {
                Console.Title = "Shatranj";
                mode = false;
            }
            else
            {
                Console.Title = "Ajedrez";
                mode = true;
            }

            for (int i = 2; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    board[i, j] = null;

            board[0, 0] = new Piece('R', 0, 0, true);
            board[0, 1] = new Piece('N', 0, 1, true);
            board[0, 3] = new Piece('K', 0, 3, true);
            board[0, 6] = new Piece('N', 0, 6, true);
            board[0, 7] = new Piece('R', 0, 7, true);

            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Piece('P', 1, i, true);
                board[6, i] = new Piece('p', 6, i, false);
            }

            board[7, 0] = new Piece('r', 7, 0, false);
            board[7, 1] = new Piece('n', 7, 1, false);
            board[7, 3] = new Piece('k', 7, 3, false);
            board[7, 6] = new Piece('n', 7, 6, false);
            board[7, 7] = new Piece('r', 7, 7, false);

            if (mode)
            {
                board[0, 2] = new Piece('B', 0, 2, true);
                board[0, 4] = new Piece('Q', 0, 4, true);
                board[0, 5] = new Piece('B', 0, 5, true);

                board[7, 2] = new Piece('b', 7, 2, false);
                board[7, 4] = new Piece('q', 7, 4, false);
                board[7, 5] = new Piece('b', 7, 5, false);
            }
            else
            {
                board[0, 2] = new Piece('E', 0, 2, true);
                board[0, 4] = new Piece('G', 0, 4, true);
                board[0, 5] = new Piece('E', 0, 5, true);

                board[7, 2] = new Piece('e', 7, 2, false);
                board[7, 4] = new Piece('g', 7, 4, false);
                board[7, 5] = new Piece('e', 7, 5, false);
            }
        }
        private Piece[,] CopyBoard()
        {
            Piece[,] aux = new Piece[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (board[i, j] != null)
                        aux[i, j] = new Piece(board[i, j]);
                    else
                        aux[i, j] = null;

            return aux;
        }
        public void begin()
        {
            int[] pieceToMove = new int[2], placeToMove = new int[2];
            bool wrongInput = true;
            Piece[,] moves = null;
        again:
            do
            {
                checkInCheck(turn, board);
                show();
                if (turn)
                    Console.WriteLine("Turno de las blancas");
                else
                    Console.WriteLine("Turno de las negras");

                do
                {
                    Console.WriteLine("Introduce la posición de la pieza a mover (x.y): ");
                    string origin = Console.ReadLine(), errorMessage = "Posición incorrecta";
                    try
                    {
                        string[] aux = origin.Split('.');

                        for (int i = 0; i < aux.Length; i++)
                            pieceToMove[i] = int.Parse(aux[i]);

                        wrongInput = checkPosition(pieceToMove[0], pieceToMove[1], turn);

                        if (!wrongInput)
                        {
                            moves = showMoves(pieceToMove[0], pieceToMove[1]);
                            errorMessage = "No hay movimientos disponibles";

                            wrongInput = true;
                            foreach (var move in moves)
                                if (move == null)
                                {
                                    wrongInput = false;
                                    break;
                                }
                        }

                        if (wrongInput)
                        {
                            Console.Clear();
                            Console.WriteLine(errorMessage);
                            show();
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Posición incorrecta");
                        show();
                    }
                } while (wrongInput);
                wrongInput = true;

                do
                {
                    try
                    {
                        Console.WriteLine("Introduce la posición destino (x,y): ");
                        string destiny = Console.ReadLine();
                        string[] aux = destiny.Split('.');
                        Piece[,] auxBoard = CopyBoard();

                        for (int i = 0; i < aux.Length; i++)
                            placeToMove[i] = int.Parse(aux[i]);

                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                if (i == placeToMove[0] && j == placeToMove[1] && moves[i, j] != null)
                                {
                                    if (auxBoard[pieceToMove[0], pieceToMove[1]] != null && (auxBoard[pieceToMove[0], pieceToMove[1]].getSymbol() == 'k' || auxBoard[pieceToMove[0], pieceToMove[1]].getSymbol() == 'K'))
                                        if (j == pieceToMove[1] - 2)
                                        {
                                            auxBoard[i, j + 1] = auxBoard[i, 0];
                                            auxBoard[i, j + 1].move();
                                            auxBoard[i, 0] = null;
                                        }
                                        else if (j == pieceToMove[1] + 2)
                                        {
                                            auxBoard[i, j - 1] = auxBoard[i, 7];
                                            auxBoard[i, j - 1].move();
                                            auxBoard[i, 7] = null;
                                        }
                                    char auxS = auxBoard[pieceToMove[0], pieceToMove[1]].getSymbol();
                                    auxBoard[i, j] = new Piece(auxS, i, j, turn);
                                    auxBoard[i, j].move();
                                    auxBoard[pieceToMove[0], pieceToMove[1]] = null;

                                    if ((auxBoard[i, j].getSymbol() == 'p' || auxBoard[i, j].getSymbol() == 'P') && auxBoard[i, j].getColor() && i == 7)
                                        auxBoard[i, j].ascent();

                                    if (checkInCheck(turn, auxBoard))
                                        goto again;
                                    else
                                    {
                                        wrongInput = false;
                                        board = auxBoard;

                                        if (checkInMate(auxBoard, !turn))
                                            Console.WriteLine("Jaque Mate");
                                    }
                                }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Posición incorrecta");
                        showMoves(pieceToMove[0], pieceToMove[1]);
                    }
                } while (wrongInput);
                wrongInput = true;

                Console.Clear();
                turn = !turn;
            } while (!inCheckMate);
        }
        private bool checkPosition(int x, int y, bool color)
        {
            if ((x >= 0 && x < 8 && y >= 0 && y < 8) && board[x, y] != null && color == board[x, y].getColor())
                return false;

            return true;
        }
        private void show()
        {
            Console.WriteLine("7 6 5 4 3 2 1 0");
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    if (board[i, j] != null && inCheck && ((board[i, j].getSymbol() == 'K' && board[i, j].getColor() == turn) || (board[i, j].getSymbol() == 'k' && board[i, j].getColor() == turn)))
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if ((j + i) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    if (board[i, j] != null)
                        Console.Write("{0} ", board[i, j].getSymbol());
                    else
                        Console.Write("  ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("{0}\n", i);
            }
        }
        private Piece[,] showMoves(int x, int y)
        {
            Console.WriteLine("7 6 5 4 3 2 1 0");
            Piece[,] moves = board[x, y].checkMoves(board);

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    if (moves[i, j] != null && board[i, j] == null)
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    else if (moves[i, j] != null && board[i, j] != null)
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if ((j + i) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    if (board[i, j] != null)
                        Console.Write("{0} ", board[i, j].getSymbol());
                    else
                        Console.Write("  ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("{0}\n", i);
            }

            return moves;
        }
        public bool checkInCheck(bool color, Piece[,] simBoard)
        {
            Piece[,] auxBoard;
            Piece king = findKing(color, simBoard);

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (simBoard[i, j] != null && king.getColor() != simBoard[i, j].getColor())
                    {
                        auxBoard = simBoard[i, j].checkMoves(simBoard);

                        foreach (Piece p in auxBoard)
                        {
                            if (p != null && p.getX() == king.getX() && p.getY() == king.getY())
                            {
                                inCheck = true;
                                return true;
                            }
                        }
                    }

            return false;
        }
        private Piece findKing(bool color, Piece[,] board)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (board[i, j] != null && color && board[i, j].getSymbol() == 'K')
                        return board[i, j];
                    else if (board[i, j] != null && !color && board[i, j].getSymbol() == 'k')
                        return board[i, j];

            return null;
        }
        private bool checkInMate(Piece[,] board, bool color)
        {
            Piece[,] moves;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && color == board[i, j].getColor())
                    {
                        moves = board[i, j].checkMoves(board);

                        foreach (Piece p in moves)
                        {
                            if (p != null)
                            {
                                Piece[,] symBoard = CopyBoard();
                                if (board[i, j].getSymbol() == 'k' || board[i, j].getSymbol() == 'K')
                                    if (p.getY() == j - 2)
                                    {
                                        symBoard[i, j + 1] = symBoard[i, 0];
                                        symBoard[i, j + 1].move();
                                        symBoard[i, 0] = null;
                                    }
                                    else if (p.getY() == j + 2)
                                    {
                                        symBoard[i, j - 1] = symBoard[i, 7];
                                        symBoard[i, j - 1].move();
                                        symBoard[i, 7] = null;
                                    }

                                symBoard[p.getX(), p.getY()] = new Piece(board[i, j].getSymbol(), p.getX(), p.getY(), !turn);
                                symBoard[p.getX(), p.getY()].move();
                                symBoard[i, j] = null;

                                if (!checkInCheck(color, symBoard))
                                {
                                    inCheckMate = false;
                                    return false;
                                }
                            }
                        }
                    }
                }

            inCheckMate = true;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Chess game = new Chess();
            game.begin();
        }
    }
}
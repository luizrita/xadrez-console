using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.linhas; i++) {
                Console.Write((8 - i) + " ");

                for (int j = 0; j < tab.colunas; j++) {
                    Posicao pos = new Posicao(i, j);

                    if (tab.peca(pos) == null) {
                        Console.Write("- ");
                    } else {
                        imprimirPeca(tab.peca(pos));
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branca) {
                Console.Write(peca);
            } else {
                ConsoleColor corAtual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = corAtual;
            }
        }
    }
}

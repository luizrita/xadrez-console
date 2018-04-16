using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write((8 - i) + " ");

                for (int j = 0; j < tab.colunas; j++) {
                    Posicao pos = new Posicao(i, j);
                    imprimirPeca(tab.peca(pos));
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++) {
                Console.Write((8 - i) + " ");

                for (int j = 0; j < tab.colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    Posicao pos = new Posicao(i, j);
                    imprimirPeca(tab.peca(pos));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void imprimirConjunto(HashSet<Peca> pecas) {
            Console.Write("[");

            foreach (Peca peca in pecas) {
                Console.Write(peca + " ");
            }

            Console.Write("]");
        }

        public static void imprimirPecaCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine();
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = atual;
            Console.WriteLine();
        }

        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            imprimirPecaCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);

            if (!partida.terminada) {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                if (partida.xeque) {
                    Console.WriteLine("XEQUE!");
                }
            } else {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("-");
            } else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor corAtual = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = corAtual;
                }
            }

            Console.Write(" ");
        }

        public static Peca selecionarPromocao(Tabuleiro tab, Cor cor) {
            Console.Write("Selecione peça para promoção: (Bispo = B, Cavalo = C, Dama = D, Torre = T): ");
            string p = Console.ReadLine();

            switch (p) {
                case "B":
                    return new Bispo(tab, cor);
                case "C":
                    return new Cavalo(tab, cor);
                case "D":
                    return new Dama(tab, cor);
                case "T":
                    return new Torre(tab, cor);
                default:
                    return new Dama(tab, cor);
            }
        }
    }
}

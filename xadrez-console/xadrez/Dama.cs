using tabuleiro;

namespace xadrez {
    class Dama : Peca {

        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }

        public override string ToString() {
            return "D";
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // N
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.linha = pos.linha - 1;
            }

            // S
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.linha = pos.linha + 1;
            }

            // E
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.coluna = pos.coluna + 1;
            }

            // W
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.coluna = pos.coluna - 1;
            }

            // NW
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            }

            // NE
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            }

            // SE
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            }

            // SW
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }

                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            }

            return mat;
        }
    }
}

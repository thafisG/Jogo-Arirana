using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public bool vez = true;


        public bool vertical = true;
        public bool horizontal = true;
        public bool diagonal = true;


        public int pecasBrancasJaComeu = 0;
        public int pecasPretaJaComeu = 0;
        public int contador = 1;


        public TableLayoutPanelCellPosition posicaoAnterior;
        public TableLayoutPanelCellPosition posicaoFinal;
        TableLayoutPanelCellPosition[] caminho = new TableLayoutPanelCellPosition[30];

        public bool realizarJogada = false;
        public bool aproxOuAfast;
        bool primeiraJogada = false;

        PictureBox botaoAtual = null;












        private void TableEntrada_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void pecas_mouse_down(object sender, MouseEventArgs e)
        {

            PictureBox peca = (PictureBox)sender;

            posicaoAnterior = tableEntrada.GetPositionFromControl(peca);
            if (primeiraJogada == false)
            {
                if (vez == false)
                {
                    if (peca.Tag.ToString() == "cangaco")
                    {
                        peca.DoDragDrop(peca, DragDropEffects.Copy);
                    }
                    else { }
                }
                else
                {
                    if (peca.Tag.ToString() == "policia")
                    {
                        peca.DoDragDrop(peca, DragDropEffects.Copy);
                    }
                    else { }
                }
            }
            else
            {
                if (peca.Tag.ToString() == "selecionada")
                {
                    peca.DoDragDrop(peca, DragDropEffects.Copy);
                }
                else { }
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (vez == true)
            {
                button1.ForeColor = Color.White;
                button1.BackColor = Color.Black;
                botaoAtual.Tag = "policia";
                realizarJogada = true;
                primeiraJogada = false;
                
                for (int i = 0; i <caminho.Length ; i++)
                {
                    caminho[i].Row = -1;
                    caminho[i].Column = -1;
                }
                contador = 1;
                vertical = true;
                horizontal = true;
                diagonal = true;
                vez = false;

            }
            else
            {
                button1.ForeColor = Color.Black;
                button1.BackColor = Color.White;
                botaoAtual.Tag = "cangaco";
                realizarJogada = true;
                primeiraJogada = false;
                for (int i = 0; i < caminho.Length; i++)
                {
                    caminho[i].Row = -1;
                    caminho[i].Column = -1;
                }
                contador = 1;
                vertical = true;
                horizontal = true;
                diagonal = true;
                vez = true;

            }

        }

        private void TableEntrada_DragDrop(object sender, DragEventArgs e)
        {
           


            PictureBox botao = (PictureBox)e.Data.GetData(typeof(PictureBox));
            e.Effect = DragDropEffects.Copy;
            Point loc = tableEntrada.PointToClient(new Point(e.X, e.Y));

          

            int ColumnIndex = -1;
            int RowIndex = -1;
            int x = 0;
            int y = 0;

            while (ColumnIndex <= tableEntrada.ColumnCount)
            {
                if (loc.X < x)
                {
                    break;
                }

                ColumnIndex++;
                x += tableEntrada.GetColumnWidths()[ColumnIndex];
            }

            while (RowIndex <= tableEntrada.RowCount)
            {

                if (loc.Y < y)
                {
                    break;
                }

                RowIndex++;
                y += tableEntrada.GetRowHeights()[RowIndex];
            }

            PictureBox existeBotao = tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex) as PictureBox;
            botaoAtual = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex);
            PictureBox pecaMovida = (PictureBox)tableEntrada.GetControlFromPosition(posicaoAnterior.Column, posicaoAnterior.Row);

            if (primeiraJogada == false)
            {
                caminho[0].Column = posicaoAnterior.Column;
                caminho[0].Row = posicaoAnterior.Row;
                primeiraJogada = true;
            }


            bool permissao = true;
            for (int i = 0; i < 30; i++)
            {
                if (ColumnIndex == caminho[i].Column && caminho[i].Row == RowIndex)
                {
                    MessageBox.Show("Você já passou por aqui");
                    permissao = false;
                    realizarJogada = false;
                    break;
                }
                else
                {
                    permissao = true;
                    realizarJogada = true;
                }
            }

            if (permissao == true)
            {

                if (botaoAtual.Image == null)
                {
                    TableLayoutPanelCellPosition posicaoFinal2 = tableEntrada.GetPositionFromControl(botao);

                    int subtracaoDasColumns = posicaoFinal2.Column - ColumnIndex;
                    int subtracaoDasRows = posicaoFinal2.Row - RowIndex;

                    if (subtracaoDasRows > -2 && subtracaoDasRows < 2 && subtracaoDasColumns > -2 && subtracaoDasColumns < 2)
                    {


                        if (subtracaoDasRows != 0 && subtracaoDasColumns != 0)
                        {

                            if (ColumnIndex == 1 || ColumnIndex == 3 || ColumnIndex == 5 || ColumnIndex == 7)
                            {
                                if (RowIndex == 1 || RowIndex == 3)
                                {
                                    if (diagonal == true)
                                    {
                                        realizarJogada = true;
                                        if (vez == true)
                                        {
                                            diagonal = false;
                                            vertical = true;
                                            horizontal = true;


                                            botaoAtual.BackgroundImage = Properties.Resources.chapeu_poliça_peça;
                                            pecaMovida.BackgroundImage = null;
                                            botaoAtual.Tag = "selecionada";
                                            pecaMovida.Tag = "";
                                            caminho[contador].Row = RowIndex;
                                            caminho[contador].Column = ColumnIndex;
                                            contador++;


                                        }
                                        else
                                        {
                                            diagonal = false;
                                            vertical = true;
                                            horizontal = true;

                                            botaoAtual.BackgroundImage = Properties.Resources.chapeu_canganço_peça1;
                                            pecaMovida.BackgroundImage = null;
                                            botaoAtual.Tag = "selecionada";
                                            pecaMovida.Tag = "";
                                            caminho[contador].Row = RowIndex;
                                            caminho[contador].Column = ColumnIndex;
                                            contador++;


                                        }
                                    }
                                    else { realizarJogada = false; }

                                }
                                else
                                {
                                    realizarJogada = false;
                                }
                            }
                            else if (ColumnIndex == 0 || ColumnIndex == 2 || ColumnIndex == 4 || ColumnIndex == 6 || ColumnIndex == 8)
                            {
                                if (RowIndex == 0 || RowIndex == 2 || RowIndex == 4 && diagonal == true)
                                {
                                    if (diagonal == true)
                                    {
                                        realizarJogada = true;
                                        if (vez == true)
                                        {
                                            diagonal = false;
                                            vertical = true;
                                            horizontal = true;

                                            botaoAtual.BackgroundImage = Properties.Resources.chapeu_poliça_peça;
                                            pecaMovida.BackgroundImage = null;

                                            pecaMovida.Tag = "";

                                            caminho[contador].Row = RowIndex;
                                            caminho[contador].Column = ColumnIndex;
                                            contador++;


                                        }
                                        else
                                        {
                                            diagonal = false;
                                            vertical = true;
                                            horizontal = true;

                                            botaoAtual.BackgroundImage = Properties.Resources.chapeu_canganço_peça1;
                                            pecaMovida.BackgroundImage = null;
                                            botaoAtual.Tag = "selecionada";
                                            pecaMovida.Tag = "";

                                            caminho[contador].Row = RowIndex;
                                            caminho[contador].Column = ColumnIndex;
                                            contador++;



                                        }
                                    }
                                    else { realizarJogada = false; }

                                }
                                else
                                {
                                    realizarJogada = false;
                                }




                            }


                        }
                        else if (subtracaoDasRows != 0 && subtracaoDasColumns == 0 )
                        {
                            if(vertical == true)
                            {
                                realizarJogada = true;
                                if (vez == true)
                                {
                                    diagonal = true;
                                    vertical = false;
                                    horizontal = true;


                                    botaoAtual.BackgroundImage = Properties.Resources.chapeu_poliça_peça;
                                    pecaMovida.BackgroundImage = null;
                                    botaoAtual.Tag = "selecionada";
                                    pecaMovida.Tag = "";


                                    caminho[contador].Row = RowIndex;
                                    caminho[contador].Column = ColumnIndex;
                                    contador++;




                                }
                                else
                                {
                                    diagonal = true;
                                    vertical = false;
                                    horizontal = true;

                                    botaoAtual.BackgroundImage = Properties.Resources.chapeu_canganço_peça1;
                                    pecaMovida.BackgroundImage = null;
                                    botaoAtual.Tag = "selecionada";
                                    pecaMovida.Tag = "";
                                    caminho[contador].Row = RowIndex;
                                    caminho[contador].Column = ColumnIndex;
                                    contador++;


                                }
                               
                            }
                            else
                            {
                                realizarJogada = false;
                            }

                        }
                        else if (subtracaoDasRows == 0 && subtracaoDasColumns != 0)
                        {
                            if(horizontal == true)
                            {
                                realizarJogada = true;
                                if (vez == true)
                                {
                                    diagonal = true;
                                    vertical = true;
                                    horizontal = false;


                                    botaoAtual.BackgroundImage = Properties.Resources.chapeu_poliça_peça;
                                    pecaMovida.BackgroundImage = null;
                                    botaoAtual.Tag = "selecionada";
                                    pecaMovida.Tag = "";


                                    caminho[contador].Row = RowIndex;
                                    caminho[contador].Column = ColumnIndex;
                                    contador++;




                                }
                                else
                                {
                                    diagonal = true;
                                    vertical = true;
                                    horizontal = false;

                                    botaoAtual.BackgroundImage = Properties.Resources.chapeu_canganço_peça1;
                                    pecaMovida.BackgroundImage = null;
                                    botaoAtual.Tag = "selecionada";
                                    pecaMovida.Tag = "";
                                    caminho[contador].Row = RowIndex;
                                    caminho[contador].Column = ColumnIndex;
                                    contador++;


                                }
                            }
                            else
                            {
                                realizarJogada = false;
                            }
                           

                        }



                    }
                    else
                    {
                        MessageBox.Show("erro");
                        realizarJogada = false;

                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    MessageBox.Show("Já existe uma peça nesta posição", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    realizarJogada = false;
                }





                posicaoFinal = tableEntrada.GetPositionFromControl(botao);


                int columns = posicaoAnterior.Column - ColumnIndex;
                int rows = posicaoAnterior.Row - RowIndex;


                if (realizarJogada == true)
                {
                   
                    if (vez == false)
                    {
                
                        if (columns == 0 && rows != 0)
                        {
                            PictureBox verificacaoDoButton = null;
                            if (RowIndex - (rows) >= 0 && RowIndex - (rows) < 5)
                            {
                                verificacaoDoButton = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows));
                            }

                            PictureBox comerAtras = null;
                            if (RowIndex + (rows) + (rows) >= 0 && RowIndex + (rows) + (rows) < 5)
                            {
                                comerAtras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (rows) + (rows));
                            }

                            if (verificacaoDoButton != null && comerAtras != null)
                            {
                                if (verificacaoDoButton.Tag.ToString() == "policia" && comerAtras.Tag.ToString() == "policia")
                                {

                                   
                                    DialogResult aproximacaoOuAfastamento = Escolha.Mostrar();


                                    if (aproximacaoOuAfastamento == DialogResult.No)
                                    {
                                        comerAtras = null;
                                    }
                                    else
                                    {
                                        verificacaoDoButton = null;
                                    }
                                }
                            }

                            if (verificacaoDoButton != null)
                            {
                                if (verificacaoDoButton.Tag.ToString() == "policia")
                                {
                                    pecasPretaJaComeu++;
                                    verificacaoDoButton.BackgroundImage = null;
                                    verificacaoDoButton.Tag = "";
                                    PictureBox verificacao = null;
                                    if (RowIndex - (rows) - (rows) >= 0 && RowIndex - (rows) - (rows) < 5)
                                    {
                                        verificacao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows) - (rows));
                                    }
                                    if (verificacao != null)
                                    {
                                        if (verificacao.Tag.ToString() == "policia")
                                        {
                                            pecasPretaJaComeu++;
                                            verificacao.BackgroundImage = null;
                                            verificacao.Tag = "";
                                            PictureBox temTerceira = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows) - (rows) - (rows));
                                            if (RowIndex - (rows) - (rows) - (rows) >= 0 && RowIndex - (rows) - (rows) - (rows) < 5)
                                            {
                                                temTerceira = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows) - (rows) - (rows));
                                            }

                                            if (temTerceira != null)
                                            {
                                                if (temTerceira.Tag.ToString() == "policia")
                                                {
                                                    pecasPretaJaComeu++;
                                                    temTerceira.BackgroundImage = null;
                                                    temTerceira.Tag = "";
                                                }
                                                else { }
                                            }
                                            else { }

                                        }
                                        else { }
                                    }
                                    else { }
                                }
                                else { }
                            }
                            else
                            { }

                            if (comerAtras != null)
                            {
                                PictureBox comerSegundaPecaTras = null;
                                if (RowIndex + (rows) + (rows) + (rows) >= 0 && RowIndex + (rows) + (rows) + (rows) < 5)
                                {
                                    comerSegundaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (rows) + (rows) + (rows));
                                }

                                if (comerAtras.Tag.ToString() == "policia")
                                {
                                    pecasPretaJaComeu++;
                                    comerAtras.BackgroundImage = null;
                                    comerAtras.Tag = "";
                                    if (comerSegundaPecaTras != null)
                                    {
                                        if (comerSegundaPecaTras.Tag.ToString() == "policia")
                                        {
                                            pecasPretaJaComeu++;
                                            comerSegundaPecaTras.BackgroundImage = null;
                                            comerSegundaPecaTras.Tag = "";
                                            PictureBox comerTerceiraPecaTras = null;
                                            if (RowIndex + (rows) + (rows) + (rows) + (rows) >= 0 && RowIndex + (rows) + (rows) + (rows) + (rows) < 5)
                                            {
                                                comerTerceiraPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (rows) + (rows) + (rows) + (rows));
                                            }
                                            if (comerTerceiraPecaTras != null)
                                            {
                                                if (comerTerceiraPecaTras.Tag.ToString() == "policia")
                                                {
                                                    pecasPretaJaComeu++;
                                                    comerTerceiraPecaTras.BackgroundImage = null;
                                                    comerTerceiraPecaTras.Tag = "";
                                                }
                                            }

                                        }

                                    }

                                }
                                else { }
                            }
                            else { }

                       

                        }



                        else if (columns != 0 && rows != 0)
                        {
                            PictureBox verificacao = null;
                            if (ColumnIndex - (columns) >= 0 && RowIndex - (rows) >= 0 && ColumnIndex - (columns) < 9 && RowIndex - (rows) < 5)
                            {
                                verificacao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns), RowIndex - (rows));
                            }
                            PictureBox comerAtras = null;
                            if (ColumnIndex + (columns) + (columns) >= 0 && RowIndex + (rows) + (rows) >= 0 && ColumnIndex + (columns) + (columns) < 9 && RowIndex + (rows) + (rows) < 5)
                            {
                                comerAtras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns), RowIndex + (rows) + (rows));
                            }




                            if (verificacao != null && comerAtras != null)
                            {
                                if (verificacao.Tag.ToString() == "policia" && comerAtras.Tag.ToString() == "policia")
                                {

                                  
                                    DialogResult resultado = Escolha.Mostrar();


                                    if (resultado == DialogResult.No)
                                    {
                                        comerAtras = null;
                                    }
                                    else
                                    {
                                        verificacao = null;
                                    }
                                }
                            }




                            if (verificacao != null)
                            {
                                if (verificacao.Tag.ToString() == "policia")
                                {
                                    verificacao.BackgroundImage = null;
                                    verificacao.Tag = "";
                                    pecasPretaJaComeu++;


                                    PictureBox comerPecaDaFrente = null;

                                    if (ColumnIndex - (columns) - (columns) >= 0 && RowIndex - (rows) - (rows) >= 0 && ColumnIndex - (columns) - (columns) < 9 && RowIndex - (rows) - (rows) < 5)
                                    {
                                        comerPecaDaFrente = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns), RowIndex - (rows) - (rows));
                                    }
                                    if (comerPecaDaFrente != null)
                                    {
                                        if (comerPecaDaFrente.Tag.ToString() == "policia")
                                        {
                                            comerPecaDaFrente.BackgroundImage = null;
                                            comerPecaDaFrente.Tag = "";

                                            pecasPretaJaComeu++;



                                            PictureBox temTerceira = null;

                                            if (ColumnIndex - (columns) - (columns) - (columns) >= 0 && RowIndex - (rows) - (rows) - (rows) >= 0 && ColumnIndex - (columns) - (columns) - (columns) < 9 && RowIndex - (rows) - (rows) - (rows) < 5)
                                            {
                                                temTerceira = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns), RowIndex - (rows) - (rows) - (rows));

                                            }
                                            if (temTerceira != null)
                                            {
                                                if (temTerceira.Tag.ToString() == "policia")
                                                {
                                                    pecasPretaJaComeu++;
                                                    temTerceira.BackgroundImage = null;
                                                    temTerceira.Tag = "";
                                                }
                                                else { }
                                            }



                                        }
                                        else { }
                                    }


                                }
                                else { }

                            }
                            else { }
                            if (comerAtras != null)
                            {

                                PictureBox comerSegundaPecaTras = null;

                                if (ColumnIndex + (columns) + (columns) + (columns) >= 0 && RowIndex + (rows) + (rows) + (rows) >= 0 && ColumnIndex + (columns) + (columns) + (columns) < 9 && RowIndex + (rows) + (rows) + (rows) < 5)
                                {
                                    comerSegundaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns), RowIndex + (rows) + (rows) + (rows));
                                }
                                else
                                {

                                }

                                if (comerAtras.Tag.ToString() == "policia")

                                {
                                    pecasPretaJaComeu++;

                                    comerAtras.BackgroundImage = null;
                                    comerAtras.Tag = "";
                                    if (comerSegundaPecaTras != null)
                                    {
                                        if (comerSegundaPecaTras.Tag.ToString() == "policia")
                                        {
                                            pecasPretaJaComeu++;
                                            comerSegundaPecaTras.BackgroundImage = null;
                                            comerSegundaPecaTras.Tag = "";
                                            PictureBox comerTerceiraPecaTras = null;
                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) >= 0 && RowIndex + (rows) + (rows) + (rows) + (rows) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) < 9 && RowIndex + (rows) + (rows) + (rows) + (rows) < 5)
                                            {
                                                comerTerceiraPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns), RowIndex + (rows) + (rows) + (rows) + (rows));
                                            }
                                            if (comerTerceiraPecaTras != null)
                                            {
                                                if (comerTerceiraPecaTras.Tag.ToString() == "policia")
                                                {
                                                    pecasPretaJaComeu++;
                                                    comerTerceiraPecaTras.BackgroundImage = null;
                                                    comerTerceiraPecaTras.Tag = "";
                                                }
                                                else { }
                                            }

                                        }
                                        else { }
                                    }

                                }
                                else { }

                            }
                            else { }




                        }





                        else if (columns != 0 && rows == 0)
                        {
                            PictureBox verificacao = null;
                            if (ColumnIndex - (columns) >= 0 && ColumnIndex - (columns) < 9)
                            {
                                verificacao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns), RowIndex);
                            }

                            PictureBox comerAtras = null;
                            if (ColumnIndex + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) < 9)
                            {
                                comerAtras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns), RowIndex);
                            }





                            if (verificacao != null && comerAtras != null)
                            {
                                if (verificacao.Tag.ToString() == "policia" && comerAtras.Tag.ToString() == "policia")
                                {

                                    DialogResult resultado = Escolha.Mostrar();


                                    if (resultado == DialogResult.No)
                                    {
                                        comerAtras = null;
                                    }
                                    else
                                    {
                                        verificacao = null;
                                    }
                                }
                            }


                            if (verificacao != null)
                            {


                                if (verificacao.Tag.ToString() == "policia")
                                {
                                    pecasPretaJaComeu++;
                                    verificacao.BackgroundImage = null;
                                    verificacao.Tag = "";
                                    PictureBox comerSegundaPeca = null;
                                    if (ColumnIndex - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) < 9)
                                    {
                                        comerSegundaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns), RowIndex);
                                    }
                                    if (comerSegundaPeca != null)
                                    {
                                        if (comerSegundaPeca.Tag.ToString() == "policia")
                                        {
                                            pecasPretaJaComeu++;
                                            comerSegundaPeca.BackgroundImage = null;
                                            comerSegundaPeca.Tag = "";
                                            PictureBox comerTerceiraPeca = null;
                                            if (ColumnIndex - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) < 9)
                                            {
                                                comerTerceiraPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns), RowIndex);
                                            }
                                            else { }

                                            if (comerTerceiraPeca != null)
                                            {
                                                if (comerTerceiraPeca.Tag.ToString() == "policia")
                                                {
                                                    pecasPretaJaComeu++;
                                                    comerTerceiraPeca.BackgroundImage = null;
                                                    comerTerceiraPeca.Tag = "";
                                                    PictureBox comerQuartaPeca = null;

                                                    if (ColumnIndex - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) < 9)
                                                    {
                                                        comerQuartaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                    }

                                                    if (comerQuartaPeca != null)
                                                    {
                                                        if (comerQuartaPeca.Tag.ToString() == "policia")
                                                        {
                                                            pecasPretaJaComeu++;
                                                            comerQuartaPeca.BackgroundImage = null;
                                                            comerQuartaPeca.Tag = "";
                                                            PictureBox comerQuintaPeca = null;
                                                            if (ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) < 9)
                                                            {
                                                                comerQuintaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                            }
                                                            else { }

                                                            if (comerQuintaPeca != null)
                                                            {
                                                                if (comerQuintaPeca.Tag.ToString() == "policia")
                                                                {
                                                                    pecasPretaJaComeu++;
                                                                    comerQuintaPeca.BackgroundImage = null;
                                                                    comerQuintaPeca.Tag = "";

                                                                    PictureBox comerSextaPeca = null;


                                                                    if (ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) < 9)
                                                                    {
                                                                        comerSextaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                                    }
                                                                    else { }

                                                                    if (comerSextaPeca != null)
                                                                    {
                                                                        if (comerSextaPeca.Tag.ToString() == "policia")
                                                                        {
                                                                            pecasPretaJaComeu++;
                                                                            comerSextaPeca.BackgroundImage = null;
                                                                            comerSextaPeca.Tag = "";
                                                                            PictureBox comerSetimaPeca = null;

                                                                            if (ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) < 9)
                                                                            {
                                                                                comerSetimaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                                            }
                                                                            else { }

                                                                            if (comerSetimaPeca != null)
                                                                            {
                                                                                if (comerSetimaPeca.Tag.ToString() == "policia")
                                                                                {
                                                                                    pecasPretaJaComeu++;
                                                                                    comerSetimaPeca.BackgroundImage = null;
                                                                                    comerSetimaPeca.Tag = "";

                                                                                }
                                                                                else { }
                                                                            }

                                                                        }
                                                                        else { }
                                                                    }

                                                                }
                                                                else { }
                                                            }

                                                        }
                                                        else { }

                                                    }

                                                }
                                                else { }

                                            }
                                            else { }






                                        }
                                        else { }
                                    }

                                }
                                else { }
                            }
                            else { }
                            if (comerAtras != null)
                            {
                                PictureBox comerSegundaPecaTras = null;
                                if (ColumnIndex + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) < 9)
                                {
                                    comerSegundaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns), RowIndex);
                                }
                                else
                                {

                                }

                                if (comerAtras.Tag.ToString() == "policia")

                                {
                                    pecasPretaJaComeu++;
                                    comerAtras.BackgroundImage = null;
                                    comerAtras.Tag = "";
                                    if (comerSegundaPecaTras != null)
                                    {
                                        if (comerSegundaPecaTras.Tag.ToString() == "policia")
                                        {
                                            pecasPretaJaComeu++;
                                            comerSegundaPecaTras.BackgroundImage = null;
                                            comerSegundaPecaTras.Tag = "";
                                            PictureBox comerTerceiraPecaTras = null;
                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) < 9)
                                            {
                                                comerTerceiraPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns), RowIndex);
                                            }
                                            if (comerTerceiraPecaTras != null)
                                            {
                                                if (comerTerceiraPecaTras.Tag.ToString() == "policia")
                                                {
                                                    pecasPretaJaComeu++;
                                                    comerTerceiraPecaTras.BackgroundImage = null;
                                                    comerTerceiraPecaTras.Tag = "";


                                                    PictureBox comerQuartaPecaTras = null;
                                                    if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                    {
                                                        comerQuartaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                    }
                                                    if (comerQuartaPecaTras != null)
                                                    {
                                                        if (comerQuartaPecaTras.Tag.ToString() == "policia")
                                                        {
                                                            pecasPretaJaComeu++;
                                                            comerQuartaPecaTras.BackgroundImage = null;
                                                            comerQuartaPecaTras.Tag = "";


                                                            PictureBox comerQuintaPecaTras = null;
                                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                            {
                                                                comerQuintaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                            }
                                                            if (comerQuintaPecaTras != null)
                                                            {
                                                                if (comerQuintaPecaTras.Tag.ToString() == "policia")
                                                                {
                                                                    pecasPretaJaComeu++;
                                                                    comerQuintaPecaTras.BackgroundImage = null;
                                                                    comerQuintaPecaTras.Tag = "";


                                                                    PictureBox comerSextaPecaTras = null;
                                                                    if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                                    {
                                                                        comerSextaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                                    }
                                                                    if (comerSextaPecaTras != null)
                                                                    {
                                                                        if (comerSextaPecaTras.Tag.ToString() == "policia")
                                                                        {
                                                                            pecasPretaJaComeu++;
                                                                            comerSextaPecaTras.BackgroundImage = null;
                                                                            comerSextaPecaTras.Tag = "";

                                                                            PictureBox comerSetimaPecaTras = null;
                                                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                                            {
                                                                                comerSetimaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                                            }
                                                                            if (comerSetimaPecaTras != null)
                                                                            {
                                                                                if (comerSetimaPecaTras.Tag.ToString() == "policia")
                                                                                {
                                                                                    pecasPretaJaComeu++;
                                                                                    comerSetimaPecaTras.BackgroundImage = null;
                                                                                    comerSetimaPecaTras.Tag = "";

                                                                                }
                                                                                else { }
                                                                            }

                                                                        }
                                                                        else { }
                                                                    }

                                                                }
                                                                else { }
                                                            }

                                                        }
                                                        else { }
                                                    }


                                                }
                                                else { }
                                            }

                                        }
                                        else { }
                                    }

                                }
                                else { }

                            }
                            else { }


                        }
                        else { }
                        {

                        }


                    }



                    else if (vez == true)
                    {

                        if (columns == 0 && rows != 0)
                        {
                            PictureBox verificacaoDoButton = null;
                            if (RowIndex - (rows) >= 0 && RowIndex - (rows) < 5)
                            {
                                verificacaoDoButton = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows));
                            }

                            PictureBox comerAtras = null;
                            if (RowIndex + (rows) + (rows) >= 0 && RowIndex + (rows) + (rows) < 5)
                            {
                                comerAtras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (rows) + (rows));
                            }

                            if (verificacaoDoButton != null && comerAtras != null)
                            {
                                if (verificacaoDoButton.Tag.ToString() == "cangaco" && comerAtras.Tag.ToString() == "cangaco")
                                {

                                    DialogResult aproximacaoOuAfastamento = Escolha.Mostrar();


                                    if (aproximacaoOuAfastamento == DialogResult.No)
                                    {
                                        comerAtras = null;
                                    }
                                    else
                                    {
                                        verificacaoDoButton = null;
                                    }
                                }
                            }




                     
                            if (verificacaoDoButton != null)
                            {
                                if (verificacaoDoButton.Tag.ToString() == "cangaco")
                                {
                                    pecasBrancasJaComeu++;
                                    verificacaoDoButton.BackgroundImage = null;
                                    verificacaoDoButton.Tag = "";
                                    PictureBox verificacao = null;
                                    if (RowIndex - (rows) - (rows) >= 0 && RowIndex - (rows) - (rows) < 5)
                                    {
                                        verificacao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows) - (rows));
                                    }
                                    if (verificacao != null)
                                    {
                                        if (verificacao.Tag.ToString() == "cangaco")
                                        {
                                            pecasBrancasJaComeu++;
                                            verificacao.BackgroundImage = null;
                                            verificacao.Tag = "";
                                            PictureBox temTerceira = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows) - (rows) - (rows));
                                            if (RowIndex - (rows) - (rows) - (rows) >= 0 && RowIndex - (rows) - (rows) - (rows) < 5)
                                            {
                                                temTerceira = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (rows) - (rows) - (rows));
                                            }

                                            if (temTerceira != null)
                                            {
                                                if (temTerceira.Tag.ToString() == "cangaco")
                                                {
                                                    pecasBrancasJaComeu++;
                                                    temTerceira.BackgroundImage = null;
                                                    temTerceira.Tag = "";
                                                }
                                                else { }
                                            }
                                            else { }

                                        }
                                        else { }
                                    }
                                    else { }
                                }
                                else { }
                            }
                            else
                            { }


                            if (comerAtras != null)
                            {
                                PictureBox comerSegundaPecaTras = null;
                                if (RowIndex + (rows) + (rows) + (rows) >= 0 && RowIndex + (rows) + (rows) + (rows) < 5)
                                {
                                    comerSegundaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (rows) + (rows) + (rows));
                                }

                                if (comerAtras.Tag.ToString() == "cangaco")
                                {
                                    pecasBrancasJaComeu++;
                                    comerAtras.BackgroundImage = null;
                                    comerAtras.Tag = "";
                                    if (comerSegundaPecaTras != null)
                                    {
                                        if (comerSegundaPecaTras.Tag.ToString() == "cangaco")
                                        {
                                            pecasBrancasJaComeu++;
                                            comerSegundaPecaTras.BackgroundImage = null;
                                            comerSegundaPecaTras.Tag = "";
                                            PictureBox comerTerceiraPecaTras = null;
                                            if (RowIndex + (rows) + (rows) + (rows) + (rows) >= 0 && RowIndex + (rows) + (rows) + (rows) + (rows) < 5)
                                            {
                                                comerTerceiraPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (rows) + (rows) + (rows) + (rows));
                                            }
                                            if (comerTerceiraPecaTras != null)
                                            {
                                                if (comerTerceiraPecaTras.Tag.ToString() == "cangaco")
                                                {
                                                    pecasBrancasJaComeu++;
                                                    comerTerceiraPecaTras.BackgroundImage = null;
                                                    comerTerceiraPecaTras.Tag = "";
                                                }
                                            }

                                        }

                                    }

                                }
                                else { }
                            }
                            else { }


                        }

                        else if (columns != 0 && rows != 0)
                        {
                            PictureBox verificacao = null;
                            if (ColumnIndex - (columns) >= 0 && RowIndex - (rows) >= 0 && ColumnIndex - (columns) < 9 && RowIndex - (rows) < 5)
                            {
                                verificacao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns), RowIndex - (rows));
                            }
                            PictureBox comerAtras = null;
                            if (ColumnIndex + (columns) + (columns) >= 0 && RowIndex + (rows) + (rows) >= 0 && ColumnIndex + (columns) + (columns) < 9 && RowIndex + (rows) + (rows) < 5)
                            {
                                comerAtras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns), RowIndex + (rows) + (rows));
                            }




                            if (verificacao != null && comerAtras != null)
                            {
                                if (verificacao.Tag.ToString() == "cangaco" && comerAtras.Tag.ToString() == "cangaco")
                                {

                                    DialogResult resultado = Escolha.Mostrar();


                                    if (resultado == DialogResult.No)
                                    {
                                        comerAtras = null;
                                    }
                                    else
                                    {
                                        verificacao = null;
                                    }
                                }
                            }

                            if (verificacao != null)
                            {
                                if (verificacao.Tag.ToString() == "cangaco")
                                {
                                    verificacao.BackgroundImage = null;
                                    verificacao.Tag = "";
                                    pecasBrancasJaComeu++;


                                    PictureBox comerPecaDaFrente = null;

                                    if (ColumnIndex - (columns) - (columns) >= 0 && RowIndex - (rows) - (rows) >= 0 && ColumnIndex - (columns) - (columns) < 9 && RowIndex - (rows) - (rows) < 5)
                                    {
                                        comerPecaDaFrente = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns), RowIndex - (rows) - (rows));
                                    }
                                    if (comerPecaDaFrente != null)
                                    {
                                        if (comerPecaDaFrente.Tag.ToString() == "cangaco")
                                        {
                                            comerPecaDaFrente.BackgroundImage = null;
                                            comerPecaDaFrente.Tag = "";

                                            pecasBrancasJaComeu++;



                                            PictureBox temTerceira = null;

                                            if (ColumnIndex - (columns) - (columns) - (columns) >= 0 && RowIndex - (rows) - (rows) - (rows) >= 0 && ColumnIndex - (columns) - (columns) - (columns) < 9 && RowIndex - (rows) - (rows) - (rows) < 5)
                                            {
                                                temTerceira = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns), RowIndex - (rows) - (rows) - (rows));

                                            }
                                            if (temTerceira != null)
                                            {
                                                if (temTerceira.Tag.ToString() == "cangaco")
                                                {
                                                    pecasBrancasJaComeu++;
                                                    temTerceira.BackgroundImage = null;
                                                    temTerceira.Tag = "";
                                                }
                                                else { }
                                            }



                                        }
                                        else { }
                                    }


                                }
                                else { }

                            }
                            else { }
                            if (comerAtras != null)
                            {

                                PictureBox comerSegundaPecaTras = null;

                                if (ColumnIndex + (columns) + (columns) + (columns) >= 0 && RowIndex + (rows) + (rows) + (rows) >= 0 && ColumnIndex + (columns) + (columns) + (columns) < 9 && RowIndex + (rows) + (rows) + (rows) < 5)
                                {
                                    comerSegundaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns), RowIndex + (rows) + (rows) + (rows));
                                }
                                else
                                {

                                }

                                if (comerAtras.Tag.ToString() == "cangaco")

                                {
                                    pecasBrancasJaComeu++;
                                    comerAtras.BackgroundImage = null;
                                    comerAtras.Tag = "";
                                    if (comerSegundaPecaTras != null)
                                    {
                                        if (comerSegundaPecaTras.Tag.ToString() == "cangaco")
                                        {
                                            pecasBrancasJaComeu++;
                                            comerSegundaPecaTras.BackgroundImage = null;
                                            comerSegundaPecaTras.Tag = "";
                                            PictureBox comerTerceiraPecaTras = null;
                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) >= 0 && RowIndex + (rows) + (rows) + (rows) + (rows) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) < 9 && RowIndex + (rows) + (rows) + (rows) + (rows) < 5)
                                            {
                                                comerTerceiraPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns), RowIndex + (rows) + (rows) + (rows) + (rows));
                                            }
                                            if (comerTerceiraPecaTras != null)
                                            {
                                                if (comerTerceiraPecaTras.Tag.ToString() == "cangaco")
                                                {
                                                    pecasBrancasJaComeu++;
                                                    comerTerceiraPecaTras.BackgroundImage = null;
                                                    comerTerceiraPecaTras.Tag = "";
                                                }
                                                else { }
                                            }

                                        }
                                        else { }
                                    }

                                }
                                else { }

                            }
                            else { }



                        }



                        else if (columns != 0 && rows == 0)
                        {
                            PictureBox verificacao = null;
                            if (ColumnIndex - (columns) >= 0 && ColumnIndex - (columns) < 9)
                            {
                                verificacao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns), RowIndex);
                            }

                            PictureBox comerAtras = null;
                            if (ColumnIndex + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) < 9)
                            {
                                comerAtras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns), RowIndex);
                            }





                            if (verificacao != null && comerAtras != null)
                            {
                                if (verificacao.Tag.ToString() == "cangaco" && comerAtras.Tag.ToString() == "cangaco")
                                {

                                    DialogResult resultado = Escolha.Mostrar();


                                    if (resultado == DialogResult.No)
                                    {
                                        comerAtras = null;
                                    }
                                    else
                                    {
                                        verificacao = null;
                                    }
                                }
                            }

                            if (verificacao != null)
                            {


                                if (verificacao.Tag.ToString() == "cangaco")
                                {
                                    pecasBrancasJaComeu++;
                                    verificacao.BackgroundImage = null;
                                    verificacao.Tag = "";
                                    PictureBox comerSegundaPeca = null;
                                    if (ColumnIndex - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) < 9)
                                    {
                                        comerSegundaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns), RowIndex);
                                    }
                                    if (comerSegundaPeca != null)
                                    {
                                        if (comerSegundaPeca.Tag.ToString() == "cangaco")
                                        {
                                            pecasBrancasJaComeu++;
                                            comerSegundaPeca.BackgroundImage = null;
                                            comerSegundaPeca.Tag = "";
                                            PictureBox comerTerceiraPeca = null;
                                            if (ColumnIndex - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) < 9)
                                            {
                                                comerTerceiraPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns), RowIndex);
                                            }
                                            else { }

                                            if (comerTerceiraPeca != null)
                                            {
                                                if (comerTerceiraPeca.Tag.ToString() == "cangaco")
                                                {
                                                    pecasBrancasJaComeu++;
                                                    comerTerceiraPeca.BackgroundImage = null;
                                                    comerTerceiraPeca.Tag = "";
                                                    PictureBox comerQuartaPeca = null;

                                                    if (ColumnIndex - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) < 9)
                                                    {
                                                        comerQuartaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                    }

                                                    if (comerQuartaPeca != null)
                                                    {
                                                        if (comerQuartaPeca.Tag.ToString() == "cangaco")
                                                        {
                                                            pecasBrancasJaComeu++;
                                                            comerQuartaPeca.BackgroundImage = null;
                                                            comerQuartaPeca.Tag = "";
                                                            PictureBox comerQuintaPeca = null;
                                                            if (ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) < 9)
                                                            {
                                                                comerQuintaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                            }
                                                            else { }

                                                            if (comerQuintaPeca != null)
                                                            {
                                                                if (comerQuintaPeca.Tag.ToString() == "cangaco")
                                                                {
                                                                    pecasBrancasJaComeu++;
                                                                    comerQuintaPeca.BackgroundImage = null;
                                                                    comerQuintaPeca.Tag = "";

                                                                    PictureBox comerSextaPeca = null;


                                                                    if (ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) < 9)
                                                                    {
                                                                        comerSextaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                                    }
                                                                    else { }

                                                                    if (comerSextaPeca != null)
                                                                    {
                                                                        if (comerSextaPeca.Tag.ToString() == "cangaco")
                                                                        {
                                                                            pecasBrancasJaComeu++;
                                                                            comerSextaPeca.BackgroundImage = null;
                                                                            comerSextaPeca.Tag = "";
                                                                            PictureBox comerSetimaPeca = null;

                                                                            if (ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) >= 0 && ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) < 9)
                                                                            {
                                                                                comerSetimaPeca = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (columns) - (columns) - (columns) - (columns) - (columns) - (columns) - (columns), RowIndex);
                                                                            }
                                                                            else { }

                                                                            if (comerSetimaPeca != null)
                                                                            {
                                                                                if (comerSetimaPeca.Tag.ToString() == "cangaco")
                                                                                {
                                                                                    pecasBrancasJaComeu++;
                                                                                    comerSetimaPeca.BackgroundImage = null;
                                                                                    comerSetimaPeca.Tag = "";

                                                                                }
                                                                                else { }
                                                                            }

                                                                        }
                                                                        else { }
                                                                    }

                                                                }
                                                                else { }
                                                            }

                                                        }
                                                        else { }

                                                    }

                                                }
                                                else { }

                                            }
                                            else { }






                                        }
                                        else { }
                                    }

                                }
                                else { }
                            }
                            else { }
                            if (comerAtras != null)
                            {
                                PictureBox comerSegundaPecaTras = null;
                                if (ColumnIndex + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) < 9)
                                {
                                    comerSegundaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns), RowIndex);
                                }
                                else
                                {

                                }

                                if (comerAtras.Tag.ToString() == "cangaco")

                                {
                                    pecasBrancasJaComeu++;
                                    comerAtras.BackgroundImage = null;
                                    comerAtras.Tag = "";
                                    if (comerSegundaPecaTras != null)
                                    {
                                        if (comerSegundaPecaTras.Tag.ToString() == "cangaco")
                                        {
                                            pecasBrancasJaComeu++;
                                            comerSegundaPecaTras.BackgroundImage = null;
                                            comerSegundaPecaTras.Tag = "";
                                            PictureBox comerTerceiraPecaTras = null;
                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) < 9)
                                            {
                                                comerTerceiraPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns), RowIndex);
                                            }
                                            if (comerTerceiraPecaTras != null)
                                            {
                                                if (comerTerceiraPecaTras.Tag.ToString() == "cangaco")
                                                {
                                                    pecasBrancasJaComeu++;
                                                    comerTerceiraPecaTras.BackgroundImage = null;
                                                    comerTerceiraPecaTras.Tag = "";


                                                    PictureBox comerQuartaPecaTras = null;
                                                    if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                    {
                                                        comerQuartaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                    }
                                                    if (comerQuartaPecaTras != null)
                                                    {
                                                        if (comerQuartaPecaTras.Tag.ToString() == "cangaco")
                                                        {
                                                            pecasBrancasJaComeu++;
                                                            comerQuartaPecaTras.BackgroundImage = null;
                                                            comerQuartaPecaTras.Tag = "";


                                                            PictureBox comerQuintaPecaTras = null;
                                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                            {
                                                                comerQuintaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                            }
                                                            if (comerQuintaPecaTras != null)
                                                            {
                                                                if (comerQuintaPecaTras.Tag.ToString() == "cangaco")
                                                                {
                                                                    pecasBrancasJaComeu++;
                                                                    comerQuintaPecaTras.BackgroundImage = null;
                                                                    comerQuintaPecaTras.Tag = "";


                                                                    PictureBox comerSextaPecaTras = null;
                                                                    if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                                    {
                                                                        comerSextaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                                    }
                                                                    if (comerSextaPecaTras != null)
                                                                    {
                                                                        if (comerSextaPecaTras.Tag.ToString() == "cangaco")
                                                                        {
                                                                            pecasBrancasJaComeu++;
                                                                            comerSextaPecaTras.BackgroundImage = null;
                                                                            comerSextaPecaTras.Tag = "";

                                                                            PictureBox comerSetimaPecaTras = null;
                                                                            if (ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) >= 0 && ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) < 9)
                                                                            {
                                                                                comerSetimaPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns) + (columns), RowIndex);
                                                                            }
                                                                            if (comerSetimaPecaTras != null)
                                                                            {
                                                                                if (comerSetimaPecaTras.Tag.ToString() == "cangaco")
                                                                                {
                                                                                    pecasBrancasJaComeu++;
                                                                                    comerSetimaPecaTras.BackgroundImage = null;
                                                                                    comerSetimaPecaTras.Tag = "";

                                                                                }
                                                                                else { }
                                                                            }

                                                                        }
                                                                        else { }
                                                                    }

                                                                }
                                                                else { }
                                                            }

                                                        }
                                                        else { }
                                                    }


                                                }
                                                else { }
                                            }

                                        }
                                        else { }
                                    }

                                }
                                else { }

                            }
                            else { }



                        }
                        else { }
                        {

                        }



                    }




                    if (pecasBrancasJaComeu == 22)
                    {
                        MessageBox.Show("A POLÍCIA VENCEU!!!");
                        Application.Restart();

                    }
                    else if (pecasPretaJaComeu == 22)
                    {
                        MessageBox.Show("O CANGAÇO VENCEU!!!");
                        Application.Restart();
                    }



                }


            }

        }


        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}

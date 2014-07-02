﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoBr.Bancos.Hsbc;
using BoletoBr.Dominio.CodigoMovimento;

namespace BoletoBr.Dominio.CodigoRejeicao
{
    public enum EnumCodigoRejeicaoHsbc
    {
        /* Código de Rejeição de 1 a 151 */
        RegistroForaDeSequencia = 1,
        RegistroDuplicado = 2,
        TipoDeRegistroInvalido = 3,
        RegistroNaoPertenceAEstaPlanilha = 4,
        BduDoBeneficiarioNaoNumerico = 5,
        BduDoBeneficiarioNaoInformado = 6,
        BduDoBeneficiarioInexistente = 7,
        CodigoBeneficiarioNaoInformado = 8,
        CodigoBeneficiarioNaoNumerico = 9,
        CodigoBeneficiarioZerado = 10,
        CodigoBeneficiarioInexistente = 11,
        CodigoFormularioNaoInformado = 12,
        CodigoFormularioInexistente = 13,
        InformarCodBeneficiario = 15,
        InformarDataVencimentoParcelaUnicaOuDataPrimeiroVencimento = 16,
        InformarValorParcelaUnicaOuValorDasParcelas = 17,
        InformarTipoDaMoeda = 18,
        InformarCodigoDocumento = 19,
        PeriodicidadeDeVencimentoInvalida = 22,
        TipodeMontagemInvalido = 23,
        TipoDeMontagemNaoInformado = 24,
        QuantidadeDeCarnesInvalida = 25,
        QuantidadeDeCarnesNaoInformada = 26,
        NumeroParcelaDeInvalido = 27,
        NumeroParcelaDeNaoInformado = 28,
        NumeroParcelaAteInvalido = 29,


    }

    public class CodigoRejeicaoHsbc : AbstractCodigoRejeicao, ICodigoRejeicao
    {
        #region Construtores

        public CodigoRejeicaoHsbc(int codigo)
        {
            try
            {
                this.carregar(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        #endregion

        #region Metodos Privados

        private void carregar(int codigo)
        {
            try
            {
                this.Banco = new BancoHsbc();

                switch ((EnumCodigoRejeicaoHsbc) codigo)
                {
                    //case EnumCodigoMovimentoCaixa.EntradaConfirmada:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.EntradaConfirmada;
                    //    this.Descricao = "Entrada confirmada";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.EntradaRejeitada:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.EntradaRejeitada;
                    //    this.Descricao = "Entrada rejeitada";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.TransferenciaCarteiraEntrada:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.TransferenciaCarteiraEntrada;
                    //    this.Descricao = "Transferência de carteira/entrada";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.TransferenciaCarteiraBaixa:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.TransferenciaCarteiraBaixa;
                    //    this.Descricao = "Transferência de carteira/baixa";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.Liquidacao:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.Liquidacao;
                    //    this.Descricao = "Liquidação normal";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.Baixa:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.Baixa;
                    //    this.Descricao = "Baixa";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.TitulosCarteiraEmSer:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.TitulosCarteiraEmSer;
                    //    this.Descricao = "Títulos em carteira em ser";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoAbatimento:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoAbatimento;
                    //    this.Descricao = "Confirmação recebimento instrução de abatimento";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoCancelamentoAbatimento:
                    //    this.Codigo =
                    //        (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoCancelamentoAbatimento;
                    //    this.Descricao = "Confirmação recebimento instrução de cancelamento de abatimento";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoAlteracaoVencimento:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoAlteracaoVencimento;
                    //    this.Descricao = "Confirmação recebimento instrução alteração de vencimento";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.FrancoPagamento:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.FrancoPagamento;
                    //    this.Descricao = "Franco pagamento";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.LiquidacaoAposBaixa:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.LiquidacaoAposBaixa;
                    //    this.Descricao = "Liquidação após baixa";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoProtesto:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoProtesto;
                    //    this.Descricao = "Confirmação de recebimento de instrução de protesto";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoSustacaoProtesto:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoSustacaoProtesto;
                    //    this.Descricao = "Confirmação de recebimento de instrução de sustação de protesto";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.RemessaCartorio:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.RemessaCartorio;
                    //    this.Descricao = "Remessa a cartório/aponte em cartório";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.RetiradaCartorioManutencaoCarteira:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.RetiradaCartorioManutencaoCarteira;
                    //    this.Descricao = "Retirada de cartório e manutenção em carteira";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ProtestadoBaixado:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ProtestadoBaixado;
                    //    this.Descricao = "Protestado e baixado/baixa por ter sido protestado";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.InstrucaoRejeitada:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.InstrucaoRejeitada;
                    //    this.Descricao = "Instrução rejeitada";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.ConfirmaçãoPedidoAlteracaoOutrosDados:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmaçãoPedidoAlteracaoOutrosDados;
                    //    this.Descricao = "Confirmação do pedido de alteração de outros dados";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.DebitoTarifas:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.DebitoTarifas;
                    //    this.Descricao = "Debito de tarifas/custas";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.OcorrenciaSacado:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.OcorrenciaSacado;
                    //    this.Descricao = "Ocorrencias do sacado";
                    //    break;
                    //case EnumCodigoMovimentoCaixa.AlteracaoDadosRejeitada:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.AlteracaoDadosRejeitada;
                    //    this.Descricao = "Alteração de dados rejeitada";
                    //    break;
                    //default:
                    //    this.Codigo = 0;
                    //    this.Descricao = "( Selecione )";
                    //    break;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        private void Ler(int codigo)
        {
            try
            {
                switch (codigo)
                {
                    //case 2:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.EntradaConfirmada;
                    //    this.Descricao = "Entrada confirmada";
                    //    break;
                    //case 3:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.EntradaRejeitada;
                    //    this.Descricao = "Entrada rejeitada";
                    //    break;
                    //case 4:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.TransferenciaCarteiraEntrada;
                    //    this.Descricao = "Transferência de carteira/entrada";
                    //    break;
                    //case 5:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.TransferenciaCarteiraBaixa;
                    //    this.Descricao = "Transferência de carteira/baixa";
                    //    break;
                    //case 6:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.Liquidacao;
                    //    this.Descricao = "Liquidação";
                    //    break;
                    //case 9:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.Baixa;
                    //    this.Descricao = "Baixa";
                    //    break;
                    //case 11:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.TitulosCarteiraEmSer;
                    //    this.Descricao = "Títulos em carteira em ser";
                    //    break;
                    //case 12:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoAbatimento;
                    //    this.Descricao = "Confirmação recebimento instrução de abatimento";
                    //    break;
                    //case 13:
                    //    this.Codigo =
                    //        (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoCancelamentoAbatimento;
                    //    this.Descricao = "Confirmação recebimento instrução de cancelamento de abatimento";
                    //    break;
                    //case 14:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoAlteracaoVencimento;
                    //    this.Descricao = "Confirmação recebimento instrução alteração de vencimento";
                    //    break;
                    //case 15:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.FrancoPagamento;
                    //    this.Descricao = "Franco pagamento";
                    //    break;
                    //case 17:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.LiquidacaoAposBaixa;
                    //    this.Descricao = "Liquidação após baixa";
                    //    break;
                    //case 19:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoProtesto;
                    //    this.Descricao = "Confirmação de recebimento de instrução de protesto";
                    //    break;
                    //case 20:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmacaoRecebimentoInstrucaoSustacaoProtesto;
                    //    this.Descricao = "Confirmação de recebimento de instrução de sustação de protesto";
                    //    break;
                    //case 23:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.RemessaCartorio;
                    //    this.Descricao = "Remessa a cartório/aponte em cartório";
                    //    break;
                    //case 24:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.RetiradaCartorioManutencaoCarteira;
                    //    this.Descricao = "Retirada de cartório e manutenção em carteira";
                    //    break;
                    //case 25:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ProtestadoBaixado;
                    //    this.Descricao = "Protestado e baixado/baixa por ter sido protestado";
                    //    break;
                    //case 26:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.InstrucaoRejeitada;
                    //    this.Descricao = "Instrução rejeitada";
                    //    break;
                    //case 27:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.ConfirmaçãoPedidoAlteracaoOutrosDados;
                    //    this.Descricao = "Confirmação do pedido de alteração de outros dados";
                    //    break;
                    //case 28:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.DebitoTarifas;
                    //    this.Descricao = "Debito de tarifas/custas";
                    //    break;
                    //case 29:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.OcorrenciaSacado;
                    //    this.Descricao = "Ocorrencias do sacado";
                    //    break;
                    //case 30:
                    //    this.Codigo = (int) EnumCodigoMovimentoCaixa.AlteracaoDadosRejeitada;
                    //    this.Descricao = "Alteração de dados rejeitada";
                    //    break;
                    //default:
                    //    this.Codigo = 0;
                    //    this.Descricao = "( Selecione )";
                    //    break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        #endregion
    }
}

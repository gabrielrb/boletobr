﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoletoBr.Arquivo;
using BoletoBr.Bancos.Bradesco;
using BoletoBr.Bancos.Cef;
using BoletoBr.Dominio;
using BoletoBr.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoBr.UnitTests.TestsBancosRemessa
{
    [TestClass]
    public class TestRemessaBradesco
    {
        [TestMethod]
        public void TestFormataSacadorAvalistaGeracaoRemessaBradescoCnab400()
        {
            // Posição 335 - 394

            const string nome = "SACADOR AVALISTA";
            const string cpfCnpj = "999.999.999-11";
            //const string cpfCnpj = "99.999.999/0001-99";
            var str = string.Empty;

            if (cpfCnpj.Replace(".", "").Replace("/", "").Replace("-", "").Length == 11)
            {
                str = (nome.ToUpper() +
                    string.Empty.PadLeft(2, ' ') +
                    cpfCnpj.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 9) +
                    string.Empty.PadLeft(4, '0') +
                    cpfCnpj.Replace(".", "").Replace("/", "").Replace("-", "").Substring(9, 2)).PadLeft(60, ' ');
            }
            else
            {
                str = (nome.ToUpper() +
                    string.Empty.PadLeft(2, ' ') +
                    cpfCnpj.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(15, '0')).PadLeft(60,' ');
            }

            const string valorEsperado = "                           SACADOR AVALISTA  999999999000011";
            //const string valorEsperado = "                           SACADOR AVALISTA  099999999000199";
            Assert.AreEqual(valorEsperado.Length, str.Length);
            Assert.AreEqual(valorEsperado, str);
        }

        [TestMethod]
        public void TestGerarHeaderArquivoRemessaBradescoCnab400()
        {
            var remessa = new Remessa(Remessa.EnumTipoAmbiemte.Homologacao, EnumCodigoOcorrenciaRemessa.Registro, "2");

            var banco = Fabricas.BancoFactory.ObterBanco("237", "2");

            var contaBancariaCedente = new ContaBancaria("1234", "8", "12345", "6");

            var cedente = new Cedente("99999", "1", 0, "99.999.999/9999-99", "Razao Social X", contaBancariaCedente, null);

            var sacado = new Sacado("Sacado Fulano de Tal", "99.999.999/9999-99", new Endereco()
            {
                TipoLogradouro = "R",
                Logradouro = "1",
                Bairro = "Bairro X",
                Cidade = "Cidade X",
                SiglaUf = "XX",
                Cep = "12345-000",
                Complemento = "Comp X",
                Numero = "9"
            });

            var carteira = new CarteiraCobranca { Codigo = "06" };

            var boleto = new Boleto(carteira, cedente, sacado, remessa)
            {
                NumeroDocumento = "3242",
                ValorBoleto = Convert.ToDecimal(275),
                SequencialNossoNumero = "3242",
                DataVencimento = new DateTime(2014, 08, 04),
                Especie = banco.ObtemEspecieDocumento(EnumEspecieDocumento.DuplicataMercantil)
            };

            banco.FormatarBoleto(boleto);

            const int numeroRemessa = 1;
            const int numeroRegistro = 1;

            var escritor = new EscritorRemessaCnab400Bradesco();

            var linhasEscrever = escritor.EscreverHeader(boleto, numeroRemessa, numeroRegistro);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var data = DateTime.Now.ToString("d").Replace("/", "");

            var nomeArquivo = string.Format("{0}{1}{2}{3}{4}{5}{6}", banco.CodigoBanco, "-", banco.NomeBanco, "_", data, @"_HEADER", ".txt");

            var arquivo = new System.IO.StreamWriter(path + @"\" + nomeArquivo, true);
            arquivo.WriteLine(linhasEscrever);

            arquivo.Close();
        }

        [TestMethod]
        public void TestGerarDetalheArquivoRemessaBradescoCnab400()
        {
            var remessa = new Remessa(Remessa.EnumTipoAmbiemte.Homologacao, EnumCodigoOcorrenciaRemessa.Registro, "2");

            var banco = Fabricas.BancoFactory.ObterBanco("237", "2");

            var contaBancariaCedente = new ContaBancaria("1234", "8", "12345", "6");

            var cedente = new Cedente("99999", "1", 0, "99.999.999/9999-99", "Razao Social X", contaBancariaCedente, null);

            var sacado = new Sacado("Sacado Fulano de Tal", "99.999.999/9999-99", new Endereco()
            {
                TipoLogradouro = "R",
                Logradouro = "1",
                Bairro = "Bairro X",
                Cidade = "Cidade X",
                SiglaUf = "XX",
                Cep = "12345-000",
                Complemento = "Comp X",
                Numero = "9"
            });

            var carteira = new CarteiraCobranca { Codigo = "06" };

            var boleto = new Boleto(carteira, cedente, sacado, remessa)
            {
                NumeroDocumento = "3242",
                ValorBoleto = Convert.ToDecimal(275),
                SequencialNossoNumero = "3242",
                DataVencimento = new DateTime(2014, 08, 04),
                Especie = banco.ObtemEspecieDocumento(EnumEspecieDocumento.DuplicataMercantil),
                CodigoOcorrenciaRemessa = new CodigoOcorrencia(01),
            };

            banco.FormatarBoleto(boleto);

            const int numeroRegistro = 1;

            var escritor = new EscritorRemessaCnab400Bradesco();

            var linhasEscrever = escritor.EscreverDetalhe(boleto, numeroRegistro);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var data = DateTime.Now.ToString("d").Replace("/", "");

            var nomeArquivo = string.Format("{0}{1}{2}{3}{4}{5}{6}", banco.CodigoBanco, "-", banco.NomeBanco, "_", data, @"_REGISTRO_DETALHE", ".txt");

            var arquivo = new System.IO.StreamWriter(path + @"\" + nomeArquivo, true);
            arquivo.WriteLine(linhasEscrever);

            arquivo.Close();
        }

        [TestMethod]
        public void TestGerarTrailerArquivoRemessaBradescoCnab400()
        {
            var remessa = new Remessa(Remessa.EnumTipoAmbiemte.Homologacao, EnumCodigoOcorrenciaRemessa.Registro, "2");

            var banco = Fabricas.BancoFactory.ObterBanco("237", "2");

            var contaBancariaCedente = new ContaBancaria("1234", "8", "12345", "6");

            var cedente = new Cedente("99999", "1", 0, "99.999.999/9999-99", "Razao Social X", contaBancariaCedente, null);

            var sacado = new Sacado("Sacado Fulano de Tal", "99.999.999/9999-99", new Endereco()
            {
                TipoLogradouro = "R",
                Logradouro = "1",
                Bairro = "Bairro X",
                Cidade = "Cidade X",
                SiglaUf = "XX",
                Cep = "12345-000",
                Complemento = "Comp X",
                Numero = "9"
            });

            var carteira = new CarteiraCobranca { Codigo = "06" };

            var boleto = new Boleto(carteira, cedente, sacado, remessa)
            {
                NumeroDocumento = "3242",
                ValorBoleto = Convert.ToDecimal(275),
                SequencialNossoNumero = "3242",
                DataVencimento = new DateTime(2014, 08, 04),
                Especie = banco.ObtemEspecieDocumento(EnumEspecieDocumento.DuplicataMercantil),
                CodigoOcorrenciaRemessa = new CodigoOcorrencia(01),
            };

            banco.FormatarBoleto(boleto);

            const int numeroRegistro = 1;

            var escritor = new EscritorRemessaCnab400Bradesco();

            var linhasEscrever = escritor.EscreverTrailer(numeroRegistro);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var data = DateTime.Now.ToString("d").Replace("/", "");

            var nomeArquivo = string.Format("{0}{1}{2}{3}{4}{5}{6}", banco.CodigoBanco, "-", banco.NomeBanco, "_", data, @"_TRAILER", ".txt");

            var arquivo = new System.IO.StreamWriter(path + @"\" + nomeArquivo, true);
            arquivo.WriteLine(linhasEscrever);

            arquivo.Close();
        }
    }
}
using e_Agenda.Controladores;
using e_Agenda.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using UnitTestProject.Extensions;

namespace UnitTestProject.Compromissos
{
    [TestClass]
    public class TestesCompromissos
    {
        ControladorCompromissos ccomp;
        Contato c;
        Compromisso comp;

        [TestInitialize]
        public void adicionarCompromisso()
        {
            c = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev");
            new ControladorContatos().inserir(c);
            comp = new Compromisso("Aula ADP", "google meet", new DateTime(2021, 06, 28, 13, 30, 0), new DateTime(2021, 06, 28, 17, 30, 0), c);
            
            ccomp = new ControladorCompromissos();
            ccomp.inserir(comp);
        }

        [TestMethod]
        public void inserirCompromisso()
        {
            comp.id.Should().NotBe(0);
        }
        [TestMethod]
        public void editarCompromisso()
        {
            Compromisso cn = new Compromisso("Aula IFSC", "google meet", new DateTime(2021, 06, 29, 8, 0, 0), new DateTime(2021, 06, 29, 12, 0, 0), c);
            ccomp.editar(comp.id, cn);

            ccomp.getById(cn.id).ToString().Should().Be(cn.ToString());
        }
        [TestMethod]
        public void excluirCompromisso()
        {
            ccomp.excluir(comp.id);
            ccomp.getById(comp.id).Should().BeNull();
        }
        [TestMethod]
        public void inserirCompromissoSemContato()
        {
            comp.contato = null;
            ccomp.inserir(comp);
            ccomp.getById(comp.id).ToString().Should().Be(comp.ToString());
        }
        [TestMethod]
        public void testeSelecionarCompromissoPorId()
        {
            ccomp.getById(comp.id).ToString().Should().Be(comp.ToString());
        }
        [TestMethod]
        public void SelecionarTodosCompromissos()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", new DateTime(2021, 06, 30, 13, 30, 0), new DateTime(2021, 06, 30, 17, 30, 0), null);
            ccomp.inserir(comp);

            ccomp.Registros.Should().HaveCount(2);
        }

        [TestMethod]
        public void SelecionarCompromissosPassados()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", new DateTime(2020, 06, 30, 13, 30, 0), new DateTime(2020, 06, 30, 17, 30, 0), null);
            ccomp.inserir(comp);

            ccomp.compromissosPassados().Should().HaveCount(2);
        }
        [TestMethod]
        public void SelecionarCompromissosFuturos()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", new DateTime(2022, 06, 30, 13, 30, 0), new DateTime(2022, 06, 30, 17, 30, 0), null);
            ccomp.inserir(comp);

            ccomp.compromissosFuturos(new DateTime(2023, 01, 01)).Should().HaveCount(2);
        }

        [TestCleanup]
        public void removerTodosCompromissos()
        {
            Db.Delete(Extension.resetId("TBCompromissos"));
            Db.Delete(Extension.resetId("TBContatos"));
        }
    }
}

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
            comp = new Compromisso("Aula ADP", "google meet", DateTime.Now.AddHours(1), DateTime.Now.AddHours(5), c);

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
            Compromisso cn = new Compromisso("Aula IFSC", "google meet", DateTime.Now, DateTime.Now.AddHours(4), c);
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
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now, DateTime.Now.AddHours(5), null);
            ccomp.inserir(comp);

            ccomp.Registros.Should().HaveCount(2);
        }
        [TestMethod]
        public void SelecionarCompromissosPassados()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddDays(-50).AddHours(-5), DateTime.Now.AddDays(-50), null);
            ccomp.inserir(comp);

            ccomp.compromissosPassados().Should().HaveCount(1);
        }
        [TestMethod]
        public void SelecionarCompromissosFuturos()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddDays(50).AddHours(5), DateTime.Now.AddDays(50), null);
            ccomp.inserir(comp);

            ccomp.compromissosFuturos(DateTime.Now.AddMonths(8)).Should().HaveCount(2);
        }
        [TestMethod]
        public void verificaDataABBA()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now, DateTime.Now.AddHours(5), null);
            ccomp.inserir(comp);
            Compromisso comp2 = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddHours(1), DateTime.Now.AddHours(4), null);
            ccomp.horarioDisponivel(comp2).Should().BeFalse();
        }
        [TestMethod]
        public void verificaDataBAAB()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now, DateTime.Now.AddHours(5), null);
            ccomp.inserir(comp);
            Compromisso comp2 = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddHours(-1), DateTime.Now.AddHours(6), null);
            ccomp.horarioDisponivel(comp2).Should().BeFalse();
        }
        [TestMethod]
        public void verificaDataABAB()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now, DateTime.Now.AddHours(5), null);
            ccomp.inserir(comp);
            Compromisso comp2 = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddHours(1), DateTime.Now.AddHours(6), null);
            ccomp.horarioDisponivel(comp2).Should().BeFalse();
        }
        [TestMethod]
        public void verificaDataBABA()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now, DateTime.Now.AddHours(5), null);
            ccomp.inserir(comp);
            Compromisso comp2 = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddHours(-1), DateTime.Now.AddHours(4), null);
            ccomp.horarioDisponivel(comp2).Should().BeFalse();
        }
        [TestMethod]
        public void verificaDataValida()
        {
            comp = new Compromisso("Aula ADP 2", "google meet", DateTime.Now, DateTime.Now.AddHours(5), null);
            ccomp.inserir(comp);
            Compromisso comp2 = new Compromisso("Aula ADP 2", "google meet", DateTime.Now.AddHours(6), DateTime.Now.AddHours(8), null);
            ccomp.horarioDisponivel(comp2).Should().BeTrue();
        }
        [TestCleanup]
        public void removerTodosCompromissos()
        {
            Db.Delete(Extension.resetId("TBCompromissos"));
            Db.Delete(Extension.resetId("TBContatos"));
        }
    }
}

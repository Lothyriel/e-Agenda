using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TestesCompromissos
    {
        ControladorCompromissos ccomp = new ControladorCompromissos();
        static Contato c = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev");
        Compromisso comp = new Compromisso("Aula ADP", "google meet", new DateTime(2021, 06, 28, 13, 30, 0), new DateTime(2021, 06, 28, 17, 30, 0), c);

        void inserirCompromisso() { ccomp.inserir(comp); }
        void excluirCompromisso() { ccomp.excluir(comp.id); }

        [TestMethod]
        public void adicionarCompromisso()
        {
            inserirCompromisso();
            Assert.IsTrue(comp.id != 0);
            excluirCompromisso();
        }
        [TestMethod]
        public void editarCompromisso()
        {
            inserirCompromisso();
            Compromisso cn = new Compromisso("Aula IFSC", "google meet", new DateTime(2021, 06, 29, 8, 0, 0), new DateTime(2021, 06, 29, 12, 0, 0), c);
            ccomp.editar(cn.id, cn);

            Assert.AreEqual(cn.local, comp.local);
            Assert.AreNotEqual(cn.assunto, comp.assunto);
            Assert.AreNotEqual(cn.data_inicio, comp.data_inicio);
            Assert.AreNotEqual(cn.id, comp.id);
            Assert.AreNotEqual(cn, comp);
            excluirCompromisso();
        }
        [TestMethod]
        public void testeExcluirCompromisso()
        {
            inserirCompromisso();
            excluirCompromisso();
            Assert.AreEqual(null, ccomp.getById(comp.id));
        }
        [TestMethod]
        public void testeSelecionarCompromissoSemContato()
        {
            comp.contato = null;
            inserirCompromisso();
            Assert.AreEqual(ccomp.getById(comp.id).id, comp.id);
            Assert.AreEqual(ccomp.getById(comp.id).contato, comp.contato);
            excluirCompromisso();
        }
    }
}

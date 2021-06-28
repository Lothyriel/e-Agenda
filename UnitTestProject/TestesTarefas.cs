using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TestesTarefas
    {
        ControladorTarefas ct = new ControladorTarefas();
        ControladorObjetivos co = new ControladorObjetivos();
        Tarefa t = new Tarefa(20, "Limpar a casa");
        void inserirTarefa() { ct.inserir(t); }
        void excluirTarefa() { ct.excluir(t.id); }

        [TestMethod]
        public void adicionarTarefa()
        {
            inserirTarefa();
            Assert.IsTrue(t.id != 0);
            excluirTarefa();
        }
        [TestMethod]
        public void editarTarefa()
        {
            inserirTarefa();
            Tarefa tn = new Tarefa(50, "Arrumar a casa");
            t.editar(tn);
            ct.editar(t.id, t);

            Assert.AreEqual(tn.prioridade, t.prioridade);
            Assert.AreEqual(tn.titulo, t.titulo);
            Assert.AreEqual(tn.dt_criacao.ToString(), t.dt_criacao.ToString());
            Assert.AreNotEqual(tn.id, t.id);
            Assert.AreNotEqual(tn, t);
            excluirTarefa();
        }
        [TestMethod]
        public void PorcentagemConclusao100AoConcluir()
        {
            inserirTarefa();

            Objetivo o = new Objetivo("Arrumar o quarto", t.id);
            o.concluir();
            co.inserir(o);

            t.concluiTarefa();

            ct.editar(t.id, t);

            Assert.AreEqual(100, t.porcentagem_conclusao);
            excluirTarefa();
        }
        [TestMethod]
        public void mudarPorcentagemConclusao()
        {
            inserirTarefa();
            Objetivo o = new Objetivo("Varrer o chão", t.id);
            co.inserir(o);

            t.addObjetivo();

            ct.editar(t.id, t);

            Assert.IsTrue(t.porcentagem_conclusao != 100);
            excluirTarefa();
        }
        [TestMethod]
        public void DataConclusaoValidaAoConcluir()
        {
            inserirTarefa();

            Objetivo o = new Objetivo("Arrumar o quarto", t.id);
            o.concluir();
            co.inserir(o);

            t.concluiTarefa();

            ct.editar(t.id, t);

            Assert.AreNotEqual(new DateTime(1900, 1, 1), t.dt_conclusao);
            excluirTarefa();
        }
        [TestMethod]
        public void testeExcluirTarefa()
        {
            inserirTarefa();
            excluirTarefa();
            Assert.AreEqual(null, ct.getById(t.id));
        }
    }
}

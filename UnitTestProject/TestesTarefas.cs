using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class TestesTarefas
    {
        ControladorTarefas ct = new ControladorTarefas();
        ControladorObjetivos co = new ControladorObjetivos();
        Tarefa original = new Tarefa(20, "Limpar a casa");
        int id;

        [TestMethod]
        public void adicionarTarefa()
        {
            ct.inserir(original);
            id = ct.Registros.Last().id;

            Assert.AreEqual(original.titulo, ct.getById(id).titulo);
        }
        [TestMethod]
        public void editarTarefa()
        {
            original.titulo = "Arrumar a casa";
            original.prioridade = 100;
            id = ct.Registros.Last().id;

            ct.editar(id, original);

            Assert.AreEqual(original.titulo, ct.getById(id).titulo);
            Assert.AreEqual(original.prioridade, ct.getById(id).prioridade);
        }
        [TestMethod]
        public void PorcentagemConclusao100AoConcluir()
        {
            id = ct.Registros.Last().id;
            Objetivo o = new Objetivo("Arrumar o quarto", true, id);
            co.inserir(o);

            var t = ct.getById(id);
            t.concluiTarefa();

            ct.editar(id, t);

            Assert.AreEqual(100, ct.getById(id).porcentagem_conclusao);
        }
        [TestMethod]
        public void mudarPorcentagemConclusao()
        {
            id = ct.Registros.Last().id;
            Objetivo o = new Objetivo("Arrumar o quarto", id);
            co.inserir(o);
            var t = ct.getById(id);
            t.addObjetivo();

            ct.editar(id, t);
            Assert.IsTrue(ct.getById(id).porcentagem_conclusao > 0);
        }
        [TestMethod]
        public void DataConclusaoValidaAoConcluir()
        {
            id = ct.Registros.Last().id;
            Assert.AreNotEqual(new DateTime(1900, 1, 1), ct.getById(id).dt_conclusao);
        }
        [TestMethod]
        public void excluirTarefa()
        {
            ct.excluir(id);

            Assert.AreEqual(null, ct.getById(id));
        }
    }
}

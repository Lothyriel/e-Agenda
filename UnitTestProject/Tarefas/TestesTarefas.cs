using e_Agenda.Controladores;
using e_Agenda.Dominio;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestProject.Extensions;

namespace UnitTestProject.Tarefas
{
    [TestClass]
    public class TestesTarefas
    {
        ControladorTarefas ct = new ControladorTarefas();
        ControladorObjetivos co = new ControladorObjetivos();
        Tarefa t;

        [TestInitialize]
        public void inserirTarefa()
        {
            t = new Tarefa(20, "Limpar a casa");
            ct.inserir(t);
        }
        [TestMethod]
        public void adicionarTarefa()
        {
            t.id.Should().NotBe(0);
        }
        [TestMethod]
        public void editarTarefa()
        {
            Tarefa tn = new Tarefa(50, "Arrumar a casa");
            t.editar(tn);

            ct.editar(t.id, tn);

            tn.prioridade.Should().Be(t.prioridade);
            tn.titulo.Should().Be(t.titulo);
            tn.dt_criacao.ToString().Should().Be(t.dt_criacao.ToString());
            tn.id.Should().Be(t.id);
        }
        [TestMethod]
        public void PorcentagemConclusao100AoConcluir()
        {
            Objetivo o = new Objetivo("Arrumar o quarto", t.id, true);
            t.addObjetivo(o);
            t.atualizaConclusao();

            ct.editar(t.id, t);

            t.porcentagem_conclusao.Should().Be(100);
        }
        [TestMethod]
        public void mudarPorcentagemConclusao()
        {
            Objetivo o = new Objetivo("Varrer o chão", t.id);
            co.inserir(o);

            t.addObjetivo(o);

            ct.editar(t.id, t);

            t.porcentagem_conclusao.Should().NotBe(100);
        }
        [TestMethod]
        public void DataConclusaoValidaAoConcluir()
        {
            Objetivo o = new Objetivo("Arrumar o quarto", t.id, true);
            co.inserir(o);

            t.addObjetivo(o);
            t.atualizaConclusao();

            ct.editar(t.id, t);

            t.dt_conclusao.Should().NotBe(new DateTime(1900, 1, 1));
        }
        [TestMethod]
        public void testeExcluirTarefa()
        {
            ct.excluir(t.id);
            ct.getById(t.id).Should().BeNull();
        }
        [TestCleanup]
        public void removerTodasTarefas()
        {
            Db.Delete(Extension.resetId("TBTarefas"));
        }
    }
}

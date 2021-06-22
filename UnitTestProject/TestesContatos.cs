using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class TestesContatos
    {
        ControladorContatos cc = new ControladorContatos();
        Contato c = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev");
        int id;

        [TestMethod]
        public void adicionarContato()
        {
            cc.inserir(c);
            id = cc.Registros.Last().id;

            Assert.AreEqual(c.nome, cc.getById(id).nome);
        }
        [TestMethod]
        public void editarContato()
        {
            Contato nova = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev pleno");
            id = cc.Registros.Last().id;

            cc.editar(id, nova);

            Assert.AreEqual(nova.cargo, cc.getById(id).cargo);
        }
        [TestMethod]
        public void excluirContato()
        {
            id = cc.Registros.Last().id;
            cc.excluir(id);

            Assert.AreEqual(null, cc.getById(id));
        }
    }
}

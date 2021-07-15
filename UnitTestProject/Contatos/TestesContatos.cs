using e_Agenda.Controladores;
using e_Agenda.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Contatos
{
    [TestClass]
    public class TestesContatos
    {
        ControladorContatos cc = new ControladorContatos();
        Contato c = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev");

        void inserirContato() { cc.inserir(c); }
        void excluirContato() { cc.excluir(c.id); }

        [TestMethod]
        public void adicionarContato()
        {
            inserirContato();
            Assert.IsTrue(c.id != 0);
            excluirContato();
        }
        [TestMethod]
        public void editarContato()
        {
            inserirContato();
            Contato cn = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev Pleno");
            cc.editar(c.id, c);
            
            Assert.AreEqual(cn.nome, c.nome);
            Assert.AreEqual(cn.telefone, c.telefone);
            Assert.AreEqual(cn.email, c.email);
            Assert.AreEqual(cn.empresa, c.empresa);
            Assert.AreNotEqual(cn.cargo, c.cargo);
            Assert.AreNotEqual(cn.id, c.id);
            Assert.AreNotEqual(cn, c);
            excluirContato();
        }
        [TestMethod]
        public void ExcluirContato()
        {
            inserirContato();
            excluirContato();
            Assert.AreEqual(null, cc.getById(c.id));
        }
    }
}

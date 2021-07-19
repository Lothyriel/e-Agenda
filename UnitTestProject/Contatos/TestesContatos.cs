using e_Agenda.Controladores;
using e_Agenda.Dominio;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Extensions;

namespace UnitTestProject.Contatos
{
    [TestClass]
    public class TestesContatos
    {
        ControladorContatos cc = new ControladorContatos();
        Contato c = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev");

        [TestInitialize]
        public void inserirContato() { cc.inserir(c); }
        [TestCleanup]
        public void excluirContato() { Extension.resetId("TBContatos"); }

        [TestMethod]
        public void adicionarContato()
        {
            c.id.Should().NotBe(0);
        }
        [TestMethod]
        public void editarContato()
        {
            Contato cn = new Contato("João Xavier", "fastjonh@gmail.com", "999790598", "NDD", "Dev Pleno");
            cc.editar(c.id, c);

            cn.nome.Should().Be(c.nome);
            cn.telefone.Should().Be(c.telefone);
            cn.email.Should().Be(c.email);
            cn.empresa.Should().Be(c.empresa);
            
            cn.id.Should().NotBe(c.id);
            cn.cargo.Should().NotBe(c.cargo);
        }
        [TestMethod]
        public void ExcluirContato()
        {
            cc.excluir(c.id);
            cc.getById(c.id).Should().BeNull();
        }
    }
}

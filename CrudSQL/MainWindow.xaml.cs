using CrudSQL.Banco_de_Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrudSQL
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            ListarUsuario();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            InserirUsuario();
            ListarUsuarios();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            AtualizarUsuario();
            ListarUsuarios();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeletarUsuario();
            ListarUsuarios();
        }

        private void DeletarUsuario()
        {
            Usuario u = new Usuario();
            var usuarioDAL = new UsuarioDAL();
            u.Nome = txtNome.Text;
            u.Cidade = txtCidade.Text;
            u.Cargo = txtCargo.Text;
            usuarioDAL.Deletar(u);

        }

        private void ListarUsuarios()
        {
            var usuarioDAL = new UsuarioDAL();
            var lista = usuarioDAL.ListarTodos();
            gridUsuarios.ItemsSource = lista;
        }

        private void ListarUsuario()
        {
            var usuario = txtNome.Text;
            var usuarioDAL = new UsuarioDAL();
            var lista = usuarioDAL.ListarUsuario(usuario);
            gridUsuarios.ItemsSource = lista;
        }

        private void InserirUsuario()
        {
            Usuario u = new Usuario();
            var usuarioDAL = new UsuarioDAL();
            u.Nome = txtNome.Text;
            u.Cidade = txtCidade.Text;
            u.Cargo = txtCargo.Text;
            usuarioDAL.Inserir(u);
        }

        private void AtualizarUsuario()
        {
            Usuario u = new Usuario();
            var usuarioDAL = new UsuarioDAL();
            u.Nome = txtNome.Text;
            u.Cidade = txtCidade.Text;
            u.Cargo = txtCargo.Text;
            usuarioDAL.Atualizar(u);
        }

        private void gridUsuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (Usuario)gridUsuarios.SelectedValue;
            if(item == null)
                return;

            txtNome.Text = item.Nome;
            txtCidade.Text = item.Cidade;
            txtCargo.Text = item.Cargo;
        }
    }
}

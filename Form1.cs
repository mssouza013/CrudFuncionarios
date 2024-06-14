using MySql.Data.MySqlClient;

namespace Funcionario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionario = new cadastroFuncionarios();
                    cadFuncionario.Nome = txtNome.Text;
                    cadFuncionario.Email = txtEmail.Text;
                    cadFuncionario.Cpf = txtCpf.Text;
                    cadFuncionario.Endereco = txtEndereco.Text;

                    if (cadFuncionario.cadastrarFuncionarios())
                    {
                        MessageBox.Show($"O funcionario {cadFuncionario.Nome} foi cadastrado com sucesso!");
                        txtNome.Clear();
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar funcionário!");
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher todos os campos corretamente!");
                    txtNome.Clear();
                    txtCpf.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    txtNome.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionario: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Cpf = txtCpf.Text;

                    MySqlDataReader reader = cadFuncionarios.localizarFuncionario();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            lblId.Text = reader["id"].ToString();
                            txtNome.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Funcionário não encontrado!");
                            txtNome.Clear();
                            txtCpf.Clear();
                            txtEmail.Clear();
                            txtEndereco.Clear();
                            txtCpf.Focus();
                            lblId.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado!");
                        txtNome.Clear();
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtCpf.Focus();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CPF para realizar a pesquisa!");
                    txtNome.Clear();
                    txtCpf.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    txtCpf.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao encontrar funcionario: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            lblId.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;

                    if (cadFuncionarios.atualizarFuncionario())
                    {
                        MessageBox.Show("Os dados do funcionário foram atualizados com sucesso!");
                        txtNome.Clear();
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                        txtCpf.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar as informações do funcionário!");
                        txtNome.Clear();
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                        txtCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Favor localizar o funcionário que deseja atualizar as informações!");
                    txtNome.Clear();
                    txtCpf.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    lblId.Text = "";
                    txtCpf.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados do funcionario " + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);

                    if (cadFuncionarios.deletarFuncionario())
                    {
                        MessageBox.Show("O funcionário foi excluido com sucesso!");
                        txtNome.Clear();
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir o funcionário!");
                        txtNome.Clear();
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar qual funcionário que deseja excluir!");
                    txtNome.Clear();
                    txtCpf.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    lblId.Text = "";
                    txtCpf.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir funcionário: " + ex.Message);
            }
        }
    }
}

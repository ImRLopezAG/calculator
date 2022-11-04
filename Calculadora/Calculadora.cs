namespace Calculadora
{
  public partial class Calculadora : Form
  {
    Double valor1 = 0, valor2 = 0;
    char operador;
    private void addNumber(object sender, EventArgs e)
    {
      var button = ((Button)sender);

      if (txtResult.Text == "0")
        txtResult.Text = "";
      else
        txtResult.Text += button.Text;
    }

    private void clickOperator(object sender, EventArgs e)
    {
      var button = ((Button)sender);

      valor1 = Double.Parse(txtResult.Text);
      operador = Convert.ToChar(button.Tag);
      txtResult.Text = "0";
    }
    public Calculadora()
    {
      InitializeComponent();
    }

    private void Calculadora_Load(object sender, EventArgs e)
    {
      KeyPreview = true;
    }

    private void Calculadora_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (int)Keys.Enter)
      {
        e.Handled = true;
        if (txtResult.Text.Trim() != string.Empty)
        {
          btnIgual.PerformClick();
        }
      }

    }

    private void btnIgual_Click(object sender, EventArgs e)
    {
      valor2 = Double.Parse(txtResult.Text);
      switch (operador)
      {
        case '+':
          txtResult.Text = (valor1 + valor2).ToString();
          valor1 = Double.Parse(txtResult.Text);
          break;
        case '-':
          txtResult.Text = (valor1 - valor2).ToString();
          valor1 = Double.Parse(txtResult.Text);
          break;
        case 'x':
          txtResult.Text = (valor1 * valor2).ToString();
          valor1 = Double.Parse(txtResult.Text);
          break;
        case '/':
          txtResult.Text = (valor1 / valor2).ToString();
          valor1 = Double.Parse(txtResult.Text);
          break;
      }
    }

    private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Char.IsLetter(e.KeyChar)) // Solo permitir numeros en el texto            
      {
        e.Handled = true;
        // MessageBox.Show("Solo numeros");
      }
      // limpiar con scape
      if (e.KeyChar == (int)Keys.Escape)
      {
        e.Handled = true;
        txtResult.Text = string.Empty;
      }
    }
  }
}
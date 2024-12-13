using System;
namespace lab3report
{
    public partial class lab7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values
                double principal = Convert.ToDouble(txtPrincipal.Text);
                double rate = Convert.ToDouble(txtRate.Text);
                double time = Convert.ToDouble(txtTime.Text);

                // Calculate simple interest
                double interest = (principal * rate * time) / 100;

                // Display the result
                lblResult.Text = "Simple Interest: Rs" + interest.ToString("F2");
            }
            catch (Exception ex)
            {
                // Display error message if inputs are invalid
                lblResult.Text = "Please enter valid numeric values.";
            }
        }
    }
}

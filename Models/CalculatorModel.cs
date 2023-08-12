using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CalculatorAA.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Expression is required.")]
         [RegularExpression(@"^[0-9+\-*/\s]+$", ErrorMessage = "Invalid expression.")]
        public string Expression { get; set; }
        public double Result { get; set; }

        public void Calculate()
        {
        
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), Expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            Result = double.Parse((string)row["expression"]);
        }
    }
}

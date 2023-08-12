﻿using System.Data;

namespace CalculatorAA.Models
{
    public class CalculatorModel
    {
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
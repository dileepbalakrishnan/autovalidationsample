using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidateOpenDemo
{
    public partial class Form1 : Form
    {
        BindingList<ValidationRule> rules;
        public Form1()
        {
            InitializeComponent();
            ultraGrid1.InitializeLayout += UltraGrid1_InitializeLayout;
            rules = new BindingList<ValidationRule>();
        }

        private void UltraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //var scopeDropDown = new UltraDropDown();
            //scopeDropDown.DataSource = Enum.GetNames(typeof(ValidationScope));
            //var scopeValues = new ValueList();
            //foreach (var item in Enum.GetNames(typeof(ValidationScope)))
            //{
            //    scopeValues.ValueListItems.Add(item);
            //}
            //e.Layout.Bands[0].Columns["Scope"].ValueList = scopeDropDown;
            const string colorValueList = @"ColorValueList";

            if (!e.Layout.ValueLists.Exists(colorValueList))
            {
                ValueList svl = e.Layout.ValueLists.Add(colorValueList);
                svl.ValueListItems.Add(ValidationScope.Official, "Official");
                svl.ValueListItems.Add(ValidationScope.UnOfficial, "UnOfficial");
                svl.ValueListItems.Add(ValidationScope.Both, "Both");
            }
            e.Layout.Bands[0].Columns["Scope"].ValueList = e.Layout.ValueLists[colorValueList];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var data = new List<ValidationRule> 
            { 
                new ValidationRule{AutoValidate = true, ErrorMessage="Error1", ErrorRegEx="ABCD", Scope=ValidationScope.Official, TradeId="JMS-12345" },
                //new ValidationRule{AutoValidate = true, ErrorMessage="Error2", ErrorRegEx="ABCD", Scope=ValidationScope.Official, TradeId="JMS-12345" },
                //new ValidationRule{AutoValidate = true, ErrorMessage="Error3", ErrorRegEx="ABCD", Scope=ValidationScope.Official, TradeId="JMS-12345" },
                //new ValidationRule{AutoValidate = true, ErrorMessage="Error4", ErrorRegEx="ABCD", Scope=ValidationScope.Official, TradeId="JMS-12345" },
                //new ValidationRule{AutoValidate = true, ErrorMessage="Error5", ErrorRegEx="ABCD", Scope=ValidationScope.Official, TradeId="JMS-12345" },
                //new ValidationRule{AutoValidate = true, ErrorMessage="Error6", ErrorRegEx="ABCD", Scope=ValidationScope.Official, TradeId="JMS-12345" }
            };
            foreach (var item in data)
            {
                rules.Add(item);
            }
            ultraGrid1.DataSource = rules;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rule = rules[0];
            var values = $"TradeId: {rule.TradeId}\nErrorMessage: {rule.ErrorMessage}\nErrorRegEx: {rule.ErrorRegEx}\nScope: {rule.Scope}\nAutoValidate: {rule.AutoValidate}\n";
            MessageBox.Show(values);
        }
    }
}

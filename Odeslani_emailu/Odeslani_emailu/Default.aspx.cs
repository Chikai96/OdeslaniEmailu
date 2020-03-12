using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Odeslani_emailu
{
    public partial class _Default : Page
    {
        List<CheckBox> CheckboxList = new List<CheckBox>();
        protected void Page_Load(object sender, EventArgs e)
            {
            
        var db = new EmailyEntities(); // Přístup k databázi
            Table table = new Table();
            CheckBox tmpCheckBox;
            TableCell tablecellJmeno;
            TableCell tablecellPrijmeni;
            TableCell tablecellEmail;
            TableCell tablecellVyber;
            TableRow tmpTableRow;
            foreach (var kontakt in db.Kontakty)
                {
                tmpTableRow = new TableRow();

                tmpCheckBox = new CheckBox();
                tmpCheckBox.ID = kontakt.Email;

                tablecellJmeno = new TableCell();
                tablecellJmeno.Text=kontakt.Jmeno;
                tablecellPrijmeni = new TableCell();
                tablecellPrijmeni.Text=kontakt.Prijmeni;
                tablecellEmail = new TableCell();
                tablecellEmail.Text=kontakt.Email;
                tablecellVyber = new TableCell();
                tablecellVyber.Controls.Add(tmpCheckBox);

                CheckboxList.Add(tmpCheckBox);

                tablecellJmeno.Width = 100;
                tablecellPrijmeni.Width = 100;
                tablecellEmail.Width = 200;
                tablecellVyber.Width = 100;

                tmpTableRow.Cells.Add(tablecellJmeno);
                tmpTableRow.Cells.Add(tablecellPrijmeni);
                tmpTableRow.Cells.Add(tablecellEmail);
                tmpTableRow.Cells.Add(tablecellVyber);
                table.Rows.Add(tmpTableRow);


            }
            PlaceHolder1.Controls.Add(table);


            Button1.Click += Button1_Click;
            }

            private void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder emailTo = new StringBuilder();
            var oznaceneAdresy = CheckboxList.Where(x => x.Checked).Select(x => x.ID).ToList(); //vybírání označených adres
            foreach (var adresa in oznaceneAdresy)
                emailTo.Append(adresa.Replace(" ", "") + ";");
            Response.Redirect("mailto:" + emailTo.ToString());


        }
        
    }
}
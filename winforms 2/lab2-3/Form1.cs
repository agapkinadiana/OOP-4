using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace lab2_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            position.Items.AddRange(Crewman.listOfPositions);
            airplane_type.Items.AddRange(Airplane.types);
        }

        public List<Crewman> listOfCrewmans = new List<Crewman>();
        public List<Airplane> listOfAirplanes = new List<Airplane>();

        public List<Airplane> searchResult = new List<Airplane>();
        public List<Airplane> sortResult = new List<Airplane>();

        private void add_crewmans_Click(object sender, EventArgs e)
        {
            try
            {
                Regex regex = new Regex("[A-ZА-Я][a-zа-я]{1,20}");

                 //if (!regex.IsMatch(first_name.Text))// || !regex.IsMatch(second_name.Text) || !regex.IsMatch(position.Text) || (sex_male.Checked == false && sex_female.Checked == false))
                 //MessageBox.Show("Check entered data!");
                 if ((sex_male.Checked == false && sex_female.Checked == false))
                     MessageBox.Show("Not all fields are filled!");
                 else if (String.IsNullOrEmpty(position.Text))
                 {
                     errorProvider1.SetError(position, "Choose position!");
                 }
                 else if (String.IsNullOrEmpty(second_name.Text))
                 {
                     errorProvider1.SetError(second_name, "Enter second name!");
                 }
                 else if (String.IsNullOrEmpty(first_name.Text))
                 {
                     errorProvider1.SetError(first_name, "Enter first name!");
                 }
               /* Crewman crewman = new Crewman();
                crewman.NameFirst = first_name.Text;
                crewman.NameSecond = second_name.Text;
                crewman.Experience = Convert.ToInt32(experience.Value);
                crewman.DateOfBirth = date_of_birth.Text;
                crewman.Sex = sex_male.Checked == true ? sex_male.Text : sex_female.Text;
                crewman.Position = position.Text;

                var results = new List<ValidationResult>();
                var context = new ValidationContext(crewman);
                if (!Validator.TryValidateObject(crewman, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }*/
                else
                {
                   Crewman crewman = new Crewman(first_name.Text, second_name.Text, Convert.ToInt32(experience.Value),
                        date_of_birth.Text, sex_male.Checked == true ? sex_male.Text : sex_female.Text,
                        position.Text);

                    listOfCrewmans.Add(crewman);
                    list_of_crewmans.Items.Add(crewman);
                    airplane_crew.Items.Add(crewman);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void add_producers_Click(object sender, EventArgs e)
        {
            try
            {
                //Regex year_regex = new Regex(@"\d{4}");
                List<string> list = new List<string>();
                bool check = false;

                if(type_passenger.Checked)
                {
                    list.Add(type_passenger.Text);
                    check = true;
                }
                if(type_military.Checked)
                {
                    list.Add(type_military.Text);
                    check = true;
                }
                if(type_cargo.Checked)
                {
                    list.Add(type_cargo.Text);
                    check = true;
                }
                int year = 0;

                if (!check)
                    MessageBox.Show("Not all fields are filled!");
                else if (String.IsNullOrEmpty(company_name.Text))
                {
                    errorProvider1.SetError(company_name, "Enter company name!");
                }
                else if (String.IsNullOrEmpty(producer_country.Text))
                {
                    errorProvider1.SetError(producer_country, "Enter producer country!");
                }
                else if (!Int32.TryParse(year_of_foundation.Text, out year))
                {
                    errorProvider1.SetError(year_of_foundation, "Incorrect year of foundation!");
                }
                else
                {
                    Producer producer = new Producer(company_name.Text, producer_country.Text, Convert.ToInt32(year_of_foundation.Text), list);
                    list_of_producers.Items.Add(producer.ShowAllInf());
                    airplane_model.Items.Add(producer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void add_airplane_Click(object sender, EventArgs e)
        {
            try
            {
                //if (airplane_crew.Text.Equals("") || airplane_id.Text.Equals("") || airplane_type.Text.Equals("") || date_of_construction.Text.Equals("") || capacity.Text.Equals("") || airplane_model.Text.Equals(""))
                    //MessageBox.Show("Not all fields ae filled!");
                if (String.IsNullOrEmpty(airplane_type.Text))
                {
                    errorProvider1.SetError(airplane_type, "Choose airplane's type!");
                }
                else if (String.IsNullOrEmpty(airplane_model.Text))
                {
                    errorProvider1.SetError(airplane_model, "Choose airplane's model!");
                }
                else
                {
                    int cap;
                    if ((cap = Convert.ToInt32(capacity.Text)) < 0 || cap > 1000000)
                        MessageBox.Show("Check entered data!");
                    else
                    {
                        List<Crewman> list = new List<Crewman>(airplane_crew.CheckedIndices.Count);
                        foreach (Crewman crewman in airplane_crew.CheckedItems)
                            list.Add(crewman);
                        Airplane airplane = new Airplane(airplane_id.Text, airplane_type.Text, (int)count_of_spaces.Value, date_of_construction.Text, Convert.ToInt32(capacity.Text), list, (Producer)airplane_model.SelectedItem);
                        listOfAirplanes.Add(airplane);
                        list_of_airplanes.Items.Add(airplane);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void clear_crewman_Click(object sender, EventArgs e)
        {
            first_name.Clear();
            second_name.Clear();
            position.Text = "";
            experience.Value = 0;
            sex_female.Checked = sex_male.Checked = false;
        }

        private void clear_producer_Click(object sender, EventArgs e)
        {
            company_name.Clear();
            producer_country.Clear();
            year_of_foundation.Clear();
            type_passenger.Checked = type_military.Checked = type_cargo.Checked = false;
        }

        private void clear_airplane_Click(object sender, EventArgs e)
        {
            airplane_id.Clear();
            airplane_type.Text = "";
            airplane_model.Text = "";
            count_of_spaces.Value = 0;
            capacity.Clear();
            airplane_crew.ClearSelected();
        }

        private void save_Click(object sender, EventArgs e)
        {
            save_file.FileName = "serialization.xml";
            save_file.ShowDialog();

            if (listOfAirplanes.Count != 0)
            {
                using (FileStream fs = new FileStream(save_file.FileName, FileMode.OpenOrCreate))
                {
                    if (save_file.FileName.Contains(".xml"))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Airplane>));
                        xmlSerializer.Serialize(fs, listOfAirplanes);
                    }
                    else
                    {
                        throw new Exception("Uncorrect extension");
                    }
                }
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
        }

        private void read_Click(object sender, EventArgs e)
        {
            try
            {
                open_file.FileName = "serialization.xml";
                open_file.ShowDialog();

                List<Airplane> lst;
                using (FileStream fs = new FileStream(open_file.FileName, FileMode.Open))
                {
                    if (open_file.FileName.Contains(".xml"))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Airplane>));
                        lst = (List<Airplane>)xmlSerializer.Deserialize(fs);
                    }
                    else
                    {
                        throw new Exception("Uncorrect extension");
                    }
                }
                if (lst.Count != 0)
                {
                    foreach (Airplane a in lst)
                    {
                        listOfAirplanes.Add(a);
                        list_in_file.Items.Add(a);
                    }
                }
                else
                {
                    MessageBox.Show("Collection is empty!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.Message);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(listOfAirplanes);

            form2.ShowDialog();
            if (form2.SearchResult != null)
            {
                this.searchResult = form2.SearchResult;
            }
        }

        private void airplane_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = from a in listOfAirplanes
                         orderby a.Captain
                         select a;

            var result1 = from a in result
                          orderby a.SecondPilot
                          select a;

            list_of_airplanes.Items.Clear();
            sortResult.Clear();
            foreach (Airplane a in result)
            {
                list_of_airplanes.Items.Add(a);
                sortResult.Add(a);
            }
        }

        private void dateOfConstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = from a in listOfAirplanes
                         orderby a.DateOfConstruction
                         select a;

            list_of_airplanes.Items.Clear();
            sortResult.Clear();
            foreach (Airplane a in result)
            {
                list_of_airplanes.Items.Add(a);
                sortResult.Add(a);
            }
        }

        private void resultOfLastSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file.FileName = "search.xml";
            save_file.ShowDialog();

            if (searchResult.Count != 0)
            {
                using (FileStream fs = new FileStream(save_file.FileName, FileMode.OpenOrCreate))
                {
                    if (save_file.FileName.Contains(".xml"))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Airplane>));
                        xmlSerializer.Serialize(fs, searchResult);
                    }
                    else
                    {
                        throw new Exception("Uncorrect extension");
                    }
                }
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
        }

        private void resultOfLastSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file.FileName = "sort.xml";
            save_file.ShowDialog();

            if (sortResult.Count != 0)
            {
                using (FileStream fs = new FileStream(save_file.FileName, FileMode.OpenOrCreate))
                {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Airplane>));
                        xmlSerializer.Serialize(fs, sortResult);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This product is made by Diana Agapkina.\nLab2-3 Version 2.0 \nAll rights reserved. \nBSTU 2019", "Info");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(listOfAirplanes);

            form2.ShowDialog();
            if (form2.SearchResult != null)
            {
                this.searchResult = form2.SearchResult;
            }
        }

        private void nameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = from a in listOfAirplanes
                         orderby a.Captain
                         select a;

            var result1 = from a in result
                          orderby a.SecondPilot
                          select a;

            list_of_airplanes.Items.Clear();
            sortResult.Clear();
            foreach (Airplane a in result)
            {
                list_of_airplanes.Items.Add(a);
                sortResult.Add(a);
            }
        }

        private void dateOfConstructionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = from a in listOfAirplanes
                         orderby a.DateOfConstruction
                         select a;

            list_of_airplanes.Items.Clear();
            sortResult.Clear();
            foreach (Airplane a in result)
            {
                list_of_airplanes.Items.Add(a);
                sortResult.Add(a);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            first_name.Clear();
            second_name.Clear();
            position.Text = "";
            experience.Value = 0;
            sex_female.Checked = sex_male.Checked = false;
            company_name.Clear();
            producer_country.Clear();
            year_of_foundation.Clear();
            type_passenger.Checked = type_military.Checked = type_cargo.Checked = false;
            airplane_id.Clear();
            airplane_type.Text = "";
            airplane_model.Text = "";
            count_of_spaces.Value = 0;
            capacity.Clear();
            airplane_crew.ClearSelected();
            list_of_crewmans.Text = "";
            list_of_producers.Text = "";
            list_of_airplanes.Text = "";
            list_in_file.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_label.Text = DateTime.Now.ToLongDateString();
            time_label.Text = DateTime.Now.ToLongTimeString();
        }

        private void airplane_id_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = !Char.IsDigit(e.KeyChar);
        }

        private void capacity_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = !Char.IsDigit(e.KeyChar);
        }
    }
}

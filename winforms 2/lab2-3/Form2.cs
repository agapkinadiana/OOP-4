using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace lab2_3
{
    [MetadataType(typeof(Form2))]
    public partial class Form2 : Form
    {
        public Form2(List<Airplane> list)
        {
            InitializeComponent();
            search_type.Items.AddRange(Airplane.types);
            this.list = list;
        }

        private bool Search = true;
        public string Type = String.Empty;
        public string Company = String.Empty;
        [Range(0, 200)]
        public int Space = -1;
        [Range(0, 1000000)]
        public int Capacity = -1;
        private List<Airplane> list;
        public List<Airplane> SearchResult = new List<Airplane>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
            search_type.Items.AddRange(Airplane.types);
        }

        private void GoToDefault()
        {
            Type = Company = String.Empty;
            Capacity = Space = -1;
            Search = true;
        }

        private void SearchM(IEnumerable<Airplane> list)
        {
            try
            {
                Regex text = new Regex("[A-zА-я]{2,30}");
                search_result.Items.Clear();
                bool wasCheck = false;
                List<Airplane> query = new List<Airplane>(list.Count());
                if (!search_type.Equals(String.Empty))
                {
                    wasCheck = true;
                    var result = from airplane in list
                                 where airplane.Type == Type
                                 select airplane;
                    if (result.Count() == 0)
                    {
                        Search = false;
                    }
                    else
                    {
                        foreach (Airplane a in result)
                        {
                            query.Add(a);
                        }
                    }
                }
                if (!Company.Equals(String.Empty) && Search)
                {
                    var result = from airplane in wasCheck ? query : list
                                 where airplane.Model.CompanyName == Company
                                 select airplane;
                    wasCheck = true;
                    if (result.Count() == 0)
                    {
                        Search = false;
                    }
                    else if (Search)
                    {
                        query = new List<Airplane>(result.Count());
                        foreach (Airplane a in result)
                        {
                            if (!query.Contains(a))
                            {
                                query.Add(a);
                            }
                        }
                    }
                }
                if (Space != -1 && Search)
                {
                    var result = from airplane in wasCheck ? query : list
                                 where airplane.CountOfSpaces == Space
                                 select airplane;
                    wasCheck = true;
                    if (result.Count() == 0)
                    {
                        Search = false;
                    }
                    else if (Search)
                    {
                        query = new List<Airplane>(result.Count());
                        foreach (Airplane a in result)
                        {
                            if (!query.Contains(a))
                            {
                                query.Add(a);
                            }
                        }

                    }
                }
                if (Capacity != -1 && Search)
                {
                    var result = from airplane in wasCheck ? query : list
                                 where airplane.Capacity == this.Capacity
                                 select airplane;
                    wasCheck = true;
                    if (result.Count() == 0)
                    {
                        Search = false;
                    }
                    else if (Search)
                    {
                        query = new List<Airplane>(result.Count());
                        foreach (Airplane a in result)
                        {
                            if (!query.Contains(a))
                            {
                                query.Add(a);
                            }
                        }
                    }
                }
                if (query.Count != 0 && Search)
                {
                    foreach (Airplane a in query)
                    {
                        search_result.Items.Add(a);
                    }
                    SearchResult = query;
                }
                else
                {
                    MessageBox.Show("no matches found");
                }
                GoToDefault();
                query.Clear();
            }
            catch
            {
                MessageBox.Show("Test");
            }
        }

        private void clear_bt_Click(object sender, EventArgs e)
        {
            search_type.Text = String.Empty;
            search_company.Text = String.Empty;
            search_spaces.Text = String.Empty;
            search_capacity.Text = String.Empty;
            search_result.Items.Clear();
        }

        private void search_bt_Click(object sender, EventArgs e)
        {
            search_result.Items.Clear();
            try
            {
                bool flag = false;
                int capac;
                if (!search_capacity.Text.Equals(String.Empty) && (capac = Convert.ToInt32(search_capacity.Text)) > -1 && capac < 10000001)
                {
                    Capacity = capac;
                    flag = true;
                }
                if (!search_type.Text.Equals(String.Empty))
                {
                    flag = true;
                    Type = search_type.Text;
                }
                int space;
                if (!search_spaces.Text.Equals(String.Empty) && (space = Convert.ToInt32(search_spaces.Text)) > -1 && space < 201)
                {
                    flag = true;
                    Space = space;
                }
                if (!search_company.Text.Equals(String.Empty))
                {
                    flag = true;
                    Company = search_company.Text;
                }
                if (!flag)
                {
                    MessageBox.Show("no criteries for search");
                    return;
                }

                SearchM(list);
                GoToDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
    }
}

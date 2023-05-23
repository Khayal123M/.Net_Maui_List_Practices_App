namespace List_Practices_App
{
    public partial class MainPage : ContentPage
    {
        private List<Person> personels;

        public MainPage()
        {
            InitializeComponent();

            personels = new List<Person>();

            tableView.BindingContext = personels;
        }

        private void Button_Clicked(object sender, EventArgs e)  // Add Button Method
        {
            int PersonelNo = int.Parse(Entry_PerNo.Text);
            string Name = Entry_PerName.Text;
            string Surname = Entry_PerSurname.Text;
            string Telephone = Entry_PerTelephone.Text;

            Person newperson = new Person
            {
                Personel_No = PersonelNo,
                Name = Name,
                Surname = Surname,
                Telephone = Telephone
            };

            personels.Add(newperson);

            tableView.Root[0].Add(new TextCell                   
            {
                Text = $"{PersonelNo}",
                Detail = $"{Name} {Surname} {Telephone}"
            });

            labelCount.Text = personels.Count.ToString();          
        }

        private void Button_Clicked_1(object sender, EventArgs e)    // Searceh Button
        {

            int SearchPersonNo = int.Parse(Entry_Selected_PerNo.Text);

            Person SearchPerson = personels.FirstOrDefault(per => per.Personel_No == SearchPersonNo);
            if (SearchPerson != null)
            {
                lbl_Selected.Text = $"{SearchPerson.Personel_No}: {SearchPerson.Name} {SearchPerson.Surname} {SearchPerson.Telephone}";

                EntryNew_No.Text = $"{SearchPerson.Personel_No}";
                EntryNew_Name.Text = $"{SearchPerson.Name}";
                EntryNew_Surname.Text = $"{SearchPerson.Surname}";
                EntryNew_Telephone.Text = $"{SearchPerson.Telephone}";
            }
            else
            {
                lbl_Selected.Text = "The requested personnel could not be found..";
            }


        }

        private void Button_Clicked_2(object sender, EventArgs e)  // Delete Selected Button
        {


            int selected_PerNo = int.Parse(Entry_Selected_PerNo.Text);

            Person selected_Person = personels.FirstOrDefault(per => per.Personel_No == selected_PerNo);
            if (selected_Person != null)
            {
                personels.Remove(selected_Person);
                tableView.Root[0].Remove(tableView.Root[0].FirstOrDefault(cell => (string)cell.GetValue(TextCell.TextProperty) == $"{selected_PerNo}"));
            }


        }

        private void Button_Clicked_3(object sender, EventArgs e)   // Update Selected Button
        {
            int update_PerNo = int.Parse(Entry_Selected_PerNo.Text);

            Person updatePerson = personels.FirstOrDefault(per => per.Personel_No == update_PerNo);
            if (updatePerson != null)
            {
                updatePerson.Personel_No = Convert.ToInt32(EntryNew_No.Text);
                updatePerson.Name = EntryNew_Name.Text;
                updatePerson.Surname = EntryNew_Surname.Text;
                updatePerson.Telephone = EntryNew_Telephone.Text;


                tableView.Root[0].Remove(new TextCell
                {
                    Text = $"{update_PerNo}",
                    Detail = $"{updatePerson.Name} {updatePerson.Surname} {updatePerson.Telephone}"
                });

                tableView.Root[0].Add(new TextCell
                {
                    Text = $"{update_PerNo}",
                    Detail = $"{updatePerson.Name} {updatePerson.Surname} {updatePerson.Telephone}"
                });

            }

        }

        private void Button_Clicked_4(object sender, EventArgs e)    // Delete Full List Button
        {
            personels.Clear();
            tableView.Root[0].Clear();
            labelCount.Text = "0";
        }

        private void Button_Clicked_5(object sender, EventArgs e)  // Clear Entries
        {
            Entry_PerNo.Text = "";
            Entry_PerName.Text = "";
            Entry_PerSurname.Text = "";
            Entry_PerTelephone.Text = "";
            Entry_Selected_PerNo.Text = "";
            lbl_Selected.Text = "";
            EntryNew_No.Text = "";
            EntryNew_Name.Text = "";
            EntryNew_Surname.Text = "";
            EntryNew_Telephone.Text = "";
            


        }
    }








    public class Person
    {
        public int Personel_No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }

    }




}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Rehber_Islemleri : Form
    {
        public Rehber_Islemleri()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guides.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla eklendi!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            var deletedValue = db.Guides.Find(id);
            if (deletedValue != null)
            {
                db.Guides.Remove(deletedValue);
                db.SaveChanges();
                MessageBox.Show("Silme işlemi başarıyla tamamlandı");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            var updatedValue = db.Guides.Find(id);
            

            if(txtName.Text != null && txtSurname.Text != null)
            {
                updatedValue.GuideName = txtName.Text;
                updatedValue.GuideSurname = txtSurname.Text;
                db.SaveChanges();
                MessageBox.Show("Guncelleme işlemi başarıyla tamamlandı","Uyari",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            var value = db.Guides.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = value;
        }
    }
}

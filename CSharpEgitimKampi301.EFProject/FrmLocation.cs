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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values =db.Locations.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guides.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList(); ;
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());

            db.Locations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme Islemi basarili");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deletedLocation = db.Locations.Find(id);
            if(deletedLocation != null)
            {
                db.Locations.Remove(deletedLocation);
                db.SaveChanges();
                MessageBox.Show("Silme islemi basarili!","Silme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var updatedLocation = db.Locations.Find(id);
            updatedLocation.City = txtCity.Text;
            updatedLocation.Country = txtCountry.Text;
            updatedLocation.Price = decimal.Parse(txtPrice.Text);
            updatedLocation.DayNight= txtDayNight.Text;
            updatedLocation.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedLocation.GuideId = int.Parse(cmbGuide.SelectedValue.ToString()) ;

            db.SaveChanges();
            MessageBox.Show("Guncelleme islemi Basarili");
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Locations.Count().ToString();
            lblSumCapacity.Text = db.Locations.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guides.Count().ToString();
            lblAverageCapacity.Text = db.Locations.Average(x => x.Capacity).ToString();
            lblAvaragePrice.Text = db.Locations.Average(x => x.Price).ToString() + " Tl";

            var lastCountryId = db.Locations.Max(x => x.LocationId);
            lblLastAddedCountry.Text = db.Locations.Where(x => x.LocationId == lastCountryId)
                .Select(y => y.Country).FirstOrDefault();

            lblCapadociaTourCapacity.Text = db.Locations.Where(x => x.City == "Kapadokya")
                .Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkishTourAvgCapacity.Text = db.Locations.Where(x => x.Country == "Turkiye")
                .Average(y => y.Capacity).ToString();

            var romeGuideId = db.Locations.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId)
                .FirstOrDefault();
            lblRomaTourGuide.Text = db.Guides.Where(x => x.GuideId == romeGuideId)
                .Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();

            var maxCapacity = db.Locations.Max(x => x.Capacity);
            lblMaxCapacityTour.Text = db.Locations.Where(x => x.Capacity == maxCapacity)
                .Select(y => y.City).FirstOrDefault();

            var mostExpnsvTour = db.Locations.Max(x => x.Price);
            lblMostExpensiveTour.Text = db.Locations.Where(x => x.Price == mostExpnsvTour)
                .Select(y => y.City).FirstOrDefault();

            var aysglCnrId = db.Guides.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar")
                .Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocatinCount.Text = db.Locations.Where(x => x.GuideId == aysglCnrId)
                .Count().ToString();
        }
    }
}

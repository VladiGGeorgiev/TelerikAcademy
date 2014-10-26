using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Locations
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBoxContinents_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new LocationsEntities();
            var id = this.ListBoxContinents.SelectedIndex + 1;
            var countries = context.Countries.Where(x => x.ContitnentId == id).ToList();
            var pageSize = this.GridViewCountries.PageSize;
            countries.Take(pageSize);
            var selectedContinent = context.Continents.FirstOrDefault(x => x.ContinentId == id);
            if (countries.Count > 0)
            {
                this.CountriesTitle.InnerText = "Countries in " + selectedContinent.Name;
            }
            else
            {
                this.CountriesTitle.InnerText = "No contries in" + selectedContinent.Name;
            }
            this.GridViewCountries.DataSource = countries;
            this.GridViewCountries.DataBind();
        }

        protected void GridViewCountries_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var id = (int)(sender as GridView).SelectedDataKey.Value;
            var context = new LocationsEntities();
            var towns = context.Towns.Include("Country").Where(x => x.CountryId == id).ToList();
            var selectedCountry = context.Countries.FirstOrDefault(x => x.CountryId == id);

            var index = this.GridViewCountries.SelectedIndex;



            if (towns.Count > 0)
            {
                this.TownsTitle.InnerText = "Towns in: " + selectedCountry.Name;
            }
            else
            {
                this.TownsTitle.InnerText = "No towns in: " + selectedCountry.Name;
            }

            this.ListViewTowns.DataSource = towns;
            this.ListViewTowns.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBinding
{
    public partial class Default : System.Web.UI.Page
    {
        private List<Producer> producers; 

        protected void Page_Load(object sender, EventArgs e)
        {
            this.producers = GetCarsData();

            if (Page.IsPostBack)
            {
                return;
            }

            //Set data source for producers and models
            this.DropDownListProducer.DataSource = this.producers;
            var producer = this.producers.FirstOrDefault();
            if (producer != null)
            {
                this.DropDownListModel.DataSource = producer.Models;
            }

            //Set extras data source
            this.CheckBoxListExtras.DataSource = GetExtras();

            this.RadioButtonListEngines.DataSource = GetEngines();

            this.DataBind();
        }

        private List<string> GetEngines()
        {
            var engines = new List<string>()
                {
                    "Petrol",
                    "Diesel",
                    "Electric",
                    "Gas",
                    "Ethanol",
                    "Hybrid"
                };
            return engines;
        }

        private List<Extra> GetExtras()
        {
            var extras = new List<Extra>()
                {
                    new Extra("Immobilizer"),
                    new Extra("Xenon headlights"),
                    new Extra("Four wheel drive"),
                    new Extra("ABS"),
                    new Extra("Navigation system"),
                    new Extra("Parking sensors"),
                    new Extra("Cruise control"),
                    new Extra("Electric windows"),
                };
            return extras;
        }

        private List<Producer> GetCarsData()
        {
            var bmwModels = new List<Model>
                {
                    new Model("X5"),
                    new Model("1 Series"),
                    new Model("3 Series"),
                    new Model("5 Series"),
                    new Model("6 Series"),
                    new Model("7 Series"),
                    new Model("M Power")
                };
            var bmwProducer = new Producer("BMW", bmwModels);

            var audiModels = new List<Model>
                {
                    new Model("A3"),
                    new Model("A4"),
                    new Model("A5"),
                    new Model("A7"),
                    new Model("S4"),
                    new Model("S8"),
                };
            var audiProducer = new Producer("Audi", audiModels);

            var opelModels = new List<Model>
                {
                    new Model("Insignia"),
                    new Model("Astra"),
                    new Model("Vectra"),
                };
            var opelProducer = new Producer("Opel", opelModels);

            var carsProducers = new List<Producer>()
                {
                    bmwProducer,
                    audiProducer,
                    opelProducer
                };
            return carsProducers;
        }

        protected void DropDownListProducers_Change(object sender, EventArgs e)
        {
            var selectedProducer = this.DropDownListProducer.SelectedValue;
            var producer = producers.FirstOrDefault(x => x.Name == selectedProducer);
            if (producer == null)
            {
                throw new InvalidOperationException("Invalid producer!");
            }

            var selectedProducerModels = producer.Models;
            this.DropDownListModel.DataSource = selectedProducerModels;
            this.DropDownListModel.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var producer = this.DropDownListProducer.SelectedValue;
            var model = this.DropDownListModel.SelectedValue;
            var engine = this.RadioButtonListEngines.SelectedValue;
            var extrasSource = this.CheckBoxListExtras.Items;
            List<string> extras = new List<string>();
            foreach (ListItem extra in extrasSource)
            {
                if (extra.Selected)
                {
                    extras.Add(extra.Text);
                }
            }

            string selectedInformation = string.Format("Producer: {0} Model: {1} Engine: {2} Extras: {3}",
                                                       producer, model, engine, string.Join(", ", extras));

            this.LiteralCollectedInfo.Text = selectedInformation;
        }
    }
}
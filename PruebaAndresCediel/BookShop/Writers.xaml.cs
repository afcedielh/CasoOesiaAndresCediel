using BookShop.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace BookShop
{
    /// <summary>
    /// Lógica de interacción para Writers.xaml
    /// </summary>
    public partial class Writers : Page
    {

        List<Writer> Writeres = new List<Writer>();
        List<Country> Countries = new List<Country>();
        List<City> Cities = new List<City>();
        Writer WriterSelected = new Writer();
        string url;

        /// <summary>
        /// 
        /// </summary>
        public Writers()
        {
            InitializeComponent();
            url = ConfigurationManager.AppSettings.Get("EndPoint");
            GetWriters();
            GetCountries();
            dgWriters.ItemsSource = Writeres;
            Country.ItemsSource = Countries.Select(a => a.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetWriters()
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "writer");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            Writeres = JsonConvert.DeserializeObject<List<Writer>>(objReader.ReadToEnd());
                        }
                    }
                }
                dgWriters.ItemsSource = Writeres;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetCountries()
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "Country");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            Countries = JsonConvert.DeserializeObject<List<Country>>(objReader.ReadToEnd());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void GetCities(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "City/" + id);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            Cities = JsonConvert.DeserializeObject<List<City>>(objReader.ReadToEnd());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Gender"></param>
        /// <param name="city"></param>
        private void CreateWriter(string Name, bool Gender, int city)
        {
            var client = new RestClient(url + "writer");
            try
            {
                Writer wr = new Writer()
                {
                    City = city,
                    Gender = Gender,
                    Id = 0,
                    Name = Name
                };
                string postData = JsonConvert.SerializeObject(wr);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", postData, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="Gender"></param>
        /// <param name="city"></param>
        private void EditWriter(int id, string Name, bool Gender, int city)
        {
            var client = new RestClient(url + "writer");
            try
            {
                Writer wr = new Writer()
                {
                    City = city,
                    Gender = Gender,
                    Id = id,
                    Name = Name
                };
                string postData = JsonConvert.SerializeObject(wr);
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", postData, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int DeleteWriter(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "writer/" + id);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            int result = 0;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return result;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            result = JsonConvert.DeserializeObject<int>(objReader.ReadToEnd());
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var CountrySelected = Countries.Where(x => x.Name.Equals(this.Country.SelectedItem.ToString())).FirstOrDefault();
                GetCities(CountrySelected.Id);
                this.City.ItemsSource = Cities.Select(a => a.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar las ciudades. " + ex.Message, "Error");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (validateForm())
                {
                    if (btnGuardar.Content.Equals("Guardar"))
                    {
                        CreateWriter(txtName.Text, Gender.SelectedItem.ToString() == "Masculino", Cities.Where(x => x.Name.Equals(City.SelectedItem.ToString())).Select(x => x.Id).FirstOrDefault());
                        GetWriters();
                    }
                    else
                    {
                        EditWriter(WriterSelected.Id, txtName.Text, Gender.SelectedIndex == 0, Cities.Where(x => x.Name.Equals(City.SelectedItem.ToString())).Select(x => x.Id).FirstOrDefault());
                        GetWriters();
                    }
                }
                else
                {
                    MessageBox.Show("Formulario no completado.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Autor", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wr"></param>
        private void loadForm(Writer wr)
        {
            txtName.Text = wr.Name;
            Gender.SelectedIndex = (bool)wr.Gender ? 0 : 1;
            GetCities(wr.CountryId);
            City.ItemsSource = Cities.Select(a => a.Name).ToList();
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i].Id == wr.City)
                {
                    City.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < Countries.Count; i++)
            {
                if (Countries[i].Id == wr.CountryId)
                {
                    Country.SelectedIndex = i;
                    break;
                }
            }
            btnGuardar.Content = "Editar";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool validateForm()
        {
            try
            {
                bool Result = !string.IsNullOrEmpty(this.txtName.Text)
                    && !string.IsNullOrEmpty(this.City.SelectedItem.ToString())
                    && !string.IsNullOrEmpty(this.Gender.SelectedItem.ToString());
                return Result;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgWriters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Writer wr = (Writer)dgWriters.SelectedItem;
                WriterSelected = wr;
                if (wr != null)
                {
                    loadForm(wr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            btnGuardar.Content = "Guardar";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Writer wr = (Writer)dgWriters.SelectedItem;
            MessageBoxResult dialogResult = MessageBox.Show("¿Desea eliminar al autor: " + wr.Name + "?", "Eliminar Autor", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                int result = DeleteWriter(wr.Id);
                if (result == 1)
                {
                    MessageBox.Show("Autor Eliminado con éxito", "Eliminar Autor", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("El autor no puede ser elminado", "Eliminar Autor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                GetWriters();
            }
        }
    }
}

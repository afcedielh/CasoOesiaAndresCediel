using BookShop.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace BookShop
{
    /// <summary>
    /// Lógica de interacción para Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        List<Books> Books = new List<Books>();
        Books BookSelected = new Books();
        List<Writer> Writeres = new List<Writer>();
        string url;
        public Book()
        {
            InitializeComponent();
            url = ConfigurationManager.AppSettings.Get("EndPoint");
            GetWriters();
            GetBooks();
            Writer.ItemsSource = Writeres.Select(x => x.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetBooks()
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "Book");
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
                            Books = JsonConvert.DeserializeObject<List<Books>>(objReader.ReadToEnd());
                        }
                    }
                }
                dgBooks.ItemsSource = Books;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar los escritores. " + ex.Message, "Error");
            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Error");
            }
        }


        private void CreateBook(Books data)
        {
            var client = new RestClient(url + "book");
            try
            {
                string postData = JsonConvert.SerializeObject(data);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", postData, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Error");
            }
        }

        private void UpdateBook(Books data)
        {
            var client = new RestClient(url + "book");
            try
            {
                string postData = JsonConvert.SerializeObject(data);
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", postData, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Error");
            }
        }


        private int DeleteBook(int data)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + "book/" + data);
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
        #region Events
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Books wr = (Books)dgBooks.SelectedItem;
            MessageBoxResult dialogResult = MessageBox.Show("¿Desea eliminar el libro: " + wr.Name + "?", "Eliminar libro", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                DeleteBook(wr.Id);
                GetBooks();
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Books wr = (Books)dgBooks.SelectedItem;
                BookSelected = wr;
                if (wr != null)
                {
                    loadForm(wr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error:" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void loadForm(Books wr)
        {
            try
            {
                txtName.Text = wr.Name;
                Date.Text = wr.Date;
                Price.Text = wr.Price.ToString();
                for (int i = 0; i < Writeres.Count; i++)
                {
                    if (Writeres[i].Id == wr.Writer)
                    {
                        Writer.SelectedIndex = i;
                        break;
                    }
                }
                btnGuardar.Content = "Editar";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error:" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    Books book = new Books()
                    {
                        Date = Date.DisplayDate.ToString("dd/MM/yyyy"),
                        Name = txtName.Text,
                        Price = int.Parse(Price.Text),
                        Writer = Writeres.Where(x => x.Name.Equals(Writer.SelectedItem.ToString())).Select(x => x.Id).FirstOrDefault(),
                        Id = BookSelected.Id
                    };
                    if (btnGuardar.Content.Equals("Guardar"))
                    {
                        CreateBook(book);
                        GetBooks();
                        MessageBox.Show("Libro creado con éxito", "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        UpdateBook(book);
                        GetBooks();
                        MessageBox.Show("Libro editado con éxito", "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error:" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            Date.Text = "";
            Price.Text = "";
            btnGuardar.Content = "Guardar";
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
                return false;
            if (string.IsNullOrEmpty(Writer.SelectedItem.ToString()))
                return false;
            if (string.IsNullOrEmpty(Price.Text))
                return false;
            return true;
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Drawing;

namespace NewsSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<News> newsList = new ObservableCollection<News>();
        public ObservableCollection<News> NewsList { get => newsList; set => Set(ref newsList, value); }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            //XmlDeSerialize();

            News news = new News()
            {
                Id = 1,
                NImageLink = @"\mainicon.ico",
                NPriority = 99,
                NLabel = "One News",
                NDateTime = DateTime.Now,
                NContent = "Текст новости!!!"
            };
        }

        void XmlSerialize()
        {
            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<News>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("News.xml", FileMode.Create))
            {
                formatter.Serialize(fs, NewsList);
            }
        }

        void XmlDeSerialize()
        {
            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<News>));
            // десериализация
            using (FileStream fs = new FileStream("News.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    NewsList = (ObservableCollection<News>)formatter.Deserialize(fs);
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }
            }
        }

    }
}

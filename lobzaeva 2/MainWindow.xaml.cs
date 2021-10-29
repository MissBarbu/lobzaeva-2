using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_7;
using LibMas;
using Microsoft.Win32;

namespace lobzaeva_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int[] mas;
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(inputN.Text, out int n)) return;
            //TextBoxesClear(null, null);
            mas = new int[n];
            ArrOperations.FillMasRandom(mas, -10, 10);
            string rezult = LibClass.Func(mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            rezultNumbers.Text = rezult;
        }

        private void TextBoxesClear(object sender, RoutedEventArgs e)
        {
            if (mas == null) return;
            rezultNumbers.Clear();
            ArrOperations.ClearMas(mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        private void SaveMas(object sender, RoutedEventArgs e)
        {
            if (mas == null)
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                ArrOperations.SaveMas(mas, save.FileName);
            }
        }
        private void openMas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                if (open.FileName != string.Empty)
                {
                    ArrOperations.OpenMas(out mas, open.FileName);
                    inputN.Text = mas.Length.ToString();
                    string rezult = LibClass.Func(mas);
                    dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                    rezultNumbers.Text = rezult;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик - Лобзаева Мария ИСП-31 \n\nВариант 7:\nВвести n целых чисел. Вычислить для чисел < 0 функцию x2. Результат обработки каждого числа вывести на экран.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void inputNumber_TextChanged(object sender, TextCompositionEventArgs e)
        {
            if (!Int32.TryParse(e.Text, out _))
            {
                e.Handled = true; // отклоняем ввод
                return;
            }
            TextBoxesClear(null, null);
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (mas == null) return;
            int columnIndex = e.Column.DisplayIndex;
            //Заносим полученное значение в массив
            mas[columnIndex] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            string rezult = LibClass.Func(mas);
            rezultNumbers.Text = rezult;
        }
    }
}

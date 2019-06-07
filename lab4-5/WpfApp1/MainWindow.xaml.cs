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
using System.Windows.Resources;
using System.Runtime.Serialization.Json;
using Microsoft.Win32;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<String> paths;
        public MainWindow()
        {
            InitializeComponent();

            this.richtextBox1.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(this.DragItem), true);
            this.richtextBox1.AddHandler(RichTextBox.DropEvent, new DragEventHandler(this.DropItem), true);

            List<string> styles = new List<string> { "pink", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "pink";
            listPaths.ItemsSource = paths;

            paths = JsonWorker.deserializeProducts<List<String>>();
            if (paths == null)
            {
                paths = new List<String>();
            }
        }

        private void listPaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = listPaths.SelectedItem.ToString();
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                TextRange range = new TextRange(richtextBox1.Document.ContentStart, richtextBox1.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
                UpdatePathList(path);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("File could not be opened.");
            }
        }

        private void UpdatePathList(String path)
        {
            SaveUri.saveUri(paths, path);
            listPaths.ItemsSource = paths;
        }

        private void DragItem(object sender, DragEventArgs e)  //перетащить
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }

        private void DropItem(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (System.IO.File.Exists(docPath[0]))
                {
                    try
                    {
                        TextRange range = new TextRange(this.richtextBox1.Document.ContentStart, this.richtextBox1.Document.ContentEnd);
                        FileStream fStream = new FileStream(docPath[0], FileMode.OpenOrCreate);
                        range.Load(fStream, DataFormats.Rtf);
                        fStream.Close();
                        this.Title = "Text Editor (" + docPath[0] + ") ";
                        UpdatePathList(docPath[0]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }

        public void ApplySelection(DependencyProperty property, object value)//для применения выбора
        {
            if (value != null)
            {
                richtextBox1.Selection.ApplyPropertyValue(property, value);//применяет свойство к указанному выделению
            }
        }

        private void ToolBar_SelectionChanged_1(object sender, SelectionChangedEventArgs e)//ф-ия тулбара где шрифты 
        {
            ComboBox source = e.OriginalSource as ComboBox;
            if (source == null) return;

            switch (source.Name)
            {
                case "fonts"://шрифты
                    ApplySelection(TextBlock.FontFamilyProperty, source.SelectedItem);//
                    break;
                case "fontSize"://размер
                    ApplySelection(TextBlock.FontSizeProperty, source.SelectedItem);
                    break;
                case "fontColor"://цвет букв
                    ApplySelection(TextBlock.ForegroundProperty, source.SelectedItem);
                    break;
                case "fontColor2"://фон
                    ApplySelection(TextBlock.BackgroundProperty, source.SelectedItem);
                    break;
            }
        }

        int GetLength(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            return textRange.Text.Length;
        }

        public static class Text
        {
            public static int size;
        }

        private void RichtextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string str = "characters: " + (GetLength(richtextBox1) - 1).ToString();
            label2.Content = str;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Save current file?", "Preservation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Save_Click(sender, e);
            }
            richtextBox1.Document.Blocks.Clear();
        }

        private void TextEditLoad(object sender, RoutedEventArgs e)
        {
            for (double i = 7; i < 49; i += 2)
            {
                fontSize.Items.Add(i);
            }

            fontColor.Items.Add("Black");
            fontColor.Items.Add("Red");
            fontColor.Items.Add("Green");
            fontColor.Items.Add("Blue");
            fontColor.Items.Add("Yellow");
            fontColor.Items.Add("Violet");
            fontColor.Items.Add("Pink");
            fontColor.Items.Add("Gold");

            fontColor2.Items.Add("Black");
            fontColor2.Items.Add("Red");
            fontColor2.Items.Add("Green");
            fontColor2.Items.Add("Blue");
            fontColor2.Items.Add("Yellow");
            fontColor2.Items.Add("Violet");
            fontColor2.Items.Add("Pink");
            fontColor2.Items.Add("Gold");
            richtextBox1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            // TimerCallback tm = new TimerCallback(GetLength);
            // Timer timer = new Timer(tm, richtextBox1, 0, 2000);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open file";
            dialog.Filter = "Text file (*.txt)|*.txt| All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                richtextBox1.Document.Blocks.Clear();
                string strfilename = dialog.FileName;
                using (StreamReader sr = new StreamReader(strfilename, Encoding.Default))//считывание с файла
                {
                    string filetext = sr.ReadToEnd();
                    richtextBox1.AppendText(filetext);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save file";
            dialog.Filter = "Text file (*.txt)|*.txt| All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName, true, Encoding.Default))
                {
                    string richText = new TextRange(richtextBox1.Document.ContentStart, richtextBox1.Document.ContentEnd).Text;
                    sw.Write(richText);
                }
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Save_Click(sender, e);

            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(richtextBox1 as Visual, "Printed notepad item");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Undo();//отменить шаг
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Redo();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Cut();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Copy();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.Paste();
        }

        private void Date_Click(object sender, RoutedEventArgs e)
        {
            richtextBox1.AppendText(DateTime.Now.ToString());
        }

        private void SetEng_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,/langEN.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void SetRus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,/langRU.xaml")
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void NewWind(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ThemeChange(object sender, RoutedEventArgs e)
        {
            //Uri uri = null;
            //bool isTheme = false;
            //ListBoxItem lbi = (ListBoxItem)sender;

            //switch (lbi.Name)
            //{
            //    case "Pink":
            //        {
            //            uri = new Uri("themes/pink.xaml", UriKind.Relative);
            //            Pink.IsSelected = false;
            //            isTheme = true;
            //            break;
            //        }
            //    case "Dark":
            //        {
            //            uri = new Uri("themes/dark.xaml", UriKind.Relative);
            //            Dark.IsSelected = false;
            //            isTheme = true;
            //            break;
            //        }
            //    default:
            //        break;
            //}
            //if (isTheme)
            //{
            //    ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //    Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            //}

            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri("themes/" + style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Menu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Custom control");
        }

        private void CustomControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Custom Control");
        }
    }
}

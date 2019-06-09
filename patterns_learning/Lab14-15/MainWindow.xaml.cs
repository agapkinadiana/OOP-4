using Lab14_15.Abstract_Factory;
using Lab14_15.Adapter;
using Lab14_15.Builder___Director___Prototype;
using Lab14_15.Command;
using Lab14_15.Composite;
using Lab14_15.Decorator;
using Lab14_15.Memento;
using Lab14_15.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Component = Lab14_15.Composite.Component;

namespace Lab14_15
{
    public partial class MainWindow : Window
    {
        private Pizza _latestOrder;

        public MainWindow()
        {
            InitializeComponent();
            KeyDown += MainWindow_KeyDown; ;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Roll_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void CreateCircleButton_Click(object sender, RoutedEventArgs e)
        {
            IShapeFactory factory = GetFactory();

            var circle = factory.createCircle();
            tbk.Text = circle.ToString();
        }
        private void CreateRectButton_Click(object sender, RoutedEventArgs e)
        {
            IShapeFactory factory = GetFactory();

            var rect = factory.createRect();
            tbk.Text = rect.ToString();

        }

        private IShapeFactory GetFactory()
        {
            if (BlueRadioBut.IsChecked == true)
            {
                return KingInTheNorth.Instance.GetBlueShapeFactory();
            }
            else return KingInTheNorth.Instance.GetRedShapeFactory();
        }

        private void MakePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            PizzaBuilder builder = new PizzaBuilder();
            var director = new PizzaDirector(builder);

            if (cmx.SelectedIndex == 0)
            {
                director.makeMargarita();
            }
            else if (cmx.SelectedIndex == 1)
                director.makePepperoni();
            else
                director.makeHavaiiPizza();

            var pizza = builder.getPizza();
            tbk1.Text = pizza.ToString();

            _latestOrder = pizza;
        }

        private void RepeatOrder_Click(object sender, RoutedEventArgs e)
        {
            if (_latestOrder != null)
            {
                var clone = _latestOrder.Clone();
                tbk2.Text = $"Повтор последнего заказа... \n{clone.ToString()}";
            }
        }

        private void Adapter_Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();

            Adapter.Pen pen = new Adapter.Pen();
            AdapterTxtbl.Text += student.Stuff(pen) + '\n';
            AdapterTxtbl.Text += "Упс... В ручке стержень закончился \n";

            Chalk chalk = new Chalk();
            IPen chalkStuff = new ChalkToPenAdapter(chalk);
            AdapterTxtbl.Text += student.Stuff(chalkStuff) + '\n';
        }

        private void Decorator_Button_Click(object sender, RoutedEventArgs e)
        {
            Cake Cake1 = new AppleCake();
            Cake1 = new DeliveryCake(Cake1);
            DecoratorTxtbl.Text += String.Format("Название: {0}\n", Cake1.Name);
            DecoratorTxtbl.Text += String.Format("Цена: {0}\n", Cake1.GetCost());

            Cake Cake2 = new AppleCake();
            Cake2 = new ThereCake(Cake2);
            DecoratorTxtbl.Text += String.Format("Название: {0}\n", Cake2.Name);
            DecoratorTxtbl.Text += String.Format("Цена: {0}\n", Cake2.GetCost());

            Cake Cake3 = new ChocolateCake();
            Cake3 = new DeliveryCake(Cake3);
            DecoratorTxtbl.Text += String.Format("Название: {0}\n", Cake3.Name);
            DecoratorTxtbl.Text += String.Format("Цена: {0}\n", Cake3.GetCost());

            Cake Cake4 = new ChocolateCake();
            Cake4 = new ThereCake(Cake4);
            DecoratorTxtbl.Text += String.Format("Название: {0}\n", Cake4.Name);
            DecoratorTxtbl.Text += String.Format("Цена: {0}\n", Cake4.GetCost());
        }

        Component Box = new Box("big box:");

        private void Composite_Button_Click(object sender, RoutedEventArgs e)
        {

            Component smallBox = new Box("small box");
            Component Item1 = new Item("book");
            Component Item2 = new Item("mobile");

            smallBox.Add(Item1);
            smallBox.Add(Item2);

            Box.Add(smallBox);
            CompositeTxtbl.Items.Add(Box.Print());


            smallBox.Remove(Item1);

            Component newBox = new Box("Gift box");

            Component Item3 = new Item("Candy");
            Component Item4 = new Item("Letter");
            newBox.Add(Item3);
            newBox.Add(Item4);
            Box.Add(newBox);

            CompositeTxtbl.Items.Add(Box.Print());
        }

        private void Find_Button_Click(object sender, RoutedEventArgs e)
        {
            CompositeTxtbl.Items.Add(Box.Search("Letter"));
        }

        private void Find2_Button_Click(object sender, RoutedEventArgs e)
        {
            CompositeTxtbl.Items.Add(Box.Search("Toy"));
        }


        //-----------------------------------------------------------------
        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                JumpCommand jump = new JumpCommand();
                jump.Execute();
            }

            if (e.Key == Key.W)
            {
                ClimbCommand climb = new ClimbCommand();
                climb.Execute();
            }
            if (e.Key == Key.F)
            {
                FireCommand fire = new FireCommand();
                fire.Execute();
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var p = new Person();
            p.SetName("Diana");
            p.SetAge(19);
            MessageBox.Show(p._name + "" + p._age);
            var memento = p.GetState();
            p.SetAge(20);
            MessageBox.Show(p._name + "" + p._age);
            p.SetState(memento);
            MessageBox.Show(p._name + "" + p._age);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();
            water.Frost();
        }
    }
}

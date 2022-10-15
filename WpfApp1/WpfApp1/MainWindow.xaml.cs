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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
        
                this.viewModel = new ViewModel
                {
                    DataGridItems = new List<DataGridItem>()
                {
                        new DataGridItem
                    {
                        ID = "1",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "0x2F",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x4F",
                        Six = "0x0F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "2",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "0212",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "3",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "012",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "4",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "2121",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "5",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "4121",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "6",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "0412",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "7",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "4111",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "8",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "0x0F",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "8",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "0x0F",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    },
                        new DataGridItem
                    {
                        ID = "7",
                        Zero = "0x00",
                        One= "0xF2",
                        Two = "0x0F",
                        Three = "0xFB",
                        Four = "0xFA",
                        Five = "0x00FF",
                        Six = "0x1F",
                        Seven = "0xFC"
                    }
                }
                };
                gridList.ItemsSource = this.viewModel.DataGridItems;

            var list = this.viewModel.DataGridItems;

            var filterList = list.Select(x => x.ID).Distinct();

            List<FilterValue> filterValues = new List<FilterValue>();
            foreach (var item in filterList)
            {
                filterValues.Add(new FilterValue { Id = item, check = true });
                filterGridList.ItemsSource = filterValues;
            }
        }

        public class FilterValue
        {
            public string Id { get; set; }
            public bool check { get; set; }
        }

        private void OnCheckedId(object sender, RoutedEventArgs e)
        {
            if (gridList.IsLoaded)
            {
                System.Windows.Controls.CheckBox cb = sender as System.Windows.Controls.CheckBox;
                List<DataGridItem> temp = new List<DataGridItem>();

                var remainList = gridList.ItemsSource;
                temp = remainList.Cast<DataGridItem>().ToList();
                var newList = temp.Where(x => x.ID != cb.Content.ToString());
                gridList.ItemsSource = newList;

                var datagriditems = this.viewModel.DataGridItems.Where(x => x.ID == cb.Content.ToString()).ToList();
                temp.AddRange(datagriditems);
                gridList.ItemsSource = temp;
            }
            else
            {

            }
        }


        private void OnUnCheckedId(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox cb = sender as System.Windows.Controls.CheckBox;
            List<DataGridItem> items = new List<DataGridItem>();

            var remainList = gridList.ItemsSource;
            items = remainList.Cast<DataGridItem>().ToList();
            var newList = items.Where(x => x.ID != cb.Content.ToString());

            gridList.ItemsSource = newList;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimplyOrder {
    public partial class MainWindow : Window {
        enum Category { Bestsellers, Burgers, Steaks, SaladSandwichs, AppetizersSoups, Omelettes, Kids, Drinks, DessertsShakes };
        Food[][] foods;

        ReqCustom[] ReqCus = {
            new ReqCustom ( "Size",
                new Dictionary<string, double>
                {
                    { "Large", 1.00 },
                    { "Medium", 1.00 },
                    { "Small", 1.00 }
                }
            )
        };
        OptCustom[] OptCus = {
            new OptCustom ( "Size2",
                new Dictionary<string, double>
                {
                    { "Large", 1.00 },
                    { "Medium", 1.00 },
                    { "Small", 1.00 }
                }
            ),
            new OptCustom ( "Size3",
                new Dictionary<string, double>
                {
                    { "Large", 1.00 },
                    { "Medium", 1.00 },
                    { "Small", 1.00 }
                }
            ),
        };

        //Load hard coded food info
        private void LoadFood() {
            foods = new Food[10][];
            Food test = new Food("test", 100, "this is a test food", "url", ReqCus, OptCus);
            Food test2 = new Food("test2", 100, "this is another test food", "url", ReqCus, OptCus);
            Food test3 = new Food("test3", 100, "this is another test food", "url", ReqCus, OptCus);
            Food test4 = new Food("test4", 100, "this is another test food", "url", ReqCus, OptCus);
            Food test5 = new Food("test5", 100, "this is another test food", "url",  ReqCus, OptCus);
            foods[(int)Category.Bestsellers] = new[] { test, test2, test3, test4, test5 };
        }

    }
}

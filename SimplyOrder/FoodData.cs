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

        ReqCustom[] ReqCus1 = {
            new ReqCustom ( "Size",
                new Dictionary<string, double>
                {
                    { "Large", 1.00 },
                    { "Medium", 1.00 },
                    { "Small", 1.00 }
                }
            )
        };
        OptCustom[] OptCus1 = {
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
            new OptCustom ( "Size3",
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
            new OptCustom ( "Size3",
                new Dictionary<string, double>
                {
                    { "Large", 1.00 },
                    { "Medium", 1.00 },
                    { "Small", 1.00 }
                }
            ),
        };

        ReqCustom[] ReqCus2 = {
            new ReqCustom ( "Size",
                new Dictionary<string, double>
                {
                    { "Large", 1.00 },
                    { "Medium", 1.00 },
                    { "Small", 1.00 }
                }
            )
        };
        OptCustom[] OptCus2 = {
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
            Food test = new Food("test", 100, "this is a test food", "url", ReqCus1, OptCus1);
            Food test2 = new Food("test2", 100, "this is another test food", "url", ReqCus2, OptCus2);
            Food test3 = new Food("test3", 100, "this is another test food", "url", ReqCus1, OptCus1);
            Food test4 = new Food("test4", 100, "this is another test food", "url", ReqCus1, OptCus1);
            Food test5 = new Food("test5", 100, "this is another test food", "url",  ReqCus1, OptCus1);
            foods[(int)Category.Bestsellers] = new[] { test, test2, test3, test4, test5 };
        }

    }
}

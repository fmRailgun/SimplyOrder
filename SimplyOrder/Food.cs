using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyOrder{
    
    class Food{
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desciption { get; set; }

        Dictionary<string, double> [] ReqCustom;
        Dictionary<string, double> [] OptCustom;

        public int ReqCustomeCount = 0;
        public int OptCustomeCount = 0;

        public Food(string name, double price, string desc, Dictionary<string, double> [] reqCustom, Dictionary<string, double> [] optCustom) {
            this.Name = name;
            this.Price = price;
            this.Desciption = desc;
            this.ReqCustom = reqCustom;
            this.OptCustom = optCustom;
            this.ReqCustomeCount = reqCustom.Length;
            this.OptCustomeCount = optCustom.Length;

            //Error Checking
            if (Math.Abs(this.Price * 100 % 100) > 0.0000001) {
                throw new System.ArgumentException("The price can only have two decimal places " + Math.Abs(this.Price * 100 % 100));
            }

            //Check the number of decimal places
            for (int i = 0; i < ReqCustomeCount; i++) {
                foreach (KeyValuePair<string, double> entry in this.ReqCustom[i]) {
                    if (Math.Abs(entry.Value * 100 % 100) > 0.0000001) {
                        throw new System.ArgumentException("The customization price can only have two decimal places");
                    }
                }
            }

            //Check the number of decimal places
            for (int i = 0; i < OptCustomeCount; i++) {
                foreach (KeyValuePair<string, double> entry in this.OptCustom[i]) {
                    if (Math.Abs(entry.Value * 100 % 100) > 0.0000001) {
                        throw new System.ArgumentException("The customization price can only have two decimal places");
                    }
                }
            }
        }
    }
}

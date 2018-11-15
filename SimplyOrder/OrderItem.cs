using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyOrder
{
    class OrderItem{
        public string Name;
        public int Count;
        public double BasicPrice;
        public double Price;
        Dictionary<string, bool> ReqCustom;
        Dictionary<string, bool> OptCustom;
        public OrderItem(string name, double basicPrice, Dictionary<string, bool> reqCustom, Dictionary<string, bool> optCustom) {
            this.Name = name;
            this.Count = 0;
            this.BasicPrice = basicPrice;
            this.Price = basicPrice;

            //Error Checking
            bool found = false;
            foreach(KeyValuePair<string, bool> entry in this.ReqCustom) {
                if (entry.Value) {
                    if (found) {
                        throw new System.ArgumentException("Can only choose one");
                    }
                    found = true;
                }
            }
            if (!found) {
                throw new System.ArgumentException("Need to choose at least one");
            }
            this.ReqCustom = reqCustom;
            this.OptCustom = optCustom;
        }
    }
}

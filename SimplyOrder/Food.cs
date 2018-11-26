using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyOrder{
    
    class Food{
        public string Name { get; set; }
        public double BasicPrice { get; set; }
        public double Price { get; set; }
        public string Desciption { get; set; }
        public string imagePath { get; set; }

        public ReqCustom[] RequiredCustom { get; set; }
        public OptCustom[] OptionalCustom { get; set; }
        
        public int OptionCount { get; set; }

        public Food(string name, double price, string desc) {
            this.Name = name;
            this.BasicPrice = price;
            this.Price = price;
            this.Desciption = desc;
        }

        public Food(string name, double price, string desc, string imagePath, ReqCustom[] reqCustom, OptCustom[] optCustom) {
            this.Name = name;
            this.BasicPrice = price;
            this.Price = price;
            this.Desciption = desc;
            this.RequiredCustom = reqCustom;
            this.OptionalCustom = optCustom;
            this.imagePath = imagePath;

            for (int i = 0; i < RequiredCustom.Length; i++) {
                OptionCount += RequiredCustom[i].Options.Length;
            }

            for (int i = 0; i < OptionalCustom.Length; i++) {
                OptionCount += OptionalCustom[i].Options.Length;
            }

            //Error Checking
            if (Math.Abs(this.Price * 100 % 100) > 0.0000001) {
                throw new System.ArgumentException("The price can only have two decimal places " + Math.Abs(this.Price * 100 % 100));
            }
        }

        public void CalculatePrice() {
            this.Price = this.BasicPrice;
            for (int i = 0; i < RequiredCustom.Length; i++) {
                this.Price += RequiredCustom[i].Options[RequiredCustom[i].Selected].Price;
            }

            for (int i = 0; i < OptionalCustom.Length; i++) {
                foreach (Option option in OptionalCustom[i].Options) {
                    if (option.Selected) {
                        this.Price += option.Price;
                    }
                }
            }
        }

        public static Food Clone(Food food) {
            Food result = new Food(food.Name, food.Price, food.Desciption);
            result.OptionCount = food.OptionCount;
            result.RequiredCustom = new ReqCustom[food.RequiredCustom.Length];
            for(int i = 0; i < food.RequiredCustom.Length; i++) {
                result.RequiredCustom[i] = ReqCustom.Clone(food.RequiredCustom[i]);
            }
            result.OptionalCustom = new OptCustom[food.OptionalCustom.Length];
            for (int i = 0; i < food.OptionalCustom.Length; i++) {
                result.OptionalCustom[i] = OptCustom.Clone(food.OptionalCustom[i]);
            }
            return result;
        }

    }
}

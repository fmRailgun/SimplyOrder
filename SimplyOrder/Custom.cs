using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimplyOrder {

    class Option {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Selected { get; set; }

        public Option(string name, double price, bool selected) {
            this.Name = name;
            this.Price = price;
            this.Selected = selected;

            //Error Checking
            if (Math.Abs(this.Price * 100 % 100) > 0.0000001) {
                throw new System.ArgumentException("The price can only have two decimal places " + Math.Abs(this.Price * 100 % 100));
            }
        }

        public static Option Clone(Option option) {
            return new Option(option.Name, option.Price, option.Selected);
        }
    }

    class ReqCustom {

        public string Name { get; set; }
        public Option [] Options { get; set; }
        public int Selected { get; set; }

        public ReqCustom(string name) {
            this.Name = name;
            this.Selected = 0;
        }

        public ReqCustom(string name, Dictionary<string, double> options) {
            this.Name = name;
            this.Selected = 0;
            Options = new Option[options.Count];
            //Check the number of decimal places

            int counter = 0;
            foreach (KeyValuePair<string, double> entry in options) {
                if (counter == 0) {
                    Option option = new Option(entry.Key, entry.Value, true);
                    Options[counter] = option;
                } else {
                    Option option = new Option(entry.Key, entry.Value, false);
                    Options[counter] = option;
                }
                counter += 1;
            }
        }

        public void Select(string name) {
            for(int i=0; i<this.Options.Length; i++) {
                if (this.Options[i].Name==name) {
                    this.Options[i].Selected = true;
                    this.Selected = i;
                } else {
                    this.Options[i].Selected = false;
                }
            }
        }

        public Option GetSelected() {
            return Options[Selected];
        }

        public static ReqCustom Clone(ReqCustom reqCustom) {
            ReqCustom result = new ReqCustom(reqCustom.Name);
            result.Options = new Option[reqCustom.Options.Length];
            for(int i=0;i< reqCustom.Options.Length; i++) {
                result.Options[i] = Option.Clone(reqCustom.Options[i]);
            }
            result.Selected = reqCustom.Selected;
            return result;
        }
    }

    class OptCustom {

        public string Name { get; set; }
        public Option[] Options { get; set; }
        int SelectedCount { get; set; }

        public OptCustom(string name) {
            this.Name = name;
        }

        public OptCustom(string name, Dictionary<string, double> options) {
            this.Name = name;
            Options = new Option[options.Count];
            this.SelectedCount = options.Count;

            int counter = 0;
            foreach (KeyValuePair<string, double> entry in options) {
                Option option = new Option(entry.Key, entry.Value, false);
                Options[counter] = option;
                counter += 1;
            }
        }

        public void Select(string name) {
            for (int i = 0; i < this.Options.Length; i++) {
                if (this.Options[i].Name == name) {
                    this.Options[i].Selected = !this.Options[i].Selected;
                    if (this.Options[i].Selected) {
                        SelectedCount++;
                    } else {
                        SelectedCount--;
                    }
                    break;
                }
            }
        }

        public Option[] GetSelected() {
            Option[] selected = new Option[SelectedCount];
            for (int i = 0; i < this.Options.Length; i++) {
                if (this.Options[i].Selected == true) {
                    selected[i] = this.Options[i];
                }
            }
            return selected;
        }

        public static OptCustom Clone(OptCustom reqCustom) {
            OptCustom result = new OptCustom(reqCustom.Name);
            result.Options = new Option[reqCustom.Options.Length];
            for (int i = 0; i < reqCustom.Options.Length; i++) {
                result.Options[i] = Option.Clone(reqCustom.Options[i]);
            }
            result.SelectedCount = reqCustom.SelectedCount;
            return result;
        }
    }

}

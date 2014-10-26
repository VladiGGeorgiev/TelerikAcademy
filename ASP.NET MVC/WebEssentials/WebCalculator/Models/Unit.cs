using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCalculator.ViewModel;

namespace WebCalculator.Models
{
    public static class Unit
    {
        public static Dictionary<string, decimal> CalculateUnits(CalculatorViewModel model)
        {
            var results = new Dictionary<string, decimal>();
            var units = GetUnits();
            if (units.ContainsKey(model.Type))
            {
                var unitTypeIndex = units[model.Type];
                foreach (var unit in units)
                {
                    if (model.Type.EndsWith("it"))
                    {
                        if (unit.Key.EndsWith("it"))
                        {
                            results.Add(unit.Key, model.Quantity * (decimal)Math.Pow(model.Kilo, (double)(unit.Value - unitTypeIndex)));
                        }
                        else if (unit.Key.EndsWith("yte"))
                        {
                            results.Add(unit.Key, model.Quantity / 8 * (decimal)Math.Pow(model.Kilo, (double)(unit.Value - unitTypeIndex)));
                        }
                    }
                    else if (model.Type.EndsWith("yte"))
                    {
                        if (unit.Key.EndsWith("yte"))
                        {
                            results.Add(unit.Key, model.Quantity * (decimal)Math.Pow(model.Kilo, (double)(unit.Value - unitTypeIndex)));
                        }
                        else if (unit.Key.EndsWith("it"))
                        {
                            results.Add(unit.Key, model.Quantity * 8 * (decimal)Math.Pow(model.Kilo, (double)(unit.Value - unitTypeIndex)));
                        }
                    }
                }
            }

            return results;
        }

        private static Dictionary<string, decimal> GetUnits()
        {
            var units = new Dictionary<string, decimal>();
            units.Add("Bit", 8);
            units.Add("Byte", 8);
            units.Add("Kilobit", 7);
            units.Add("Kilobyte", 7);
            units.Add("Megabit", 6);
            units.Add("Megabyte", 6);
            units.Add("Gigabit", 5);
            units.Add("Gigabyte", 5);
            units.Add("Terabit", 4);
            units.Add("Terabyte", 4);
            units.Add("Petabit", 3);
            units.Add("Petabyte", 3);
            units.Add("Exabit", 2);
            units.Add("Exabyte", 2);
            units.Add("Zettabit", 1);
            units.Add("Zettabyte", 1);
            units.Add("Yottabit", 0);
            units.Add("Yottabyte", 0);

            return units;
        }
    
    }
}